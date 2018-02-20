using System;
using System.Collections.Generic;
using System.Text;

namespace Keno.Data.Contracts
{
    public interface IUnitOfWork
    {
        int Commit();

        IClientRepository ClientRepository { get; }
        IClientConditionRepository ClientConditionRepository { get; }
        IClientDrinkRepository ClientDrinkRepository { get; }
        IClientFoodRepository ClientFoodRepository { get; }
        IClientIncidentRepository ClientIncidentRepository { get; }
        IClientInformationRepository ClientInformationRepository { get; }
        IDrinkRepository DrinkRepository { get; }
        IFoodRepository FoodRepository { get; }
        IIncidentRepository IncidentRepository { get; }
        IIncidentPhotoRepository IncidentPhotoRepository { get; }
        IUserRepository UserRepository { get; }
        IUserIncidentRepository UserIncidentRepository { get; }
        IUserTypeRepository UserTypeRepository { get; }
    }
}
