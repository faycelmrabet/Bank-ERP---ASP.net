 

using  Data.Infrastructure;
using  Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Models;

namespace  Data.Repositories
{
    public class ContratRepository : RepositoryBase<contrat>, IContratRepository
    {
        public ContratRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }
    }
    public interface IContratRepository : IRepository<contrat>
    {

    }
}
