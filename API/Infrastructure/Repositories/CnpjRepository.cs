using AppCore.Entities;
using AppCore.Interface.Repositores;
using AppCore.ViewModel.User;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CnpjRepository : BaseRepository<CNPJEntity>, ICnpjRepository
    {
        public CnpjRepository(IMongoClient mongoClient,
        IClientSessionHandle clientSessionHandle)
        : base(mongoClient, clientSessionHandle, "cnpj")
        {
        }

     

        private static HttpClient Client_Cnpj;
        public  async Task<ValidResult<CNPJEntity>> GetCnpj(GetCnpj cnpj)
        {
            var valid = new ValidResult<CNPJEntity>();
            try
            {
                string pattern = @"(?i)[^0-9a-záéíóúàèìòùâêîôûãõç\s]";
                Regex rgx = new Regex(pattern);
                 rgx.Replace(cnpj.cnpj, "");
                var result = await AsyncGetCnpj(rgx.Replace(cnpj.cnpj, ""));
                valid.Value = JsonConvert.DeserializeObject<CNPJEntity>(result.Content.ReadAsStringAsync().Result);
                valid.Status = true;
            }
            catch (Exception ex)
            {
                valid.Message = ex.Message;
            }
            return valid;
        }

        public async Task<HttpResponseMessage> AsyncGetCnpj(string pUrl)
        {
            //var lPost = new StringContent(pParam, Encoding.UTF8, "application/json");

            if (Client_Cnpj == null)
            {
                Client_Cnpj = new HttpClient
                {
                    BaseAddress = new Uri("https://www.receitaws.com.br/v1/cnpj/"),
                    Timeout = TimeSpan.FromMilliseconds(30000),
                };
                Client_Cnpj.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Client_Cnpj.DefaultRequestHeaders.Add("Authorization", $"Bearer {_Servico.Token()}");
            }
            try
            {
                var resp = new HttpResponseMessage();
                var controleServ = true;
                var tentativa = 0;

                while (controleServ)
                {
                    resp = await Client_Cnpj.GetAsync($"{Client_Cnpj.BaseAddress}{pUrl}");

                    var lErro = resp.Content.ReadAsStringAsync().Result;

                    if (tentativa >= 5)
                    {
                        controleServ = false;
                    }

                    if (resp.StatusCode != HttpStatusCode.OK || lErro.ToLower().Contains("error"))
                    {   
                        tentativa++;
                        var msg = string.Format("Erro ao tentar localizar o CNPJ verifique se o mesmo esta correto", ((int)resp.StatusCode), pUrl,"");
                        throw new ArgumentException(msg);
                    }
                    else
                    {
                        controleServ = false;
                    }
                }
                return resp;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

    }
}
