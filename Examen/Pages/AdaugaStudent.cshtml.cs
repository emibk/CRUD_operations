using Examen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Xml.Schema;

namespace Examen.Pages
{
    public class AdaugaStudentModel : PageModel
    {
        [BindProperty]
        public Student Student { get; set; }
        public List<SelectListItem> grupa { get; set; }
        private readonly ContextModels.StudentContext _context;
        public AdaugaStudentModel(ContextModels.StudentContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            Student = new Student();
            grupa = _context.Grupa.Select(
                x => new SelectListItem{
                Text = x.Denumire,
                Value = x.Id.ToString()
            }).ToList();
        }
        public IActionResult OnPost()
        {
            _context.Add(Student);
            _context.SaveChanges();
            return RedirectToPage("/Index");
        }
    }
}
