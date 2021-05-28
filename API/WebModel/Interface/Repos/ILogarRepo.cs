using System.Collections.Generic;
using System.Threading.Tasks;
using web.Models;
using Web.Model.Models;

namespace WebModel.Interface.Repos
{
    public interface ILogarRepo
    {
        Task<LogadoModel> Logar(LogarModel use);
        Task<string> Casdastro(Register use);

        Task<CnpjModel> GetCnpj(LogadoModel use, string cnpj);
        Task<CnpjzModel> GetCnpj(LogadoModel use);
        Task<bool> SaveCnpj(LogadoModel use, string cnpj);
    }
}
