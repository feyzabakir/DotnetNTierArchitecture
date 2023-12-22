using DotnetNTierArchitecture.Core.Models;
using DotnetNTierArchitecture.Core.Repositories;
using DotnetNTierArchitecture.Core.Services;
using DotnetNTierArchitecture.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetNTierArchitecture.Service.Services
{
    public class UserService : Service<User>, IUserService
    {
        public UserService(IGenericRepository<User> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
