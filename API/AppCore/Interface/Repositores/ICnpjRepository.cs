using AppCore.Entities;
using AppCore.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Interface.Repositores
{
    public interface ICnpjRepository : IBaseRepository<CNPJEntity>
    {
        Task<ValidResult<CNPJEntity>> GetCnpj(GetCnpj cnpj);
    }
}
