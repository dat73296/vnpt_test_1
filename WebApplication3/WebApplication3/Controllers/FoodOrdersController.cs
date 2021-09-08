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
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class FoodOrdersController: Controller
    {
        private readonly WebDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public FoodOrdersController(WebDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: OrderFoods
        public async Task<IActionResult> Index()
        {
          //  var webDbContext = _context.FoodOrder.Include(o => o.Food).Include(o => o.Order);
            //return View(await webDbContext.ToListAsync());
            return View(await (from s in _context.FoodOrder.Include(o => o.Food).Include(o => o.Order)
                               where s.OrderId == Convert.ToInt32(_session.GetString("Order"))
                               select s).ToListAsync());
        }
        public async Task<IActionResult> Index3()
        {
            //  var webDbContext = _context.FoodOrder.Include(o => o.Food).Include(o => o.Order);
            //return View(await webDbContext.ToListAsync());
            return View(await (from s in _context.FoodOrder.Include(o => o.Food).Include(o => o.Order)
                               select s).ToListAsync());
        }
        public static int x;
        public static int x1;
        public static int x2;
        public static int x3;
        public  IActionResult Index1(int id)
        {
           
            int sum = 0;
            var ketqua = from s in _context.FoodOrder.Include(o => o.Food).Include(o => o.Order)
                               where s.OrderId == id
                               select s;
            foreach (var s in ketqua)
            {
                s.TotalMoney = Convert.ToInt32(s.Quantity * s.Food.Price);
                sum += s.TotalMoney;
            }
            ViewBag.Sum = sum;
            x = id;
            return View(ketqua);
            //return View(await (from s in _context.FoodOrder.Include(o => o.Food).Include(o => o.Order)
            //                   where s.OrderId == id
            //                   select s).ToListAsync()
            //                   );
        }

        // GET: OrderFoods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderFood = await _context.FoodOrder
                .Include(o => o.Food)
                .Include(o => o.Order)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (orderFood == null)
            {
                return NotFound();
            }

            return View(orderFood);
        }

        // GET: OrderFoods/Create
        public IActionResult Create(int id)
        {
            ViewData["FoodId"] = new SelectList(_context.Foods, "ID", "Image");
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id");
            var currentFoodOrder = new FoodOrder();
            currentFoodOrder.FoodId = id;
            currentFoodOrder.Quantity = 1;
            currentFoodOrder.OrderId = Convert.ToInt32(_session.GetString("Order"));
           // currentFoodOrder.TotalMoney =Convert.ToInt32(currentFoodOrder.Quantity * currentFoodOrder.Food.Price);
            if (ModelState.IsValid)
            {
                _context.Add(currentFoodOrder);
                _context.SaveChanges();
                return RedirectToAction("Index","Foods");
                ViewBag.Note = "Them thanh cong";
            }
            return View(currentFoodOrder);
        }

        // POST: OrderFoods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Quantity,FoodId,OrderId")] FoodOrder orderFood)
        {

            if (ModelState.IsValid)
            {
                _context.Add(orderFood);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FoodId"] = new SelectList(_context.Foods, "ID", "Image", orderFood.FoodId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", orderFood.OrderId);
            return View(orderFood);
        }

        // GET: OrderFoods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderFood = await _context.FoodOrder.FindAsync(id);
            if (orderFood == null)
            {
                return NotFound();
            }
            ViewData["FoodId"] = new SelectList(_context.Foods, "ID", "Image", orderFood.FoodId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", orderFood.OrderId);
            return View(orderFood);
        }

        // POST: OrderFoods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Quantity,FoodId,OrderId")] FoodOrder orderFood)
        {
            if (id != orderFood.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderFood);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderFoodExists(orderFood.ID))
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
            ViewData["FoodId"] = new SelectList(_context.Foods, "ID", "Image", orderFood.FoodId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", orderFood.OrderId);
            return View(orderFood);
        }

        // GET: OrderFoods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderFood = await _context.FoodOrder
                .Include(o => o.Food)
                .Include(o => o.Order)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (orderFood == null)
            {
                return NotFound();
            }

            return View(orderFood);
        }

        // POST: OrderFoods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderFood = await _context.FoodOrder.FindAsync(id);
            _context.FoodOrder.Remove(orderFood);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderFoodExists(int id)
        {
            return _context.FoodOrder.Any(e => e.ID == id);
        }

        public IActionResult Export()
        {

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("FoodOrder");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "ID Order";
                worksheet.Cell(currentRow, 2).Value = "Người đặt";
                worksheet.Cell(currentRow, 3).Value = "Món";
                worksheet.Cell(currentRow, 4).Value = "Số lượng";
                worksheet.Cell(currentRow, 5).Value = "Đơn giá";
                worksheet.Cell(currentRow, 6).Value = "Thời gian đặt";
                worksheet.Cell(currentRow, 7).Value = "Thành tiền";
                var kq = from s in _context.FoodOrder.Include(o => o.Food).Include(o => o.Order)
                         where s.OrderId == x
                         select s;
                foreach (var user in kq)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = user.ID;
                    worksheet.Cell(currentRow, 2).Value = _session.GetString("Ten");
                    worksheet.Cell(currentRow, 3).Value = user.Food.Name;
                    worksheet.Cell(currentRow, 4).Value = user.Quantity;
                    worksheet.Cell(currentRow, 5).Value = user.Food.Price;
                    worksheet.Cell(currentRow, 6).Value = user.Order.OrderDate;
                    worksheet.Cell(currentRow, 7).Value = Convert.ToInt32(user.Quantity * user.Food.Price);
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
        //[HttpPost]
        //public async Task<IActionResult> Search(IFormCollection log)
        //{
        //    DateTime a = Convert.ToDateTime(log["daytime"]);
        //    return View(await (from s in _context.FoodOrder.Include(f => f.Food).Include(f => f.User)
        //                       where (s.OrderDate.Day == a.Day && s.OrderDate.Month == a.Month && s.OrderDate.Year == a.Year)
        //                       select s).ToListAsync());
        //}

        public async Task<IActionResult> Down(int? id)
        {

            var foodorder = await _context.FoodOrder.FirstOrDefaultAsync(x => id == x.ID);
            var order = await _context.Orders.FirstOrDefaultAsync(x => Convert.ToInt32(_session.GetString("Order"))== x.Id);
            string s = order.Status.ToString();
            if (String.Compare(s, "Chưa xử li", true) == 0)
                foodorder.Quantity--;

            await _context.SaveChangesAsync();

            //var webDbContext = _context.FoodOrder.Include(o => o.Food).Include(o => o.Order);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Up(int? id)
        {

            var foodorder = await _context.FoodOrder.FirstOrDefaultAsync(x => id == x.ID);
            var order = await _context.Orders.FirstOrDefaultAsync(x => Convert.ToInt32(_session.GetString("Order")) == x.Id);
            string s = order.Status.ToString();
            if (String.Compare(s, "Chưa xử li", true) == 0)
                foodorder.Quantity++;

            await _context.SaveChangesAsync();

            //var webDbContext = _context.FoodOrder.Include(o => o.Food).Include(o => o.Order);
            //return View("Index", await webDbContext.ToListAsync());
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> Search1(IFormCollection log)
        {
            DateTime a = Convert.ToDateTime(log["day"]);
            x1 = Convert.ToInt32(a.Day);
            x2 = Convert.ToInt32(a.Month);
            x3 = Convert.ToInt32(a.Year);
            return View(await (from s in _context.FoodOrder.Include(o => o.Food).Include(o => o.Order)
                               where (s.Order.OrderDate.Day == a.Day && s.Order.OrderDate.Month == a.Month && s.Order.OrderDate.Year == a.Year)
                               select s).ToListAsync());
        }
        public IActionResult Export1()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("FoodOrder");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "ID Order";
                worksheet.Cell(currentRow, 2).Value = "Người đặt";
                worksheet.Cell(currentRow, 3).Value = "Món";
                worksheet.Cell(currentRow, 4).Value = "Số lượng";
                worksheet.Cell(currentRow, 5).Value = "Đơn giá";
                worksheet.Cell(currentRow, 6).Value = "Thời gian đặt";
                worksheet.Cell(currentRow, 7).Value = "Thành tiền";
                var kq = from s in _context.FoodOrder.Include(o => o.Food).Include(o => o.Order)
                         where s.Order.OrderDate.Day == x1 && s.Order.OrderDate.Month == x2 && s.Order.OrderDate.Year == x3
                         select s;
                foreach (var date in kq)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = date.OrderId;
                    worksheet.Cell(currentRow, 2).Value = date.Order.UserId;
                    worksheet.Cell(currentRow, 3).Value = date.Food.Name;
                    worksheet.Cell(currentRow, 4).Value = date.Quantity;
                    worksheet.Cell(currentRow, 5).Value = date.Food.Price;
                    worksheet.Cell(currentRow, 6).Value = date.Order.OrderDate;
                    worksheet.Cell(currentRow, 7).Value = Convert.ToInt32(date.Quantity * date.Food.Price);
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "ds.xlsx");
                }
            }
        }

    }
}

