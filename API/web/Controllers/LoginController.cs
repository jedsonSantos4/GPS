
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using web.Models;
using Web.Model.Interface.Service;
using Web.Model.Models;

namespace web.Controllers
{
    public class LoginController : Controller
    {

        private readonly ILogarServ logarServ;
        

        public LoginController(ILogarServ _logarServ )
        {
            logarServ = _logarServ;
            
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> Logar(string user)
        {
            var usuario = JsonConvert.DeserializeObject<LogarModel>(user);

            try
            {
                var log = await logarServ.Logar(usuario);
                HttpContext.Session.SetString("SessioLogado", JsonConvert.SerializeObject(log));

                var userInfo = JsonConvert.DeserializeObject<LogadoModel>
                 (HttpContext.Session.GetString("SessioLogado"));              

                return Json(log);
            }
            catch (Exception)
            {
                return Json("Error");                
            }           
        }

        public async Task<JsonResult> Cadastar(string user)
        {
            var usuario = JsonConvert.DeserializeObject<Register>(user);
           
            try
            {
                var teste = await logarServ.Casdastro(usuario);

                if (teste.Contains("Erro:"))
                {
                    return Json(false);
                }
                return Json(true);

            }
            catch (Exception)
            {
                return Json(false);
            }
        }

        public async Task<JsonResult> ConsultaCpnjs(LogadoModel user, string cnpj)
        {
            try
            {
                var resul = await logarServ.GetCnpj(user, cnpj);
                if (resul == null)
                {
                    return Json("Error");

                }

                return Json(resul.cnps);
            }
            catch (Exception)
            {
                return Json("Error");
            }
            
        }

        public async Task<JsonResult> ConsultaCpnjsSave(LogadoModel user)
        {
            var resul = await logarServ.GetCnpj(user);
            return Json(resul);
        }

        public async Task<JsonResult> SaveCnpj(LogadoModel user, string cnpj)
        {
            var resul = await logarServ.SaveCnpj(user, cnpj);


            return Json(resul);
        }

    }
}
