﻿using System;
using System.Collections.Generic;
using Keno.Data;

namespace Keno.Business.Implementation
{
    public class KenoService : IKenoService
    {
        public KenoService()
        {
        }

        public List<ClientViewModel> GetAllClients()
        {
            throw new NotImplementedException();
        }

        public ClientViewModel GetClientById(long clientId)
        {
            throw new NotImplementedException();
        }

        public UserViewModel GetUserById(long userId)
        {
            throw new NotImplementedException();
        }

        public UserViewModel GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        #region Model Mapping

        public ClientViewModel MapDomainToViewModel(Client model){

            ClientViewModel result = null;

            result = new ClientViewModel()
            {
                Id = result.Id,
                Forename = result.Forename,
                Surname = result.Surname,
                DateOfBirth = result.DateOfBirth,
                DateCreated = result.DateCreated,
                DateModified = result.DateModified,
                Location = result.Location,
                Deleted = result.Deleted

            };

            return result;
        }

        public Client MapDomainToViewModel(ClientViewModel model)
        {

            Client result = null;

            result = new Client()
            {
                Id = result.Id,
                Forename = result.Forename,
                Surname = result.Surname,
                DateOfBirth = result.DateOfBirth,
                DateCreated = result.DateCreated,
                DateModified = result.DateModified,
                Location = result.Location,
                Deleted = result.Deleted

            };

            return result;
        }

        #endregion

    }
}
