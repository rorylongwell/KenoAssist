using System;
using System.Collections.Generic;
using System.Text;

namespace Keno.Data.Contracts
{
    public interface IMessageRepository : IRepository<Message>
    {
        List<Message> GetSentMessagesByUserId(long userId);
        List<Message> GetRecievedMessagesByUserId(long userId);
    }
}
