using RegistrationFormEfCore.Models;
using System.Collections.Generic;

namespace RegistrationFormEfCore.Dtos
{
    public class ShowRegistration
    {
        public int RegistrationId { get; set; }
        public List<SelectedValue> SelectedValue { get; set; }


        public Question Question { get; set; }
        public DropDownOption DropDownOption { get; set; }
        public List<Question> Questions { get; set; }
        public List<DropDownOption> DropDownOptions { get; set; }

    }
}

