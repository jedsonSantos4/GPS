using AppCore.Entities;
using AppCore.Interface.Services;
using AppCore.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Services
{
    public interface ICnpjService2 : IBaseService<CNPJEntity>
    {
        Task<ValidResult<CNPJEntity>> GetCnpj(GetCnpj cnpj);
        Task<List<CNPJEntity>> Gets(string id);
    }
}
