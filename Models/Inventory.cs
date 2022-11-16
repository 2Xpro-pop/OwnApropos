using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnApropos.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int FillialId { get; set; } 
        public Fillial Fillial { get; set; } = null!;
    }
}
