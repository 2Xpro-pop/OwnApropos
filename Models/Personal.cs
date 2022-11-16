using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnApropos.Models
{
    public class Personal
    {
        public int Id { get; set; }
        public string Fio { get; set; }
        public double Salary { get; set; }
        public string TelefonNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int FillialId { get; set; }
        public Fillial Fillial { get; set; }
    }
}
