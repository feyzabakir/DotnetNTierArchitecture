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
    public class UserProfileService : Service<UserProfile>, IUserProfileService
    {
        public UserProfileService(IGenericRepository<UserProfile> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
