using Keno.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Keno.Business.Implementation
{
    public interface IKenoService
    {
        ClientViewModel GetClientById(long clientId);
        List<ClientViewModel> GetAllClients();

        UserViewModel GetUserById(long userId);
        UserViewModel GetUserByUsername(string username);

    }
}
