using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ScoresWebsite.Models
{
    public class mvcappdb:DbContext
    {
        public DbSet<Player> Players { get; set; }
    }
}