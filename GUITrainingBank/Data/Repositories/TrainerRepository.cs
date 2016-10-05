using Data.Infrastructure;
using Data.Interfaces;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class TrainerRepository: RepositoryBase<utilisateur> , ITrainerRepository
    {
        public TrainerRepository(IDatabaseFactory dbFactory) : base(dbFactory)
        {


        }
    }
    public interface ITrainerRepository : IRepository<utilisateur>
    {


    }
}
