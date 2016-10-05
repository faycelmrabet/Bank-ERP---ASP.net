using Data.Infrastructure;
using Data.Interfaces;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
   public class OffreRepository : RepositoryBase<offre> , IOffreRepository
    {
        public OffreRepository(IDatabaseFactory dbFactory) : base(dbFactory)
        {

        }



    }

    public interface IOffreRepository : IRepository<offre>
    {

    }
}
