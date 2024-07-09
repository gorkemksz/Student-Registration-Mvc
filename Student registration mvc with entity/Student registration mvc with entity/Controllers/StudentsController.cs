using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_registration_mvc_with_entity.Data;
using Student_registration_mvc_with_entity.Models;
using Student_registration_mvc_with_entity.Models.Entities;

namespace Student_registration_mvc_with_entity.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public StudentsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;

        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel viewModel)
        {
            var student = new Student
            {
                Name = viewModel.Name,
                Surname = viewModel.Surname,
                Email = viewModel.Email,
                PhoneNumber = viewModel.PhoneNumber,
                DateOfBirth = viewModel.DateOfBirth,
            };

            await dbContext.Students1.AddAsync(student);
            await dbContext.SaveChangesAsync();

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var student = await dbContext.Students1.ToListAsync();

            return View(student);
        }
        [HttpGet]
        public async Task<IActionResult> ListAjax()
        {
            var student = await dbContext.Students1.ToListAsync();

            return Json(student);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid ID)
        {
            var student = await dbContext.Students1.FindAsync(ID);
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Student viewModel)
        {
           var student = await dbContext.Students1.FindAsync(viewModel.Id);
           if (student != null)
            {
                student.Name = viewModel.Name;
                student.Surname = viewModel.Surname;
                student.Email = viewModel.Email;
                student.PhoneNumber = viewModel.PhoneNumber;
                student.DateOfBirth = viewModel.DateOfBirth;

                await dbContext.SaveChangesAsync();
            }
           return RedirectToAction("List","Students");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Student viewModel)
        {
            var student = await dbContext.Students1.AsNoTracking().FirstOrDefaultAsync(x => x.Id == viewModel.Id);

            if (student != null)
            {
                dbContext.Students1.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Students");
        }
    }
}
