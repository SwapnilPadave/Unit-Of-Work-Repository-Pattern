using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UOW_Models;
using UOW_Models.Models;
using UOW_Repository.Infrastructure;

namespace UOW_Repository.Repositories
{
    public class UserRepository:Repository<User>,IUserRepository
    {
        public UserRepository(
            ApplicationDBContext context,
            ILogger logger
            ):base(context,logger)
        {

        }

        public override async Task<IEnumerable<User>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "{Repo} All Method Error", typeof(UserRepository));
                return new List<User>();
            }
        }
        public override async Task<bool> Update(User entity)
        {
            try
            {
                var existingUser = await dbSet.Where(x => x.ID == entity.ID).FirstOrDefaultAsync();
                if (existingUser == null)
                    return await Add(entity);
                existingUser.FirstName = entity.FirstName;
                existingUser.LastName = entity.LastName;
                existingUser.Email = entity.Email;
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All Method Error", typeof(UserRepository));
                return false;
            }
        }
        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                var exist = await dbSet.Where(x => x.ID == id).FirstOrDefaultAsync();
                if (exist != null)
                {
                    dbSet.Remove(exist);
                    return true;
                }
                else
                {
                    return false;
                }           
               
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All Method Error", typeof(UserRepository));
                return false;
            }
        }
    }
}
