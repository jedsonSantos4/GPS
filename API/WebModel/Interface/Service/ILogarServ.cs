using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web.Models;
using Web.Model.Models;

namespace Web.Model.Interface.Service
{
    public interface ILogarServ
    {
        Task<LogadoModel> Logar(LogarModel use);

        Task<string> Casdastro(Register use);

        Task<CnpjModel> GetCnpj(LogadoModel use, string cnpj);
        Task<CnpjzModel> GetCnpj(LogadoModel use);
        Task<bool> SaveCnpj(LogadoModel use, string cnpj);

    }
}
