using System;
using System.Collections.Generic;
using Keno.Data;
using Keno.Data.Contracts;
using Keno.Data.Repository;

namespace Keno.Business.Implementation
{
    public class KenoService : IKenoService
    {
        IUnitOfWork uow;
        public KenoService(KenoEntities context)
        {
            uow = new UnitOfWork(context);

        }

        public KenoService()
        {
            uow = new UnitOfWork(new KenoEntities());
        }

        public List<ClientViewModel> GetAllClients()
        {
            var items = uow.ClientRepository.GetAll();
            var models = new List<ClientViewModel>();
            foreach (var item in items)
            {
                models.Add(MapDomainToViewModel(item));
            }
            return models;
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

        public ClientViewModel MapDomainToViewModel(Client model)
        {

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

        public Client MapViewToDomainModel(ClientViewModel model)
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

        public UserViewModel AddUser(UserViewModel user)
        {
            throw new NotImplementedException();
        }

        public UserViewModel UpdateUser(UserViewModel user)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(long userId)
        {
            throw new NotImplementedException();
        }

        public ClientViewModel AddClient(ClientViewModel client)
        {
            throw new NotImplementedException();
        }

        public ClientViewModel UpdateClient(ClientViewModel client)
        {
            throw new NotImplementedException();
        }

        public bool DeleteClient(long clientId)
        {
            throw new NotImplementedException();
        }

        public ClientConditionViewModel GetClientConditionById(long clientConditionId)
        {
            throw new NotImplementedException();
        }

        public List<ClientConditionViewModel> GetAllClientConditionsByClientId(long clientId)
        {
            throw new NotImplementedException();
        }

        public ClientConditionViewModel AddClientCondition(ClientConditionViewModel clientCondition)
        {
            throw new NotImplementedException();
        }

        public ClientConditionViewModel UpdateClientCondition(ClientConditionViewModel clientCondition)
        {
            throw new NotImplementedException();
        }

        public bool DeleteClientCondition(long clientConditionId)
        {
            throw new NotImplementedException();
        }

        public ClientFoodViewModel GetClientFoodById(long clientFoodId)
        {
            throw new NotImplementedException();
        }

        public List<ClientFoodViewModel> GetAllClientFoodsByClientId(long clientId)
        {
            throw new NotImplementedException();
        }

        public ClientFoodViewModel AddClientFood(ClientFoodViewModel clientFood)
        {
            throw new NotImplementedException();
        }

        public ClientFoodViewModel UpdateClientFood(ClientFoodViewModel clientFood)
        {
            throw new NotImplementedException();
        }

        public bool DeleteClientFood(long clientFoodId)
        {
            throw new NotImplementedException();
        }

        public ClientDrinkViewModel GetClientDrinkById(long clientDrinkId)
        {
            throw new NotImplementedException();
        }

        public List<ClientDrinkViewModel> GetAllClientDrinksByClientId(long clientId)
        {
            throw new NotImplementedException();
        }

        public ClientDrinkViewModel AddClientDrink(ClientDrinkViewModel clientDrink)
        {
            throw new NotImplementedException();
        }

        public ClientDrinkViewModel UpdateClientDrink(ClientDrinkViewModel clientDrink)
        {
            throw new NotImplementedException();
        }

        public bool DeleteClientDrink(long clientDrinkId)
        {
            throw new NotImplementedException();
        }

        public IncidentViewModel GetIncidentById(long incidentId)
        {
            throw new NotImplementedException();
        }

        public List<IncidentViewModel> GetAllIncidents()
        {
            throw new NotImplementedException();
        }

        public IncidentViewModel AddIncident(IncidentViewModel incident)
        {
            throw new NotImplementedException();
        }

        public IncidentViewModel UpdateIncident(IncidentViewModel incident)
        {
            throw new NotImplementedException();
        }

        public bool DeleteIncident(long incidentId)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
