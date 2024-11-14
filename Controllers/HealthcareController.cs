using BookingDoctor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingDoctor.Controllers
{
    public class HealthcareController : Controller
    {
        private readonly HealthcareContext _context;

        public HealthcareController(HealthcareContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new HealthcareIndexViewModel
            {
                Hospitals = await _context.Hospitals.ToListAsync(),
                FeaturedDoctors = await _context.Doctors
                    .Include(d => d.Hospital)                  
                    .Take(4)
                    .ToListAsync()
            };
            return View(viewModel);
        }

        public async Task<IActionResult> WhoWeAre()
        {
            var hospitals = await _context.Hospitals.ToListAsync();
            return View(hospitals);
        }

        public async Task<IActionResult> WhatWeDo()
        {
            var specializations = await _context.Specializations
                .Include(s => s.Doctors)
                .ToListAsync();
            return View(specializations);
        }

        public IActionResult Society()
        {
            return View();
        }

        public IActionResult Investors()
        {
            return View();
        }

        public IActionResult Brand()
        {
            return View();
        }
    }
}