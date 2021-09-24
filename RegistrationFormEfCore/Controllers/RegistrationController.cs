using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RegistrationFormEfCore.Data;
using RegistrationFormEfCore.Dtos;
using RegistrationFormEfCore.Models;
using System.Collections.Generic;
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

            //    var questions = _context.Questions.Include(q => q.DropDownOptions).ToList();
            //    var showRegistrations = new List<ShowRegistration>();

            //    foreach (var question in questions)
            //    {

            //        var showRegistration = new ShowRegistration()
            //        {
            //            //SelectedValue = _context.SelectedValues.ToList()

            //            RegistrationId = question.Id,
            //            Questions = question.Text,
            //            DropDownOptions = question.DropDownOptions

            //        };
            //        showRegistrations.Add(showRegistration);
            //    }
            //    return View(showRegistrations);
        }

        [HttpPost]
        public IActionResult Index(int regid)
        {
            var questions = _context.Questions.Include(f => f.DropDownOptions).ToList();
            var selectedValues = _context.SelectedValues.Where(v => v.RegistrationId == regid).ToList();
            return RedirectToAction("Index");

            var viewModel = new ShowRegistration
            {
                RegistrationId = regid,
                OptionValues = new()
            };

            foreach (var question in questions)
            {
                var selectedValue = selectedValues.SingleOrDefault(v => v.RegistrationId == regid && v.QuestionId == question.Id);

                viewModel.OptionValues.Add(new OptionValue
                {
                    Question = question,
                    SelectedOptionId = (selectedValue != null) ? selectedValue.DropDownOptionId : 0
                });
            }

            return View(viewModel);
        }


        public IActionResult Edit(int id)
        {

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(SelectedValue selectedValue)
        {
            _context.SelectedValues.Update(selectedValue);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult SaveChanges(List<ShowRegistration> showRegistration)
        {
            var NewSelectedValues = new SelectedValue()
            {
                //QuestionId = showRegistration
                //DropDownOptionId = showRegistration.
            };
            _context.SelectedValues.Add(NewSelectedValues);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}
