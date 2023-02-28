using Examen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Examen.Pages
{
    public class EditareStudentModel : PageModel
    {
        private readonly ContextModels.StudentContext _context;
        public List<SelectListItem> grupa { get; set; }
        [BindProperty]
        public Student Student { get; set; }
        public EditareStudentModel(ContextModels.StudentContext context)
        {
            _context = context;
            
        }
        public void OnGet(int StudentId)
        {
            Student = _context.Student.Include(c => c.Grupa).FirstOrDefault(m => m.Id == StudentId);
            grupa = _context.Grupa.Select(
                x => new SelectListItem
                {
                    Text = x.Denumire,
                    Value = x.Id.ToString()
                }).ToList();
        }
        public IActionResult OnPost(int StudentId)
        {
            Student.Id = StudentId;
            _context.Update(Student);
            _context.SaveChanges();
            return RedirectToPage("/Index");
        }
    }
}
