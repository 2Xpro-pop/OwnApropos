using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnApropos.Models
{
    public class Pacient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool HasPalate { get; set; }

        public int PersonalId { get; set; }
        public int? PalateId { get; set; } 

        public virtual Personal Personal { get; set; }
        public virtual Palate? Palate { get; set; }
    }
}
