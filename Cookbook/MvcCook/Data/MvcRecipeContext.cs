using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcCook.Models;

namespace MvcRecipe.Data
{
    public class MvcRecipeContext : DbContext
    {
        public MvcRecipeContext (DbContextOptions<MvcRecipeContext> options)
            : base(options)
        {
        }

        public DbSet<MvcCook.Models.Recipe> Recipe { get; set; } = default!;
    }
}
