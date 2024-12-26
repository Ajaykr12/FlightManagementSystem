using Microsoft.AspNetCore.Mvc;
using FlightManagementSystem.Data;
using FlightManagementSystem.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace FlightManagementSystem.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservationController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var reservations = _context.Reservations
                .Select(r => new
                {
                    r.Id,
                    r.ReservationDate,
                    r.JourneyDate,
                    r.PaymentMode,
                    r.Amount,
                    PassengerName = r.Passenger.Name,
                    FlightName = r.Flight.Name
                })
                .ToList();
            return View(reservations);
        }

        [Authorize(Roles = "User")]
        public IActionResult UserIndex(int Id)
        {
            string? UserId = User.FindFirst(claim => claim.Type == System.Security.Claims.ClaimTypes.Sid)?.Value;
            int userid = Convert.ToInt32(UserId);
            var reservations = _context.Reservations.Where(r => r.UserId == userid)
                .Select(r => new
                {
                    r.Id,
                    r.ReservationDate,
                    r.JourneyDate,
                    r.PaymentMode,
                    r.Amount,
                    r.IsCancelled,
                    PassengerName = r.Passenger.Name,
                    FlightName = r.Flight.Name
                })
                .ToList();
            return View(reservations);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            Reservation reservation = new Reservation();
            ViewBag.Flights = _context.Flights.Where(f => !f.IsCancelled).ToList();
            ViewBag.Passengers = _context.Passengers.ToList();
            return View(reservation);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(Reservation reservation)
        {
            ViewBag.Flights = _context.Flights.Where(f => !f.IsCancelled).ToList();
            ViewBag.Passengers = _context.Passengers.ToList();
            if (reservation != null) {
                Reservation reservation1 = new Reservation()
                {
                    PassengerId = reservation.PassengerId,
                    FlightId = reservation.FlightId,
                    ReservationDate = reservation.ReservationDate,
                    JourneyDate = reservation.JourneyDate,
                    PaymentMode = reservation.PaymentMode,
                    IsCancelled = false,
                    Amount = reservation.Amount

                };
                _context.Reservations.Add(reservation1);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reservation);
        }

        [Authorize(Roles = "User")]
        public IActionResult UserCreate(int passengerId, int flightId)
        {
            Reservation reservation = new Reservation();
            ViewBag.Flight = _context.Flights.Where(f => f.Id == flightId).FirstOrDefault();
            ViewBag.Passenger = _context.Passengers.Where(p => p.Id == passengerId).FirstOrDefault();
            return View(reservation);
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult UserCreate(Reservation reservation)
        {
            string? UserId = User.FindFirst(claim => claim.Type == System.Security.Claims.ClaimTypes.Sid)?.Value;
            int userid = Convert.ToInt32(UserId);
            ViewBag.Flights = _context.Flights.Where(f => !f.IsCancelled).ToList();
            ViewBag.Passengers = _context.Passengers.ToList();
            if (reservation != null)
            {
                Reservation reservation1 = new Reservation()
                {
                    PassengerId = reservation.PassengerId,
                    FlightId = reservation.FlightId,
                    ReservationDate = reservation.ReservationDate,
                    JourneyDate = reservation.JourneyDate,
                    PaymentMode = reservation.PaymentMode,
                    IsCancelled = false,
                    Amount = reservation.Amount,
                    UserId = userid

                };
                _context.Reservations.Add(reservation1);
                _context.SaveChanges();
                var filght = _context.Flights.Where(f => f.Id == reservation.FlightId).FirstOrDefault();
                filght.AvailableSeats -= 1;
                _context.SaveChanges();
                return RedirectToAction("UserIndex");
            }
            return View(reservation);
        }

        [Authorize(Roles = "Admin,User")]
        public IActionResult Details(int id)
        {
            var reservation = _context.Reservations
                .Where(r => r.Id == id)
                .Select(r => new
                {
                    r.Id,
                    r.ReservationDate,
                    r.JourneyDate,
                    r.PaymentMode,
                    r.Amount,
                    r.IsCancelled,
                    PassengerName = r.Passenger.Name,
                    FlightName = r.Flight.Name
                })
                .FirstOrDefault();

            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        [Authorize(Roles = "Admin,User")]
        public IActionResult Cancel(int id)
        {
            var reservation = _context.Reservations.Find(id);
            if (reservation == null)
            {
                return NotFound();
            }

            reservation.IsCancelled = true;
            _context.Reservations.Update(reservation);
            _context.SaveChanges();

            if (User.FindFirst(claim => claim.Type == System.Security.Claims.ClaimTypes.Role)?.Value == "Admin") {
                return RedirectToAction("Index");
            }
            else
            return RedirectToAction("UserIndex");
        }
    }
}