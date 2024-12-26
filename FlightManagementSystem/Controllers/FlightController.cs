using Microsoft.AspNetCore.Mvc;
using FlightManagementSystem.Data;
using FlightManagementSystem.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace FlightManagementSystem.Controllers
{
    public class FlightController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FlightController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles ="Admin")]
        public IActionResult Index()
        {
            var flights = _context.Flights.ToList();
            return View(flights);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(Flight flight)
        {
            if (ModelState.IsValid)
            {
                _context.Flights.Add(flight);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(flight);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var flight = _context.Flights.Find(id);
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight);
        }

        [HttpPost]
        public IActionResult Edit(Flight flight)
        {
            if (ModelState.IsValid)
            {
                _context.Flights.Update(flight);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(flight);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var flight = _context.Flights.Find(id);
            if (flight != null)
            {
                _context.Flights.Remove(flight);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "User")]
        public IActionResult UserIndex()
        {
            var flights = _context.Flights
                .Where(f => !f.IsCancelled && f.AvailableSeats > 0)
                .ToList();
            return View(flights);
        }

        [Authorize]
        public IActionResult Details(int id)
        {
            var flight = _context.Flights.Find(id);
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight);
        }
    }
}