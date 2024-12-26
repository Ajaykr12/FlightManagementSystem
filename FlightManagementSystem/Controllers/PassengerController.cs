using Microsoft.AspNetCore.Mvc;
using FlightManagementSystem.Data;
using FlightManagementSystem.Models;
using System.Linq;
using FlightManagementSystem.DTO;
using Microsoft.AspNetCore.Authorization;

namespace FlightManagementSystem.Controllers
{
    public class PassengerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PassengerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // This action is ued to view Passenger List by Admin
        [Authorize("Admin")]
        public IActionResult Index()
        {
            var passengers = _context.Passengers.ToList();
            return View(passengers);
        }

        // This action is used to view Passenger List by User
        [Authorize("User")]
        public IActionResult UserIndex(int id)
        {
            var flight = _context.Flights.Where(f => f.Id == id).FirstOrDefault();
            ViewBag.flightName = flight?.Name;
                ViewBag.flightId = flight?.Id;
            var passengers = _context.Passengers.ToList();
            return View(passengers);
        }

        
        public IActionResult Create([FromQuery] int flightid)
        {
           /* var idParam = HttpContext.Request.QueryString["flightid"];
            int flightId = int.Parse(idParam);*/
            ViewBag.flightId = flightid;
            return View();
        }


        // This action is used to create Passenger
        [Authorize]
        [HttpPost]
        public IActionResult Create(PassengerDTO passengerdto)
        {
            if (passengerdto != null)
            {
                Passenger passenger = new Passenger()
                {
                    Name = passengerdto.Name,
                    Address = passengerdto.Address,
                    IdentificationType = passengerdto.IdentificationType,
                    IdentificationNumber = passengerdto.IdentificationNumber,
                };
                _context.Passengers.Add(passenger);
                _context.SaveChanges();
                 return RedirectToAction("UserIndex", new { id = passengerdto.FlightId });
            }
            return View(passengerdto);
        }

        // This action is used to edit the Passenger details
        public IActionResult Edit(int id, int flightid)
        {
            var passenger = _context.Passengers.Find(id);
            if (passenger == null)
            {
                return NotFound();
            }
            PassengerDTO passengerDTO = new PassengerDTO() { 
                Id = passenger.Id,
                Name = passenger.Name,
                Address = passenger.Address,
                IdentificationType = passenger.IdentificationType,
                IdentificationNumber = passenger.IdentificationNumber,
                FlightId = flightid
            };
            ViewBag.flightId = flightid;
            return View(passengerDTO);
        }

        // This action is used to edit the Passenger details
        [HttpPost]
        public IActionResult Edit(PassengerDTO passengerdto)
        {
            if (passengerdto != null)
            {
                var passenger = _context.Passengers.Find(passengerdto.Id);
                passenger.Name = passengerdto.Name;
                passenger.Address = passengerdto.Address;
                passenger.IdentificationType = passengerdto.IdentificationType;
                passenger.IdentificationNumber = passengerdto.IdentificationNumber;
                _context.Passengers.Update(passenger);
                _context.SaveChanges();
                return RedirectToAction("UserIndex", new { id = passengerdto.FlightId });
            }
            return View(passengerdto);
        }

        public IActionResult Delete(int id, int flightid)
        {
            var passenger = _context.Passengers.Find(id);
            if (passenger != null)
            {
                _context.Passengers.Remove(passenger);
                _context.SaveChanges();
            }
            if (User.FindFirst(claim => claim.Type == System.Security.Claims.ClaimTypes.Role)?.Value == "Admin")
            {
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("UserIndex", new { id = flightid });
        }

        public IActionResult Details(int id, int flightid)
        {
            var passenger = _context.Passengers.Find(id);
            if (passenger == null)
            {
                return NotFound();
            }
            ViewBag.flightId = flightid;
            return View(passenger);
        }
    }
}