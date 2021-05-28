using Nancy.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using web.Models;
using Web.Model.Models;
using WebModel.Interface.Repos;

namespace WebAcess
{
    public class LogarAcess : ILogarRepo
    {
        private static HttpClient Client_Logar;
        private static HttpClient Client_CastroLogin;
        private static HttpClient Client_getCnpj;
        private static HttpClient Client_getCnpjs;
        private static HttpClient Client_saveCnpjs;
        public async Task<LogadoModel> Logar(LogarModel use)
        {
            var lParam = "{\"email\":\"" + use.User + "\",\"password\":\"" + use.Password + "\"}";

            var result = await AsyncPostlogin("http://jedsonsantos-001-site1.itempurl.com/api/User/auth", lParam);
            var resultContent = result.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<LogadoModel>(resultContent);            
        }

        public async Task<HttpResponseMessage> AsyncPostlogin(string pUrl, string pParam)
        {
            var lPost = new StringContent(pParam, Encoding.UTF8, "application/json");
            
            if (Client_Logar == null)
            {
                Client_Logar = new HttpClient
                {
                    BaseAddress = new Uri(pUrl),
                    Timeout = TimeSpan.FromMilliseconds(30000),
                };
                Client_Logar.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));                
            }
            try
            {
                var resp = new HttpResponseMessage();
                var controleServ = true;
                var tentativa = 0;

                while (controleServ)
                {
                    resp = await Client_Logar.PostAsync($"{Client_Logar.BaseAddress}", lPost);
                    var lErro = resp.Content.ReadAsStringAsync().Result;

                    if (tentativa >= 5)
                    {
                        controleServ = false;
                    }

                    if (resp.StatusCode != HttpStatusCode.OK || lErro.ToLower().Contains("error"))
                    {
                        Thread.Sleep(500);
                        tentativa++;
                        var msg = string.Format(lErro.ToLower(), ((int)resp.StatusCode), pUrl, pParam);
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
        public async Task<HttpResponseMessage> AsyncPostInsert(string pUrl, string pParam)
        {
            var lPost = new StringContent(pParam, Encoding.UTF8, "application/json");

            if (Client_CastroLogin == null)
            {
                Client_CastroLogin = new HttpClient
                {
                    BaseAddress = new Uri(pUrl),
                    Timeout = TimeSpan.FromMilliseconds(30000),
                };
                Client_CastroLogin.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
            try
            {
                var resp = new HttpResponseMessage();
                var controleServ = true;
                var tentativa = 0;

                while (controleServ)
                {
                    resp = await Client_CastroLogin.PostAsync($"{Client_CastroLogin.BaseAddress}", lPost);
                    var lErro = resp.Content.ReadAsStringAsync().Result;

                    if (tentativa >= 5)
                    {
                        controleServ = false;
                    }

                    if (resp.StatusCode != HttpStatusCode.OK || lErro.ToLower().Contains("error"))
                    {
                        Thread.Sleep(500);
                        tentativa++;
                        var msg = string.Format(lErro.ToLower(), ((int)resp.StatusCode), pUrl, pParam);
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
        public async Task<HttpResponseMessage> AsyncPostGetCnpj(string pUrl, string pParam)
        {
            var lPost = new StringContent(pParam, Encoding.UTF8, "application/json");

            if (Client_getCnpj == null)
            {
                Client_getCnpj = new HttpClient
                {
                    BaseAddress = new Uri(pUrl),
                    Timeout = TimeSpan.FromMilliseconds(30000),
                };
                Client_getCnpj.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
            try
            {
                var resp = new HttpResponseMessage();
                var controleServ = true;
                var tentativa = 0;

                while (controleServ)
                {
                    resp = await Client_getCnpj.PostAsync($"{Client_getCnpj.BaseAddress}", lPost);
                    var lErro = resp.Content.ReadAsStringAsync().Result;

                    if (tentativa >= 5)
                    {
                        controleServ = false;
                    }

                    if (resp.StatusCode != HttpStatusCode.OK || lErro.ToLower().Contains("error"))
                    {
                        Thread.Sleep(500);
                        tentativa++;
                        var msg = string.Format(lErro.ToLower(), ((int)resp.StatusCode), pUrl, pParam);
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
        public async Task<HttpResponseMessage> AsyncPostGetCnpjs(string pUrl, string pParam)
        {
            var lPost = new StringContent(pParam, Encoding.UTF8, "application/json");

            if (Client_getCnpjs == null)
            {
                Client_getCnpjs = new HttpClient
                {
                    BaseAddress = new Uri(pUrl),
                    Timeout = TimeSpan.FromMilliseconds(30000),
                };
                Client_getCnpjs.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
            try
            {
                var resp = new HttpResponseMessage();
                var controleServ = true;
                var tentativa = 0;

                while (controleServ)
                {
                    resp = await Client_getCnpjs.PostAsync($"{Client_getCnpjs.BaseAddress}", lPost);
                    var lErro = resp.Content.ReadAsStringAsync().Result;

                    if (tentativa >= 5)
                    {
                        controleServ = false;
                    }

                    if (resp.StatusCode != HttpStatusCode.OK || lErro.ToLower().Contains("error"))
                    {
                        Thread.Sleep(500);
                        tentativa++;
                        var msg = string.Format(lErro.ToLower(), ((int)resp.StatusCode), pUrl, pParam);
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
        public async Task<HttpResponseMessage> AsyncPostSaveCnpjs(string pUrl, string pParam)
        {
            var lPost = new StringContent(pParam, Encoding.UTF8, "application/json");

            if (Client_saveCnpjs == null)
            {
                Client_saveCnpjs = new HttpClient
                {
                    BaseAddress = new Uri(pUrl),
                    Timeout = TimeSpan.FromMilliseconds(30000),
                };
                Client_saveCnpjs.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
            try
            {
                var resp = new HttpResponseMessage();
                var controleServ = true;
                var tentativa = 0;

                while (controleServ)
                {
                    resp = await Client_saveCnpjs.PostAsync($"{Client_saveCnpjs.BaseAddress}", lPost);
                    var lErro = resp.Content.ReadAsStringAsync().Result;

                    if (tentativa >= 5)
                    {
                        controleServ = false;
                    }

                    if (resp.StatusCode != HttpStatusCode.OK || lErro.ToLower().Contains("error"))
                    {
                        Thread.Sleep(500);
                        tentativa++;
                        var msg = string.Format(lErro.ToLower(), ((int)resp.StatusCode), pUrl, pParam);
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



        public async Task<string> Casdastro(Register use)
        {
            var lParam = "{\"email\":\"" + use.Email + "\",\"password\":\"" + use.Password + "\",\"nome\":\"" + use.Nome + "\"}";

            var result = await AsyncPostInsert("http://jedsonsantos-001-site1.itempurl.com/api/User/insert", lParam);
            return result.Content.ReadAsStringAsync().Result;

         
        }

        public async Task<CnpjModel> GetCnpj(LogadoModel use, string cnpj)
        {
            var lParam = "{\"id\":\"" + use.user.id + "\",\"cnpj\":\"" + cnpj + "\"}";

            var result = await AsyncPostGetCnpj("http://jedsonsantos-001-site1.itempurl.com/api/CNPJ/GET", lParam);
            var resultContent = result.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<CnpjModel>(resultContent);
        }

        public async Task<CnpjzModel> GetCnpj(LogadoModel use)
        {
            var lParam = "{\"id\":\"" + use.user.id + "\",\"cnpj\":\"\"}";

            var result = await AsyncPostGetCnpjs("http://jedsonsantos-001-site1.itempurl.com/api/CNPJ/POST", lParam);
            var resultContent = result.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject< CnpjzModel > (resultContent);
        }

        public async Task<bool> SaveCnpj(LogadoModel use, string cnpj)
        {
            var lParam = "{\"id\":\"" + use.user.id + "\",\"cnpj\":\"" + cnpj + "\"}";

            var result = await AsyncPostSaveCnpjs("http://jedsonsantos-001-site1.itempurl.com/api/CNPJ/INSERT", lParam);
            var resultContent = result.Content.ReadAsStringAsync().Result;
            if (string.IsNullOrEmpty(resultContent))
            {
                return true;
            }
            return false;
        }


       private IEnumerable<CnpjModel> ReadMessage(HttpResponseMessage response)
        {
            var elaboracoes = new List<CnpjModel>();
            try
            {
                var JsTool2 = new JavaScriptSerializer();
                var resultadoJson = response.Content.ReadAsStringAsync();
                var jsonResult = resultadoJson.Result;

                var objJason = JArray.Parse(jsonResult);
                foreach (var item in objJason)
                {
                    /*Retorna apenas valores validos*/
                    try
                    {
                        var elab = JsonConvert.DeserializeObject<CnpjModel>(item.ToString());
                        elaboracoes.Add(elab);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
                return elaboracoes;
            }
            catch (Exception)
            {
                return elaboracoes;
            }
        }
    }
}
