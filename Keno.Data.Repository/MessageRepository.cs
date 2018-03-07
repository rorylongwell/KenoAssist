using Keno.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Keno.Data.Repository
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(KenoEntities context) : base(context)
        {
            this.context = context;

        }

        public List<Message> GetRecievedMessagesByUserId(long userId)
        {
            return context.Messages.Where(m => m.ToUserId == userId).ToList();
        }

        public List<Message> GetSentMessagesByUserId(long userId)
        {
            return context.Messages.Where(m => m.FromUserId == userId).ToList();
        }
    }
}
