using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhonebookAPI.Models
{
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nomer { get; set; }
        public string Address { get; set; }
        public int? IsDeleted { get; set; }
    }
}
