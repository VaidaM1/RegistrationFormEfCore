using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RegistrationFormEfCore.Data;
using RegistrationFormEfCore.Dtos;
using System.Linq;

namespace RegistrationFormEfCore.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly ILogger<RegistrationController> _logger;
        private readonly DataContext _context;

        public RegistrationController(ILogger<RegistrationController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            var viewForm = new ShowRegistration()
            {
                SelectedValue = _context.SelectedValues.Include(a => a.Question).ThenInclude(a => a.DropDownOptions).ToList()
            };
            return View(viewForm);

            //return View(_context.SelectedValues.Select(v => v.RegistrationId).Distinct().ToList());

        }

        [HttpPost]
        public IActionResult Index(int regid)
        {
            var questions = _context.Questions.Include(f => f.DropDownOptions).ToList();
            var selectedValues = _context.SelectedValues.Where(v => v.RegistrationId == regid).ToList();
            return RedirectToAction("Index");


            //foreach (var question in questions)
            //{
            //    var selectedValue = selectedValues.SingleOrDefault(v => v.RegistrationId == regid && v.QuestionId == question.Id);
            //    viewModel.SelectedValue.Add(new SelectedValue
            //    {
            //        Question = question,
            //        SelectedOptionId = (selectedValue != null) ? selectedValue.DropDownOptionId : 0
            //    });
            //}
            //return View(viewModel);
        }


        //var oldValues = _context.SelectedValues.Where(v => v.RegistrationId == viewModel.RegistrationId);
        //_context.SelectedValues.RemoveRange(oldValues);
        
        [HttpPost]
        public IActionResult SaveChanges(ShowRegistration registrationForm)
        {
            if (registrationForm.RegistrationId == 0)
            {
                registrationForm.RegistrationId = 1;
            }

            var registration = _context.Registrations.Include(r => r.QuestionInformations).FirstOrDefault(r => r.Id == registrationForm.RegistrationId);

            registration.QuestionInformations = registrationForm.SelectedValue;

            _context.Update(registration);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
