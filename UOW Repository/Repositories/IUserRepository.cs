using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UOW_Models.Models;
using UOW_Repository.Infrastructure;

namespace UOW_Repository.Repositories
{
    public interface IUserRepository:IRepository<User>
    {        
    }
}
