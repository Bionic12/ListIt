using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListIt.Models
{
    public class Registry
    {
        public int Id { get; set; }

        public string IdUser { get; set; }
        public List<Chore> chores { get; set; }

    }
}