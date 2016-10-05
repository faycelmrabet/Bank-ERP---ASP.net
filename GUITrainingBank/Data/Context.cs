using Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Context : IdentityDbContext<User>
    {
        public Context()
            : base("banquematacheContext")
        {
        }

        public static Context Create()
        {
            return new Context();
        }
    }
}
