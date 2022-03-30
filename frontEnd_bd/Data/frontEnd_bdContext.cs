using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using apiRest_bd.Data.ModelsViews;

namespace frontEnd_bd.Data
{
    public class frontEnd_bdContext : DbContext
    {
        public frontEnd_bdContext (DbContextOptions<frontEnd_bdContext> options)
            : base(options)
        {
        }

        public DbSet<apiRest_bd.Data.ModelsViews.IngressoDTOList> IngressoDTOList { get; set; }
    }
}
