using AppCore.Entities;
using AppCore.Services;
using AppCore.ViewModel.User;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/CNPJ")]
    [ApiController]
    public class CNPJController : Controller
    {
        private readonly ICnpjService2 cnpjService;
        private readonly IMapper _mapper;

        public CNPJController(ICnpjService2 _cnpjService, IMapper mapper)
        {
            cnpjService = _cnpjService;
            _mapper = mapper;
        }


        [HttpPost]
        [Route("GET")]
        public async Task<ActionResult<dynamic>> Get([FromBody] GetCnpj cnpj)
        {
            var resp = await cnpjService.GetCnpj(cnpj);

            // Verifica se o usuário existe
            if (resp.Value == null)
                return NotFound(resp.Message);

            resp.Value.id_user = cnpj.Id;

            var ret = _mapper.Map<Cnpjmin>(resp.Value);

            return new
            {
                cnps = ret

            };
        }

        [HttpPost]
        [Route("INSERT")]
        public async Task<ActionResult<dynamic>> Save([FromBody] GetCnpj cnpj)
        {
            var resp = await cnpjService.GetCnpj(cnpj);

            // Verifica se o usuário existe
            if (resp.Value == null)
                return NotFound(resp.Message);

            resp.Value.id_user = cnpj.Id;

            var creat = await cnpjService.InsertAsync(resp.Value);

            if (creat.Value == null)
                return NotFound(creat.Message);

            return Ok();
        }

        [HttpPost]
        [Route("POST")]
        public async Task<ActionResult<dynamic>> FindCnpj([FromBody] GetCnpj cnpj)
        {
            var resp = await cnpjService.Gets(cnpj.Id);

            // Verifica se o usuário existe
            if (resp == null)
                return NotFound(new { message = "Usuários não localizados" });


            return new
            {
                cnps =  _mapper.Map<List<Cnpjmin>>(resp) 
                
            };
        }
    }
}
