using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCWebApp.Models
{
    public class PlayerContext : DbContext
    {
        public DbSet<Player> players { get; set; }
    }
}