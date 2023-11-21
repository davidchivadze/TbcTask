using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TbcTask.Domain.Models.Database;
using TbcTask.Domain.Models.Requests;
using TbcTask.Domain.Models.Responses;
using TbcTask.Infrastructure.Services.Helper.FileManager;

namespace TbcTask.Infrastructure.Services.Helper.Mappers
{
    public static class PhysicalPersonMapper
    {
        public static PhysicalPerson AsDatabaseModel(this AddPhysicalPersonRequest model)
        {
            return new PhysicalPerson
            {
                CityID = model.CityID,
                DateOfBirth = model.DateOfBirth,
                FirstName = model.FirstName,
                GenderID = model.GenderID,
                LastName = model.LastName,
                PhoneNumbers = model.PhoneNumbers.Select(m => m.AsDatabaseModel()).ToList(),
                PrivateNumber = model.PrivateNumber,
            };
        }
        public static Phone AsDatabaseModel(this AddHysicalPersonPhoneRequestItem model)
        {
            return new Phone()
            {
                PhoneTypeID = model.TypeID,
                PhoneNumber = model.PhoneNumber,
            };
        }
        public static AddPhysicalPersonResponse AsAddPhysicalPersonViewModel(this PhysicalPerson model)
        {
            return new AddPhysicalPersonResponse()
            {
                Id = model.Id,
            };
        }
        public static GetPhysicalPersonFullDataResponse AsGetPhysicalPersonFullDataViewModel(this PhysicalPerson model)
        {
            return new GetPhysicalPersonFullDataResponse()
            {
                Id = model.Id,
                City = model.City?.Name,
                ConnectedPersons = model.ConnectedPersons?.Select(m => m.PhysicialPerson.AsConnectedPersonViewModel()).ToList(),
                DateOfBirth = model.DateOfBirth,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender?.Name,
                Image = !String.IsNullOrEmpty(model.ImageAddress) ? FileManager.FileManager.GetFileFromServer("Uploads", model.ImageAddress) : "",
                PhoneNumbers = model.PhoneNumbers?.Select(m => m.AsPhoneNumberViewModel()).ToList(),
                PrivateNumber = model.PrivateNumber,
            };
        }
        public static ConnectedPersonResponse AsConnectedPersonViewModel(this PhysicalPerson model)
        {
            return new ConnectedPersonResponse()
            {
                Id = model.Id,
                City = model.City?.Name,
                DateOfBirth = model.DateOfBirth,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender?.Name,
                ImageAddress = !String.IsNullOrEmpty(model.ImageAddress) ? FileManager.FileManager.GetFileFromServer("Uploads", model.ImageAddress) : "",
                PhoneNumbers = model.PhoneNumbers?.Select(m => m.AsPhoneNumberViewModel()).ToList(),
                PrivateNumber = model.PrivateNumber,
            };
        }
        public static PhysicalPerson AsEditPhysicalPersonDatabaseModel(this EditPhysicalPersonRequest model)
        {
            return new PhysicalPerson()
            {
                CityID = model.CityID,
                DateOfBirth = model.DateOfBirth,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PrivateNumber = model.PrivateNumber,
                GenderID = model.GenderID,
                Id = model.Id.Value,

            };
        }
        public static Phone AsPhoneDatabaseModel(this EditPhoneNumberRequest model, int personID)
        {
            return new Phone()
            {
                Id = model.Id??0,
                PhoneNumber = model.PhoneNumber,
                PhoneTypeID = model.TypeID,
                PhysicalPersonID = personID
            };
        }
        public static EditPhysicalPersonResponse AsEditPhysicalPersonViewModel(this PhysicalPerson model)
        {
            return new EditPhysicalPersonResponse()
            {
                Id = model.Id,
                City = model.City?.Name,
                DateOfBirth = model.DateOfBirth,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender?.Name,
                ImageAddress = model.ImageAddress,
                PhoneNumbers = model.PhoneNumbers?.Select(m => m.AsPhoneNumberViewModel()).ToList(),
                PrivateNumber = model.PrivateNumber,
            };
        }
        public static PhoneNumberResponse AsPhoneNumberViewModel(this Phone phone)
        {
            return new PhoneNumberResponse()
            {
                PhoneNumber = phone.PhoneNumber,
                Type = phone.PhoneType.Name
            };
        }
        public static SearchPhysicalPersonDataResponse AsSearchPhysicalPersonDataViewModel(this PhysicalPerson model)
        {
            return new SearchPhysicalPersonDataResponse()
            {
                Id = model.Id,
                City = model.City?.Name,
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,
                Gender = model.Gender?.Name,
                PhoneNumbers = model.PhoneNumbers?.Select(m => m.AsPhoneNumberViewModel()).ToList(),
                PrivateNumber = model.PrivateNumber,
                Image = String.IsNullOrEmpty(model.ImageAddress) ? "" : FileManager.FileManager.GetFileFromServer("Uploads", model.ImageAddress)
            };
        }
        public static DeletePhysicalPersonResponse AsDeletePhysicalPersonViewModel(this PhysicalPerson model)
        {
            return new DeletePhysicalPersonResponse()
            {
                Id = model.Id,
                City = model.City?.Name,
                //ConnectedPersons = model.ConnectedPersons?.Select(m => m.PhysicialPerson.AsConnectedPersonViewModel()).ToList(),
                DateOfBirth = model.DateOfBirth,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender?.Name,
                Image = !String.IsNullOrEmpty(model.ImageAddress) ? FileManager.FileManager.GetFileFromServer("Uploads", model.ImageAddress) : "",
                PhoneNumbers = model.PhoneNumbers?.Select(m => m.AsPhoneNumberViewModel()).ToList(),
                PrivateNumber = model.PrivateNumber,
            };
        }
    }
}
