using Examen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Examen.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly ILogger<IndexModel> _logger;
        private readonly ContextModels.StudentContext _context;
        public Student[] Studenti;
        public IndexModel(ContextModels.StudentContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Studenti = _context.Student.Include(m => m.Grupa).ToArray();
        }
    }
}