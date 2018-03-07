using Keno.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Keno.Data.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        KenoContext context;

        public UnitOfWork(KenoContext kenoContext)
        {
            this.context = new KenoContext();
            context = kenoContext;
            InitializeRepositories();
        }

        private void InitializeRepositories()
        {
            ClientRepository = new ClientRepository(this.context);
            ClientConditionRepository = new ClientConditionRepository(this.context);
            ClientDrinkRepository = new ClientDrinkRepository(this.context);
            ClientFoodRepository = new ClientFoodRepository(this.context);
            ClientIncidentRepository = new ClientIncidentRepository(this.context);
            ClientInformationRepository = new ClientInformationRepository(this.context);
            DrinkRepository = new DrinkRepository(this.context);
            FoodRepository = new FoodRepository(this.context);
            IncidentRepository = new IncidentRepository(this.context);
            IncidentPhotoRepository = new IncidentPhotoRepository(this.context);
            UserRepository = new UserRepository(this.context);
            UserIncidentRepository = new UserIncidentRepository(this.context);
            UserTypeRepository = new UserTypeRepository(this.context);
            MessageRepository = new MessageRepository(this.context);
        }

        public IClientRepository ClientRepository { get; set; }

        public IClientConditionRepository ClientConditionRepository { get; set; }

        public IClientDrinkRepository ClientDrinkRepository { get; set; }

        public IClientFoodRepository ClientFoodRepository { get; set; }

        public IClientIncidentRepository ClientIncidentRepository { get; set; }

        public IClientInformationRepository ClientInformationRepository { get; set; }

        public IDrinkRepository DrinkRepository { get; set; }

        public IFoodRepository FoodRepository { get; set; }

        public IIncidentRepository IncidentRepository { get; set; }

        public IIncidentPhotoRepository IncidentPhotoRepository { get; set; }

        public IUserRepository UserRepository { get; set; }

        public IUserIncidentRepository UserIncidentRepository { get; set; }

        public IUserTypeRepository UserTypeRepository { get; set; }

        public IMessageRepository MessageRepository { get; set; }

        public int Commit()
        {
            return context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
