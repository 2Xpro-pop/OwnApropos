using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnApropos.Models
{
    public class Fillial: ReactiveObject, IIdPickable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Budget { get; set; }

        public string Description => Name;
    }
}
