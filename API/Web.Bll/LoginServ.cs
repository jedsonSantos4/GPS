using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using web.Models;
using Web.Model.Interface.Service;
using Web.Model.Models;
using WebModel.Interface.Repos;

namespace Web.Bll
{
    public class LoginServ : ILogarServ
    {
        private readonly ILogarRepo repo;
        public LoginServ(ILogarRepo logarRepo)
        {
            repo = logarRepo;
        }

        public async Task<string> Casdastro(Register use)
        {
            return await repo.Casdastro(use);
        }

        
        public async Task<CnpjModel> GetCnpj(LogadoModel use, string cnpj)
        {
            if (string.IsNullOrEmpty(cnpj))
            {
                return null;
            }
            string pattern = @"(?i)[^0-9a-záéíóúàèìòùâêîôûãõç\s]";
            Regex rgx = new Regex(pattern);
            cnpj = rgx.Replace(cnpj, "");
           

            return await repo.GetCnpj(use, cnpj);
        }



        public async Task<CnpjzModel> GetCnpj(LogadoModel use)
        {
            return await repo.GetCnpj(use);
        }

        public async Task<LogadoModel> Logar(LogarModel use)
        {
            return await repo.Logar(use);
        }

        public async Task<bool> SaveCnpj(LogadoModel use, string cnpj)
        {
            if (string.IsNullOrEmpty(cnpj))
            {
                return false;
            }
            string pattern = @"(?i)[^0-9a-záéíóúàèìòùâêîôûãõç\s]";
            Regex rgx = new Regex(pattern);
            cnpj = rgx.Replace(cnpj, "");
            return await repo.SaveCnpj(use, cnpj);
        }

       
    }
}
