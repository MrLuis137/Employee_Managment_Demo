using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Employee_Managment_Demo.Models;

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
             return View( employee);
         }

        [HttpPost]
         public async Task<IActionResult> Edit(int? id, [Bind("ID, First_Name, Last_Name, Email")] Employee employee)
         {
             if(id != employee.ID)
             {
                 return NotFound();
             }

             if(ModelState.IsValid)
             {
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

         public  IActionResult create()
         {
             return View();
         }

        [HttpPost]
         public async Task<IActionResult> create([Bind("ID, First_Name, Last_Name, Email")] Employee employee)
         {
             if(ModelState.IsValid)
             {
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

            var medico = await _Context.Employee
            .Where(e => e.ID == id)
            .FirstOrDefaultAsync();
            if (medico == null)
            {
                return NotFound();
            }

            return View(medico);
        }
    }
