using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CSharpExam.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace CSharpExam.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;

        // here we can "inject" our context service into the constructor
        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost("register")]
        public IActionResult TryRegister(IndexViewModel modelData)
        {
            User regUser = modelData.RegUser;
            if(ModelState.IsValid)
            {
                if(dbContext.Users.Any(u => u.Email == regUser.Email))
                {
                    ModelState.AddModelError("RegUser.Email", "Email already in use!");
                }
                else
                {
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    regUser.Password = Hasher.HashPassword(regUser, regUser.Password);
                    dbContext.Add(regUser);
                    dbContext.SaveChanges();
                    User currUser = dbContext.Users.FirstOrDefault(u => u.Email == regUser.Email);
                    HttpContext.Session.SetInt32("userId", regUser.UserId);
                    return RedirectToAction("Home");
                }
            }
            return View("Index", modelData);
        }

        [HttpPost("login")]
        public IActionResult TryLogin(IndexViewModel modelData)
        {
            LoginUser logUser = modelData.LogUser;
            if(ModelState.IsValid)
            {
                var userInDb = dbContext.Users.FirstOrDefault(u => u.Email == logUser.Email);

                if (userInDb == null)
                {
                    ModelState.AddModelError("LogUser.Email", "Invalid Email/Password");
                }
                else
                {
                    var hasher = new PasswordHasher<LoginUser>();
                    var result = hasher.VerifyHashedPassword(logUser, userInDb.Password, logUser.Password);

                    if (result == 0)
                    {
                        ModelState.AddModelError("LogUser.Email", "Invalid Email/Password");
                    }
                    else
                    {
                        HttpContext.Session.SetInt32("userId", userInDb.UserId);
                        return RedirectToAction("Home");
                    }
                }
            }
            return View("Index", modelData);
        }

        [HttpGet("Home")]
        public IActionResult Home()
        {
            if (HttpContext.Session.GetInt32("userId") == null)
            {
                return RedirectToAction("Index");
            }

            User thisUser = dbContext.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("userId"));
            ViewBag.ThisUser = thisUser;

            List<Actvty> EveryActivity = dbContext.Activities
                .Include(w => w.ActivityAttendees)
                .ThenInclude(a => a.User)
                .OrderBy(ea => ea.ActivityDate)
                .ToList();

            foreach (Actvty a in EveryActivity.ToList())
            {
                if (a.ActivityDate < DateTime.Now)
                {
                    EveryActivity.Remove(a);
                }
            }
            ViewBag.AllActivities = EveryActivity;

            List<User> userCreators = dbContext.Users.ToList();
            ViewBag.Creators = userCreators;

            return View("Home");
        }

        [HttpGet("delete/{actId}")]
        public IActionResult DeleteActivity(int actId)
        {
            Actvty actToDelete = dbContext.Activities.FirstOrDefault(w => w.ActivityId == actId);
            dbContext.Activities.Remove(actToDelete);
            dbContext.SaveChanges();
            return RedirectToAction("Home");
        }

        [HttpGet("join/{actId}")]
        public IActionResult YesActivity(int actId)
        {
            Actvty thisActivity = dbContext.Activities.FirstOrDefault(a => a.ActivityId == actId);
            User usersActivities = dbContext.Users
                .Include(a => a.AttendedActs)
                .ThenInclude(e => e.Activity)
                .ToList().FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("userId"));
            
            bool canAttend = true;
            foreach (var a in usersActivities.AttendedActs)
            {
                if (a.Activity.ActivityDate.Date == thisActivity.ActivityDate.Date)
                {
                    canAttend = false;
                    Console.WriteLine("This user cannot attend activity: "+thisActivity.Title);
                }
            }

            if (canAttend)
            {
                Participation participation = new Participation();
                participation.UserId = (int)HttpContext.Session.GetInt32("userId");
                participation.ActivityId = actId;
                dbContext.Participations.Add(participation);
                dbContext.SaveChanges();
            }

            return RedirectToAction("Home");
        }

        [HttpGet("leave/{partId}")]
        public IActionResult NoActivity(int partId)
        {
            Participation participation = dbContext.Participations.FirstOrDefault(a => a.ParticipationId == partId);
            dbContext.Participations.Remove(participation);
            dbContext.SaveChanges();
            return RedirectToAction("Home");
        }

        [HttpGet("New")]
        public IActionResult NewActivity()
        {
            if (HttpContext.Session.GetInt32("userId") == null)
            {
                return RedirectToAction("Index");
            }
            return View("NewActivity");
        }

        [HttpPost("CreateActivity")]
        public IActionResult CreateActivity(Actvty newActivity)
        {
            if(ModelState.IsValid)
            {
                newActivity.PlannerId = (int)HttpContext.Session.GetInt32("userId");
                dbContext.Add(newActivity);
                dbContext.SaveChanges();
                Actvty thisActivity = dbContext.Activities.OrderByDescending(w => w.CreatedAt).FirstOrDefault();
                return Redirect("/activity/"+thisActivity.ActivityId);
            }
            return View("NewActivity", newActivity);
        }

        [HttpGet("activity/{actId}")]
        public IActionResult WeddInfo(int actId)
        {
            if (HttpContext.Session.GetInt32("userId") == null)
            {
                return RedirectToAction("Index");
            }

            User thisUser = dbContext.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("userId"));
            ViewBag.ThisUser = thisUser;

            Actvty thisActivity = dbContext.Activities.FirstOrDefault(w => w.ActivityId == actId);
            ViewBag.ThisActivity = thisActivity;

            User eventCoord = dbContext.Users.FirstOrDefault(ec => ec.UserId == thisActivity.PlannerId);
            ViewBag.EventCoordinator = eventCoord;

            var actParticipants = dbContext.Activities
                .Include(w => w.ActivityAttendees)
                .ThenInclude(u => u.User)
                .FirstOrDefault(w => w.ActivityId == actId);
            
            ViewBag.AllParticipants = actParticipants.ActivityAttendees;
            return View("ActivityInfo");
        }

        [HttpGet("logoff")]
        public IActionResult Logoff()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}