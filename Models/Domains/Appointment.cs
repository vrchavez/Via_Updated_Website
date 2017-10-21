using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Domains
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
        public string Device { get; set; }
        public string Repair { get; set; }
        public int Total { get; set; }
    }
}
