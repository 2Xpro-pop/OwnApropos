using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnApropos.Models
{
    public class BudgetHistory: IIdPickable
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public double Action { get; set; }

        public int FillialId { get; set; }
        public Fillial Fillial { get; set; } = null!;
    }
}
