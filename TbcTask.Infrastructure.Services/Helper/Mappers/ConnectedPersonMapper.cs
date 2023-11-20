using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TbcTask.Domain.Models.Database;
using TbcTask.Domain.Models.Requests;

namespace TbcTask.Infrastructure.Services.Helper.Mappers
{
    public static class ConnectedPersonMapper
    {
        public static ConnectedPersons AsConnectedPersonsDatabaseModel(this AddConnectedPersonsRequest model)
        {
            return new ConnectedPersons
            {
                ConnectedPersonId = model.ConnectedPersonID.Value,
                PhysicialPersonId = model.PhysicalPersonID.Value,
                PersonConnectionTypeID = model.ConnectionTypeID.Value,
            };
        }
        public static ConnectedPersons AsConnectedPersonDatabaseModel(this RemoveConnectedPersonsRequest model)
        {
            return new ConnectedPersons()
            {
                ConnectedPersonId = model.ConnectedPersonID.Value,
                PhysicialPersonId = model.PhysicalPersonID.Value,
                PersonConnectionTypeID = model.ConnectionTypeID.Value,
            };
        }
    }
}
