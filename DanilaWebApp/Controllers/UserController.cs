using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DanilaWebApp.Data;
using DanilaWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace DanilaWebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly DataContext _context;

        public UserController(DataContext context, RoleManager<IdentityRole> roleManagers, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            roleManager = roleManagers;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            //var context = _context.Match.Include(m => m.UserMatches).ThenInclude(m => m.User).Include(m => m.Team_home).Include(m => m.Team_guest);
            if (User.Identity.IsAuthenticated)
                return View(await _context.Users.ToListAsync());
            else
                return RedirectToAction("Login");
           // return View();//await context.ToListAsync());
        }

        public async Task<IActionResult> WatchUsers()
        {
            if (User.Identity.IsAuthenticated)
                return View(await _context.Users.ToListAsync());
            else
                return RedirectToAction("Login");
        }
        [Authorize(Roles = "user,admin")]
        // GET: Users/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        // GET: Users/Create

        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register([Bind("UserName,Password")]User user)
        {
            if (ModelState.IsValid)
            {
                User users = new User { Password = user.Password, UserName = user.UserName };


                var result = await _userManager.CreateAsync(user, user.Password);
                if (result.Succeeded)
                {

                    bool userRoleExists = await roleManager.RoleExistsAsync("user");
                    bool adminRoleExists = await roleManager.RoleExistsAsync("admin");
                    if (!userRoleExists)
                        await roleManager.CreateAsync(new IdentityRole("user"));
                    if (!adminRoleExists)
                        await roleManager.CreateAsync(new IdentityRole("admin"));

                    if (user.UserName == "Ali654")
                        await _userManager.AddToRoleAsync(user, "admin");
                    else
                        await _userManager.AddToRoleAsync(user, "user");
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Login", "User");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(user);
        }

        public IActionResult Login() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("UserName,Password")]User user)
        {
            if (ModelState.IsValid)
            {
                var result =
            await _signInManager.PasswordSignInAsync(user.UserName, user.Password, true, false);
                //User users = _context.User.FirstOrDefault(u => u.UserName == user.UserName && u.UserPassword == user.UserPassword);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "User");
                }
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {

            await _signInManager.SignOutAsync();
            //User users = _context.User.FirstOrDefault(u => u.UserName == user.UserName && u.UserPassword == user.UserPassword);
            return RedirectToAction("Login", "Users");
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Username,UserPassword,Points")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        [Authorize(Roles = "admin")]
        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserId,Username,UserPassword,Points")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(Convert.ToInt32(user.Id)))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }
        [Authorize(Roles = "admin")]
        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(string id, string ReturnUrl = "Access Denied")
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(WatchUsers));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => Convert.ToInt32(e.Id) == id);
        }
    }
}