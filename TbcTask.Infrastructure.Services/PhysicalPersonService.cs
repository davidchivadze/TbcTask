using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using TbcTask.Domain.Models.Exceptions;
using TbcTask.Domain.Models.Requests;
using TbcTask.Domain.Models.Resources;
using TbcTask.Domain.Models.Responses;
using TbcTask.Domain.Models.Responses.Base;
using TbcTask.Domain.Repository;
using TbcTask.Domain.Services;
using TbcTask.Infrastructure.Services.Helper;

namespace TbcTask.Infrastructure.Services
{
    public class PhysicalPersonService : IPhysicalPersonService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PhysicalPersonService(IUnitOfWork unitOfWork) { 
          _unitOfWork = unitOfWork;
        }

        public async Task<UploadPersonImageResponse> AddOrUploadPersonImage(UploadPersonImageRequest request, string uploadFolder)
        {
                var person=_unitOfWork.physicalPersonRepository.GetById(request.Id);
                if (person != null) {
                    var updatePhoto = this.UploadImage(request.PhysicalPersonImage, uploadFolder);
                    _unitOfWork.physicalPersonRepository.UpdatePersonImageAddress(request.Id, updatePhoto);
                return new UploadPersonImageResponse()
                {
                    PhysicalPersonID = request.Id,
                    ImageAddress = updatePhoto
                };
                }
                else
                {
                    throw new DataNotFoundException(ValidationMessages.DataNotFound);
                }

        }

        public async Task<AddPhysicalPersonResponse> AddPhysicalPerson(AddPhysicalPersonRequest addphysicalPersonRequest)
        {
            var result= _unitOfWork.physicalPersonRepository.AddPhysicalPerson(addphysicalPersonRequest.AsDatabaseModel());
            return result.AsViewModel();
        }

        public async Task<EditPhysicalPersonResponse> EditPhysicalPerson(EditPhysicalPersonRequest editphysicalPersonRequest)
        {
            using(var unitOfWork  = _unitOfWork)
            {
                try
                {

                    unitOfWork.BeginTransaction();
                    var updatePerson = _unitOfWork.physicalPersonRepository.EditPhysicalPerson(editphysicalPersonRequest.AsEditPhysicalPersonDatabaseModel());
                    foreach (var phone in editphysicalPersonRequest.PhoneNumbers)
                    {
                        if (!updatePerson.PhoneNumbers.Any(m => m.Id == phone.Id) && phone.Id != 0)
                        {
                            throw new ValidationException("Phone Number with ID:" + phone.Id
                                + " Don't Belong Person with ID:" + updatePerson.Id);
                        }
                        else
                        {
                            if (phone.Id != 0)
                            {
                                _unitOfWork.phoneNumberRepository.UpdatePhoneNumber(phone.AsEditPhoneDatabaseModel(updatePerson.Id));
                            }
                            else
                            {
                                _unitOfWork.phoneNumberRepository.Add(phone.AsEditPhoneDatabaseModel(updatePerson.Id));
                            }
                        }

                    }
                    
                    _unitOfWork.Save();
                    _unitOfWork.CommitTransaction();
                    _unitOfWork.physicalPersonRepository.GetPhysicalPersonFullData(updatePerson.Id);
                    return updatePerson.AsEditPhysicalPersonViewModel();
                }
                catch(Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw ex;
                }
            }
            
        }

        public async Task<GetPhysicalPersonFullDataResponse> GetPhysicalPersonFullData(int id)
        {
            var result = _unitOfWork.physicalPersonRepository.GetPhysicalPersonFullData(id);
            if (result != null)
            {
                return result.AsGetPhysicalPersonFullDataViewModel();
            }
            else
            {
                throw new DataNotFoundException(ValidationMessages.DataNotFound);
            }
        }
        private string UploadImage(IFormFile file,string path)
        {
            var fileName = $"{Guid.NewGuid().ToString()}_{file.FileName}";
            var directory = Path.Combine(path, "Uploads");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            var uploadsFolder = Path.Combine(directory, fileName);
            using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return uploadsFolder;
        }
    }
}