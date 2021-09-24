using RegistrationFormEfCore.Models;
using System.Collections.Generic;

namespace RegistrationFormEfCore.Dtos
{
    public class ShowRegistration
    {
        public int RegistrationId { get; set; }
        public List<SelectedValue> SelectedValue { get; set; }

        public List<OptionValue> OptionValues { get; set; }
    }

    public class OptionValue
    {
        public Question Question { get; set; }

        public int SelectedOptionId { get; set; }
    }


    //public List<Question> Questions { get; set; }
    //public List<DropDownOption> DropDownOptions { get; set; }

}

