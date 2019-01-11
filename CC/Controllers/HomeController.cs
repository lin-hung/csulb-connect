using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CC.Models;

namespace CC.Controllers
{
    public class HomeController : Controller
    {
        private readonly GroupDataContext _db;

        public HomeController(GroupDataContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var groups = _db.Groups;
            return View(groups);
            //var groups = new List<Group>();
            //var e = new List<Event>();
            //e.Add(new Event
            //{
            //    EventName = "Event Name",
            //    Description = "Event Description",
            //    Time = DateTime.Now,
            //    Location = "EventLocation",
            //    Group = new Group { GroupName = "Group Name" }
            //});
            //e.Add(new Event
            //{
            //    EventName = "Event 2",
            //    Description = "Event Description 2",
            //    Time = DateTime.Now,
            //    Location = "EventLocation 2",
            //    Group = new Group { GroupName = "Group Name" }
            //});
            //var g = new Group
            //{
            //    Id = 1,
            //    GroupName = "Group #1",
            //    Description = "Group Description",
            //    Events = e
            //};
            //var g2 = new Group
            //{
            //    Id = 2,
            //    GroupName = "Group #2",
            //    Description = "Group Description 2",
            //    Events = e
            //};
            //groups.Add(g);
            //groups.Add(g2);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        [HttpGet, Route("createevent")]
        public IActionResult CreateEvent()
        {
            return View();
        }
        [HttpPost, Route("createevent")]
        public IActionResult CreateEvent(CreateEventViewModel e)
        {
            Event _e = (Event)e;
            _e.Group = _db.Groups.Where(x => x.Id == e.GroupID).FirstOrDefault();
            _db.Events.Add(_e);
            _db.SaveChanges();
            return View();
        }
        [HttpGet, Route("createeventtest")]
        public IActionResult CreateEventTest()
        {
            return View();
        }
        [HttpPost, Route("createeventtest")]
        public IActionResult CreateEventTest(Event e)
        {
            _db.Events.Add(e);
            _db.SaveChanges();
            return View();
        }
        [HttpGet, Route("creategroup")]
        public IActionResult CreateGroup()
        {
            return View();
        }
        [HttpPost, Route("creategroup")]
        public IActionResult CreateGroup(Group group)
        {
            _db.Groups.Add(group);
            _db.SaveChanges();
            return View();
        }
        [Route("ViewEvent/{id:min(0)}")]
        public IActionResult ViewEvent(int id)
        {
            var e = new Event
            {
                EventName = "Event Name", Description="Event Description", Time=DateTime.Now, Location="EventLocation", Group=new Group { GroupName="Group Name"}
            };
            return View(e);
        }
        [Route("ViewGroup/{id:min(0)}")]
        public IActionResult ViewGroup(int id)
        {
            var g = _db.Groups.Where(x => x.Id == id).FirstOrDefault();
            
            //var e = new List<Event>();
            //e.Add(new Event
            //{
            //    EventName = "Event Name",
            //    Description = "Event Description",
            //    Time = DateTime.Now,
            //    Location = "EventLocation",
            //    Group = new Group { GroupName = "Group Name" }
            //});
            //e.Add(new Event
            //{
            //    EventName = "Event 2",
            //    Description = "Event Description 2",
            //    Time = DateTime.Now,
            //    Location = "EventLocation 2",
            //    Group = new Group { GroupName = "Group Name" }
            //});
            //var g = new Group
            //{
            //    Id = id, GroupName="Group #"+id, Description="Group Description",
            //    Events=e
            //};
            return View(g);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
