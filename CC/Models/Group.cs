using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Models
{
    public class Group
    {
        public long Id { get; set; }
        public String GroupName { get; set; }
        public String Description { get; set; }
        public string ImagePath { get; set; }
        public virtual List<Event> Events { get; set; }

        public Group()
        {
            Events = new List<Event>();
        }
    }
}
