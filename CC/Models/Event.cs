using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Models
{
    public class Event
    {
        public long Id { get; set; }
        public String EventName { get; set; }
        public String Description { get; set; }
        public DateTime Time { get; set; }
        public String Location { get; set; }
        public virtual Group Group { get; set; }
    }
    [NotMapped]
    public class CreateEventViewModel : Event
    {
        public long? GroupID { get; set; }
    }
}
