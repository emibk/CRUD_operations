using Examen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Examen.Pages
{
    public class StergeStudentModel : PageModel
    {
        private readonly ContextModels.StudentContext _context;
        [BindProperty]
        public Student Studentrem { get; set; }
        public List<SelectListItem> grupa { get; set; }
        public StergeStudentModel(ContextModels.StudentContext context)
        {
            _context = context;
            grupa = _context.Grupa.Select(
                x => new SelectListItem
                {
                    Text = x.Denumire,
                    Value = x.Id.ToString()
                }).ToList();
        }
        public void OnGet(int StudentId)
        {
            Studentrem = _context.Student.Include(c=>c.Grupa).FirstOrDefault(m=>m.Id==StudentId);
        }
        public IActionResult OnPost(int StudentId)
        {
            Studentrem.Id = StudentId;
            _context.Remove(Studentrem);
            _context.SaveChanges();
            return RedirectToPage("/Index");
        }
    }
}
