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
        }

        [HttpGet, Route("createevent")]
        public IActionResult CreateEvent()
        {
            return View();
        }
        [HttpPost, Route("createevent")]
        public IActionResult CreateEvent(CreateEventViewModel e)
        {
            e.Group = _db.Groups.Find(e.GroupID);
            _db.Events.Add(e);
            _db.SaveChanges();
            var g = _db.Groups.Find(e.GroupID);
            return RedirectToAction("ViewGroup", g);
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
        public IActionResult ViewEvent(long id)
        {
            var e = new Event
            {
                EventName = "Event Name", Description="Event Description", Time=DateTime.Now, Location="EventLocation", Group=new Group { GroupName="Group Name"}
            };
            return View(e);
        }
        [Route("ViewEvent")]
        public IActionResult ViewEvent(Event e)
        {
            return View(e);
          }
        [Route("Test")]
        public IActionResult Test()
        {
            Debug.WriteLine("###########################");
            foreach (var gr in _db.Groups)
            {
                Debug.WriteLine(gr.GroupName);
                foreach (var e in gr.Events)
                {
                    Debug.WriteLine('\t' + e.EventName);
                }
            }
            return View("Index",_db.Groups);
        }

    [Route("ViewGroup/{id:min(0)}")]
        public IActionResult ViewGroup(long id)
        {
            var g = _db.Groups.Find(id);
            _db.Entry(g).Collection(x => x.Events).Load();
            return View(g);
        }
        [Route("ViewGroup")]
        public IActionResult ViewGroup(Group g)
        {
            _db.Entry(g).Collection(x => x.Events).Load();
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


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

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