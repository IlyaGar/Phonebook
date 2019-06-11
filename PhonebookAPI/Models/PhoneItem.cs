using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhonebookAPI.Models
{
    public class PhoneItem
    {
        public int Id { get; set; }
        public string Place { get; set; }
        public string Post { get; set; }
        public string Department { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Nomer { get; set; }
        public string Email { get; set; }
        public int? IsDeleted { get; set; }
    }
}
