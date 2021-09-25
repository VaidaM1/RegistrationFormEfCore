using System.Collections.Generic;

namespace RegistrationFormEfCore.Models
{
    public class Registration
    {
        public int Id { get; set; }

        public List<SelectedValue> QuestionInformations { get; set; }
    }

}
