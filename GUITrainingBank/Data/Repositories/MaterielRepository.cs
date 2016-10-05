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
    public class MaterielRepository:RepositoryBase<materiel> , IMaterielRepository
    {
        public MaterielRepository(IDatabaseFactory dbFactory) : base(dbFactory)
        {

        }
    }
    public interface IMaterielRepository : IRepository<materiel>
    {

    }
}
