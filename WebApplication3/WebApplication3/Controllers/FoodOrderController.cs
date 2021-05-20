using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class FoodOrdersController : Controller
    {
        private readonly WebDbContext _context;


        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public FoodOrdersController(WebDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: FoodOrders
        public async Task<IActionResult> Index()
        {
            ViewBag.session = _session.GetString("Ten");
            var webDbContext = _context.FoodOrder.Include(f => f.Food).Include(f => f.User);

            return View(await webDbContext.ToListAsync());
        }

        // GET: FoodOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodOrder = await _context.FoodOrder
                .Include(f => f.Food)
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.FoodId == id);
            if (foodOrder == null)
            {
                return NotFound();
            }

            return View(foodOrder);
        }
       

        // GET: FoodOrders/Create
        public IActionResult Create(int id)
        {
            ViewData["FoodId"] = new SelectList(_context.Foods, "ID", "Name");
            ViewData["UserId"] = new SelectList(_context.Users, "UserName", "UserName");
            var currentFoodOrder = new FoodOrder();
            currentFoodOrder.FoodId = id;
            currentFoodOrder.OrderDate = DateTime.Now;
            currentFoodOrder.Quantity = 1;
            currentFoodOrder.Status = "Chưa xử li";
            currentFoodOrder.UserId = _session.GetString("Ten");

            if (ModelState.IsValid)
            {
                _context.Add(currentFoodOrder);

                _context.SaveChanges();
                return RedirectToAction(nameof(ListOrder));
            }
            return View();
        }

        // POST: FoodOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id,[Bind("Id,FoodId,UserId,Quantity,OrderDate,Status")] FoodOrder foodOrder)
        {
            var currentFoodOrder = new FoodOrder();
            currentFoodOrder.FoodId = id;
            currentFoodOrder.OrderDate = DateTime.Now;
            currentFoodOrder.Quantity = 1;
            currentFoodOrder.Status = "Chưa xử lí";
            currentFoodOrder.UserId = _session.GetString("Ten");

            if (ModelState.IsValid)
            {                
                await _context.AddAsync(currentFoodOrder);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListOrder));
            }
            ViewData["FoodId"] = new SelectList(_context.Foods, "ID", "Name", foodOrder.FoodId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserName", "UserName", foodOrder.UserId);

            return View(foodOrder);
        }

        // GET: FoodOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodOrder = await _context.FoodOrder.FindAsync(id);
            if (foodOrder == null)
            {
                return NotFound();
            }
            ViewData["FoodId"] = new SelectList(_context.Foods, "ID", "Name", foodOrder.FoodId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserName", "UserName", foodOrder.UserId);
            return View(foodOrder);
        }

        // POST: FoodOrder/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FoodId,UserId,Quantity,OrderDate,Status")] FoodOrder foodOrder)
        {
            if (id != foodOrder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foodOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodOrderExists(foodOrder.Id))
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
            ViewData["FoodId"] = new SelectList(_context.Foods, "ID", "Name", foodOrder.FoodId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserName", "UserName", foodOrder.UserId);
            return View(foodOrder);
        }
        // GET: FoodOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
          {
              if (id == null)
              {
                  return NotFound();
              }

              var foodOrder = await _context.FoodOrder
                  .Include(f => f.Food)
                  .Include(f => f.User)
                  .FirstOrDefaultAsync(m => m.FoodId == id);
              if (foodOrder == null)
              {
                  return NotFound();
              }

              return View(foodOrder);
          }

          // POST: FoodOrders/Delete/5
          [HttpPost, ActionName("Delete")]
          [ValidateAntiForgeryToken]
          public async Task<IActionResult> DeleteConfirmed(int id)
          {
              var foodOrder = await _context.FoodOrder.FindAsync(id);
              _context.FoodOrder.Remove(foodOrder);
              await _context.SaveChangesAsync();
              return RedirectToAction(nameof(Index));
          }

          private bool FoodOrderExists(int id)
          {
              return _context.FoodOrder.Any(e => e.FoodId == id);
          }


          public async Task<IActionResult> Down(int? id)
          {

              var order = await _context.FoodOrder.FirstOrDefaultAsync(x => id == x.Id);
            string s = order.Status.ToString();
            if (String.Compare(s, "Chưa xử li", true) == 0)
                order.Quantity--;

              await _context.SaveChangesAsync();

              var webDbContext = _context.FoodOrder.Include(f => f.Food).Include(f => f.User);
              return View("ListOrder", await webDbContext.ToListAsync());
          }

          public async Task<IActionResult> Up(int? id)
          {

              var order = await _context.FoodOrder.FirstOrDefaultAsync(x => id == x.Id);
              string s = order.Status.ToString();
              if (String.Compare(s, "Chưa xử li", true) == 0)
                order.Quantity++;

              await _context.SaveChangesAsync();

              var webDbContext = _context.FoodOrder.Include(f => f.Food).Include(f => f.User);
              return View("ListOrder", await webDbContext.ToListAsync());
          }
        
          public async Task<IActionResult> ListOrder()
          { 
              return View(await (from s in _context.FoodOrder.Include(f => f.Food).Include(f => f.User)
              where s.UserId == _session.GetString("Ten")
                                 select s).ToListAsync());
          }
        
        public IActionResult Export()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("FoodOrder");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Người đặt";
                worksheet.Cell(currentRow, 2).Value = "Món";
                worksheet.Cell(currentRow, 3).Value = "Số lượng";
                worksheet.Cell(currentRow, 4).Value = "Thời gian đặt";
                foreach (var user in _context.FoodOrder.Include(f => f.Food).Include(f => f.User).ToList())
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = user.User.UserName;
                    worksheet.Cell(currentRow, 2).Value = user.Food.Name;
                    worksheet.Cell(currentRow, 3).Value = user.Quantity;
                    worksheet.Cell(currentRow, 4).Value = user.OrderDate;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "users.xlsx");
                }
            }
        }
        [HttpPost]
        public async Task<IActionResult> Search(IFormCollection log)
        {
            DateTime a = Convert.ToDateTime(log["daytime"]);
            return View(await (from s in _context.FoodOrder.Include(f => f.Food).Include(f => f.User)
                               where (s.OrderDate.Day == a.Day && s.OrderDate.Month == a.Month && s.OrderDate.Year == a.Year )
                               select s).ToListAsync());
        }

       
        }
    }

