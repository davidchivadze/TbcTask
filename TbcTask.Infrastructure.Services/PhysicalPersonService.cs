using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using TbcTask.Domain.Models.Database;
using TbcTask.Domain.Models.Exceptions;
using TbcTask.Domain.Models.Requests;
using TbcTask.Domain.Models.Resources;
using TbcTask.Domain.Models.Responses;
using TbcTask.Domain.Models.Responses.Base;
using TbcTask.Domain.Repository;
using TbcTask.Domain.Services;
using TbcTask.Infrastructure.Services.Helper.FileManager;
using TbcTask.Infrastructure.Services.Helper.Mappers;

namespace TbcTask.Infrastructure.Services
{
    public class PhysicalPersonService : IPhysicalPersonService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PhysicalPersonService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AddConnectedPersonsResponse> AddConnectedPersons(AddConnectedPersonsRequest request)
        {
            using (var transaction=_unitOfWork.BeginTransaction())
            {
                var connectedPersons = request.AsConnectedPersonsDatabaseModel();
                try
                {
                    ValidateAddOrRemoveConnectedPersons(connectedPersons);
                    var connectionExist = _unitOfWork.connectedPersonRepository.GetIfConnectionExist(connectedPersons);



                    if (connectionExist == null)
                    {
                        _unitOfWork.connectedPersonRepository.AddConnectedPeople(connectedPersons);

                    }
                    else
                    {
                        if (connectionExist.IsDeleted)
                        {
                            _unitOfWork.connectedPersonRepository.UpdateConnection(connectedPersons);
                        }
                        else
                        {
                            throw new DatabaseValidationException(ErrorResponses.ConnectionExist);
                        }
                    }
                    _unitOfWork.Save();
                    _unitOfWork.CommitTransaction();
                    return new AddConnectedPersonsResponse()
                    {
                        Success = true,
                        ConnectedPersonID = request.ConnectedPersonID.Value,
                        PhysicalPersonID = request.PhysicalPersonID.Value,
                    };
                }catch(Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw;
                }
            }
        }

        public async Task<UploadPersonImageResponse> AddOrUploadPersonImage(UploadPersonImageRequest request, string uploadFolder)
        {
            var person = _unitOfWork.physicalPersonRepository.GetById(request.Id);
            if (person != null)
            {
                var updatePhoto = FileManager.StoreFileOnServer(request.PhysicalPersonImage, uploadFolder);
                _unitOfWork.physicalPersonRepository.UpdatePersonImageAddress(request.Id, updatePhoto);
                return new UploadPersonImageResponse()
                {
                    PhysicalPersonID = request.Id,
                    ImageAddress = updatePhoto
                };
            }
            else
            {
                throw new DataNotFoundException(ErrorResponses.DataNotFound);
            }

        }

        public async Task<AddPhysicalPersonResponse> AddPhysicalPerson(AddPhysicalPersonRequest addphysicalPersonRequest)
        {
            var result = _unitOfWork.physicalPersonRepository.AddPhysicalPerson(addphysicalPersonRequest.AsDatabaseModel());
            return result.AsViewModel();
        }

        public async Task<GetPhysicalPersonFullDataResponse> DeletePhysicalPerson(int Id)
        {

            var result = _unitOfWork.physicalPersonRepository.GetPhysicalPersonFullData(Id);
            if (result != null)
            {
                result.IsDeleted = true;
                _unitOfWork.Save();
                return result.AsGetPhysicalPersonFullDataViewModel();
            }
            else
            {
                throw new DataNotFoundException(ErrorResponses.DataNotFound);
            }
        }

        public async Task<EditPhysicalPersonResponse> EditPhysicalPerson(EditPhysicalPersonRequest editphysicalPersonRequest)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    
                    var updatePerson = _unitOfWork.physicalPersonRepository.EditPhysicalPerson(editphysicalPersonRequest.AsEditPhysicalPersonDatabaseModel());
                    foreach (var phone in editphysicalPersonRequest.PhoneNumbers)
                    {
                        if (!updatePerson.PhoneNumbers.Any(m => m.Id == phone.Id) && phone.Id != 0)
                        {
                            throw new ValidationException(String.Format(ValidationMessages.PhoneNumberNotFound, phone.Id, updatePerson.Id));
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
                catch (Exception ex)
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
                throw new DataNotFoundException(ErrorResponses.DataNotFound);
            }
        }

        public async Task<RemoveConnectedPersonsResponse> RemoveConnectedPersons(RemoveConnectedPersonsRequest request)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                var connectedPersons = request.AsConnectedPersonDatabaseModel();
                try
                {
                    ValidateAddOrRemoveConnectedPersons(connectedPersons);
                    var connectionExist = _unitOfWork.connectedPersonRepository.GetIfConnectionExist(connectedPersons);

                        if (connectionExist == null) { throw new DatabaseValidationException(ErrorResponses.ConnectionDontExist); }
                        _unitOfWork.connectedPersonRepository.DeleteConnection(connectedPersons);


                    _unitOfWork.Save();
                    _unitOfWork.CommitTransaction();
                    return new RemoveConnectedPersonsResponse()
                    {
                        Success = true,
                        ConnectedPersonID = connectedPersons.ConnectedPersonId,
                        PhysicalPersonID = connectedPersons.PhysicialPersonId
                    };

                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw;
                }
            }
        }

        private void ValidateAddOrRemoveConnectedPersons(ConnectedPersons request)
        {

            var person = _unitOfWork.physicalPersonRepository.GetById(request.PhysicialPersonId);
            if (person == null || person.IsDeleted) throw new DataNotFoundException(String.Format(ErrorResponses.PersonNotFoundWIthID, request.PhysicialPersonId));
            var connectedPerson = _unitOfWork.physicalPersonRepository.GetById(request.ConnectedPersonId);
            if (connectedPerson == null || connectedPerson.IsDeleted) throw new DataNotFoundException(String.Format(ErrorResponses.PersonNotFoundWIthID, request.ConnectedPersonId));
        }
    }
}