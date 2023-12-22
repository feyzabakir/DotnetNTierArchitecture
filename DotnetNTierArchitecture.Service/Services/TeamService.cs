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
    public class TeamService : Service<Team>, ITeamService
    {
        public TeamService(IGenericRepository<Team> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
