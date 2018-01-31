using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCWebApp.Models
{
    [Table("Player")]
    public class Player
    {
        public int Id { get; set; }
        public int Score { get; set; }
    }
}