using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Employee_Managment_Demo.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Employee_Managment_Demo.Controllers;

 public class EmployeeController : Controller
    {
        private readonly EMDContext _Context;

        public EmployeeController(EMDContext context)
         {
            _Context = context;
         }

         public async Task<IActionResult> Index()
         {
             return View(await _Context.Employee.ToListAsync());
         }

         
         public async Task<IActionResult> Edit(int? id)
         {
            if (id == null)
            {
                return NotFound();
            }
            
             var employee = await _Context.Employee.FindAsync(id);

             if(employee  == null)
             {
                 return NotFound();
             }
             ViewData["positions"] = new SelectList(_Context.Position, "ID","Position_Name");
             return View( employee);
         }

        [HttpPost]
         public async Task<IActionResult> Edit(int? id, [Bind("ID, First_Name, Last_Name, Email, Phone, Pay")] Employee employee,int PositionID)
         {
             if(id != employee.ID)
             {
                 return NotFound();
             }

             if(ModelState.IsValid)
             {
                 employee.PositionID = PositionID;
                 _Context.Update(employee);
                 await _Context.SaveChangesAsync();
                 return RedirectToAction(nameof(Index));
             }
             return View(employee);
         }

         public async Task<IActionResult> Delete(int? id)
         {
             if (id == null)
             {
                 return  NotFound();
             }

             var employee = await _Context.Employee.FirstOrDefaultAsync(e => e.ID == id);
             if(employee == null)
             {
                 return NotFound();
             }
             return View(employee);
         }

        [HttpPost]
         public async Task<IActionResult> delete(int id)
         {
             
             var employee = await _Context.Employee.FindAsync(id);
             _Context.Employee.Remove(employee);
             await _Context.SaveChangesAsync();
             return RedirectToAction(nameof(Index));
         }

         public async Task<IActionResult> create()
         {
            ViewData["positions"] = new SelectList(_Context.Position, "ID","Position_Name");
            return View();
         }

        [HttpPost]
         public async Task<IActionResult> create([Bind("ID, First_Name, Last_Name, Email, Phone, Pay")] Employee employee, int PositionID)
         {
             if(ModelState.IsValid)
             {
                 employee.PositionID = PositionID;
                 Console.WriteLine(PositionID);
                 _Context.Add(employee);
                 await _Context.SaveChangesAsync();
                 return RedirectToAction(nameof(Index));
             }
             return View();
         }

          public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _Context.Employee
            .Where(e => e.ID == id)
            .FirstOrDefaultAsync();
            if (employee == null)
            {
                return NotFound();
            }
            var position = await _Context.Position.FindAsync(employee.PositionID);
            ViewData["position"] = position.Position_Name;

            return View(employee);
        }
    }
