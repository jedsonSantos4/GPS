using AppCore.Entities;
using AppCore.Helpers;
using AppCore.Interface.Repositores;
using AppCore.Interface.Services;
using AppCore.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Services
{
    public class CnpjService : ICnpjService2
    {
        private readonly ICnpjRepository cnpjService;
        public CnpjService(ICnpjRepository _cnpj)
        {
            cnpjService = _cnpj;
        }

        public async Task<ValidResult<CNPJEntity>> GetCnpj(GetCnpj cnpj)
        {
            return await cnpjService.GetCnpj(cnpj);

        }

        public Task<ValidResult<bool>> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CNPJEntity>> Gets(string id)
        {

            var list = await  GetAll();

            return list.Value.Where(c => c.id_user.Equals(id)).ToList();
        }

        public async Task<ValidResult<List<CNPJEntity>>> GetAll()
        {
            var result = new ValidResult<List<CNPJEntity>>();
            try
            {
                result.Value = (List<CNPJEntity>)await cnpjService.GeAll();
                result.Status = true;
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
        }

        public async Task<ValidResult<bool>> InsertAsync(CNPJEntity obj)
        {
            var result = new ValidResult<bool>();
            try
            {
                await cnpjService.InsertAsync(obj);
                result.Status = true;
                result.Value = true;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Value = false;
                result.Message = ex.Message;
                
            }

            return result;


        }

        public Task<ValidResult<bool>> UpdateAsync(CNPJEntity obj)
        {
            throw new NotImplementedException();
        }

        Task<CNPJEntity> IBaseService<CNPJEntity>.Get(string id)
        {
            throw new NotImplementedException();
        }
    }
}
