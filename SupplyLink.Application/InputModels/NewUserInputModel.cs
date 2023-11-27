using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SupplyLink.Application.InputModels
{
    public class NewUserInputModel
    {
        public int Id { get; set; }
        public string FullName { get;  set; }
        public string Email { get;  set; }
        public DateTime BirthDate { get;  set; }
        [NotMapped]
        public string Password { get; set; }

    }

}
