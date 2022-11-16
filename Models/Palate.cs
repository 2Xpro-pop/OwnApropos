using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OwnApropos.Models
{
    public class Palate: IIdPickable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Seats { get; set; }
        public int FillialId { get; set; }
        public virtual Fillial Fillial { get; set; }

        [IgnoreDataMember]
        public string Description => Name;
    }
}
