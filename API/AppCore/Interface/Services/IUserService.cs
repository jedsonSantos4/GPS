using AppCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppCore.Interface.Services
{
    public interface IUserService : IBaseService<UserEntity>
    {
        Task<ValidResult<UserEntity>> Auth(string nome, string password);      
    }
}
