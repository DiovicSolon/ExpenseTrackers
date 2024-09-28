using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Account/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Create a new User entity with the form data
                var user = new User
                {
                    UserId = model.UserId, // Capture the UserId from the form
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password  // In a real application, you should hash the password
                };

                // Add the new user to the Users DbSet
                _context.Users.Add(user);
                _context.SaveChanges();  // Save changes to the database

                // Redirect to a different page after successful registration
                return RedirectToAction("Index", "Home");
            }

            // If model state is invalid, redisplay the form with validation errors
            return View(model);
        }
    }
}
