using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication6.Controllers
{
    public class OrdersController : Controller
    {
        private readonly WebDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public OrdersController(WebDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var webDbContext = _context.Orders.Include(o => o.User);
            return View(await webDbContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "UserName", "UserName");
            var order = new Order();
            order.UserId = _session.GetString("Ten");
            order.Status = "Chưa xử li";
            order.OrderDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(order);
                _context.SaveChanges();
                _session.SetString("Order", Convert.ToString(order.Id));
                ViewBag.Order = "Tạo Order thành công!!!";
                return RedirectToAction("Index", "Foods");
            }  
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,OrderDate,Status")] Order order)

        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Foods");
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserName", "UserName", order.UserId);
            _session.SetString("Order", Convert.ToString(order.Id));
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserName", "UserName", order.UserId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,OrderDate,Status")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "UserName", "UserName", order.UserId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);

        }
        public async Task<IActionResult> ListOrder()
        {
            return View(await (from s in _context.Orders
                               where s.UserId == _session.GetString("Ten")
                               select s).ToListAsync());
        }
        [HttpPost]
        public IActionResult Search(IFormCollection log)
        {
           DateTime a = Convert.ToDateTime(log["daytime"]);
            var x = from s1 in _context.Orders.Include(o => o.User)
                    where (s1.UserId == _session.GetString("Ten") && s1.OrderDate.Day == a.Day && s1.OrderDate.Month == a.Month && s1.OrderDate.Year == a.Year)
                    select s1;

            
            int sum = 0;
          foreach (var or in x)
          {
                var p = (from s2 in _context.FoodOrder.Include(o => o.Order)
                         where s2.OrderId == or.Id
                         select s2).ToList();
              foreach (var pp in p)
                {
                    sum += Convert.ToInt32(pp.TotalMoney);
                    return View(pp);
                }
          }
            //ViewBag.ToTalMoney = sum;
            return View();
            //return View(await (from s in _context.Orders.Include(o => o.User)
            //                   where (s.UserId == _session.GetString("Ten") && s.OrderDate.Day == a.Day && s.OrderDate.Month == a.Month && s.OrderDate.Year == a.Year)
            //                   select s).ToListAsync());
        }

    }
}
