using Projeto.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.DAL.Contracts
{
    interface IClienteRepository : IBaseRepository<Cliente>
    {
        Cliente SelectByEmail(string email);
    }
}
