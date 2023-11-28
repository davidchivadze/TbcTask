using System.ComponentModel.DataAnnotations;
using TbcTask.Domain.Models.Database;
using TbcTask.Domain.Models.Database.Reports;
using TbcTask.Domain.Models.Exceptions;
using TbcTask.Domain.Models.Requests;
using TbcTask.Domain.Models.Resources;
using TbcTask.Domain.Models.Responses;
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

        public async Task<AddConnectedPersonsResponse> AddConnectedPersonsAsync(AddConnectedPersonsRequest request)
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
                        ConnectedPersonID = request.ConnectedPersonID,
                        PhysicalPersonID = request.PhysicalPersonID,
                    };
                }catch(Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw;
                }
            }
        }

        public async Task<AddOrUpdatePersonImageResponse> AddOrUploadPersonImageAsync(AddOrUpdatePersonImageRequest request, string uploadFolder)
        {
            var person = _unitOfWork.physicalPersonRepository.GetById(request.Id);
            if (person != null)
            {
                var updatePhoto = FileManager.StoreFileOnServer(request.PhysicalPersonImage, uploadFolder);
                _unitOfWork.physicalPersonRepository.UpdatePersonImageAddress(request.Id, updatePhoto);
                return new AddOrUpdatePersonImageResponse()
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

        public async Task<AddPhysicalPersonResponse> AddPhysicalPersonAsync(AddPhysicalPersonRequest addphysicalPersonRequest)
        {
            var result = _unitOfWork.physicalPersonRepository.AddPhysicalPerson(addphysicalPersonRequest.AsDatabaseModel());
            _unitOfWork.Save();
            return result.AsAddPhysicalPersonViewModel();
        }

        public async Task<DeletePhysicalPersonResponse> DeletePhysicalPersonAsync(DeletePhysicalPersonRequest request)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    var result = _unitOfWork.physicalPersonRepository.GetPhysicalPersonFullData(request.Id);
                    if (result != null)
                    {
                        result.IsDeleted = true;
                        if (result.ConnectedPersons != null && result.ConnectedPersons.Count > 0)
                        {
                            foreach(var person in result.ConnectedPersons)
                            {
                                _unitOfWork.connectedPersonRepository.DeleteConnection(person);
                            }
                        }
                        _unitOfWork.Save();
                        _unitOfWork.CommitTransaction();
                        return result.AsDeletePhysicalPersonViewModel();
                    }
                    else
                    {
                        throw new DataNotFoundException(ErrorResponses.DataNotFound);
                    }
                }catch(Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new DatabaseValidationException(ex.Message);
                }
            }
        }

        public async Task<EditPhysicalPersonResponse> EditPhysicalPersonAsync(EditPhysicalPersonRequest editphysicalPersonRequest)
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
                            throw new DatabaseValidationException(String.Format(ValidationMessages.PhoneNumberNotFound, phone.Id, updatePerson.Id));
                        }
                        else
                        {
                            if (phone.Id != 0)
                            {
                                _unitOfWork.phoneNumberRepository.UpdatePhoneNumber(phone.AsPhoneDatabaseModel(updatePerson.Id));
                            }
                            else
                            {
                                _unitOfWork.phoneNumberRepository.Add(phone.AsPhoneDatabaseModel(updatePerson.Id));
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

        public async Task<GetPhysicalPersonFullDataResponse> GetPhysicalPersonFullDataAsync(GetPhysicalPersonFullDataRequest request)
        {
            var result = _unitOfWork.physicalPersonRepository.GetPhysicalPersonFullData(request.Id);
            if (result != null)
            {
                return result.AsGetPhysicalPersonFullDataViewModel();
            }
            else
            {
                throw new DataNotFoundException(ErrorResponses.DataNotFound);
            }
        }

        public async Task<RemoveConnectedPersonsResponse> RemoveConnectedPersonsAsync(RemoveConnectedPersonsRequest request)
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

        public async Task<List<SearchPhysicalPersonDataResponse>> SearchPhysicalPersonDataAsync(SearchPhysicalPersonDataRequest request)
        {
            var result = _unitOfWork.physicalPersonRepository.SearchPhysicalPersonData(request.Key,(request.CountPerPage*(request.Page-1)),request.CountPerPage);
            if(result.Count == 0)
            {
                throw new DataNotFoundException(ErrorResponses.DataNotFound);
            }
            var returnResult = result.Select(m => m.AsSearchPhysicalPersonDataViewModel()).ToList();
            return returnResult;
        }
        public async Task<List<PhysicalPersonConnectionReportResponse>> PhysicalPersonConnectionReportAsync()
        {
            var result=_unitOfWork.physicalPersonRepository.PhysicalPersonConnectionReport();
            return result.Data.Select(m => m.AsPhysicalPersonConnectionReportViewModel()).ToList();
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