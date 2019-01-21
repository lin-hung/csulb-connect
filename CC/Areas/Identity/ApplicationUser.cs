using CC.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Areas.Identity
{
    public class ApplicationUser:IdentityUser
    {
        public virtual ICollection<GroupUser> Groups { get; set; }
        public virtual ICollection<EventUser> Events { get; set; }
    }

    public enum Role { Creator, Member };

    //for in-between classes groupuser and eventuser, set composite key inside
    //data context- ef doesn't support annotated composite keys
    //ids exposed because conflict in name ID
    public class GroupUser
    {
        public Group Group { get; set; }
        public ApplicationUser User { get; set; }
        public Role UserRole { get; set; }
        public long _gId;
        public string _uId;
        public long GroupId { get { return _gId; } set { _gId = this.Group.Id; } }
        public string UserId { get { return _uId; } set { _uId = this.User.Id; } }
    }
    public class EventUser
    {
        public Event Event { get; set; }
        public ApplicationUser User { get; set; }
        public Role UserRole { get; set; }
        public long _eId;
        public string _uId;
        public long EventId { get { return _eId; } set {_eId= this.Event.Id; } }
        public string UserId { get { return _uId; } set { _uId = this.User.Id; } }
    }
}
