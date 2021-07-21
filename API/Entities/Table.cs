using API.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Table
    {
        public int Id { get; set; }
        public bool? Available { get; set; }
        public AppUser reserved_to { get; set; }
        public string status { get; set; }
    }
}
