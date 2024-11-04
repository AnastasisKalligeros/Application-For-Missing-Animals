using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationForMissingAnimals.Models
{
	public class Account
	{

        public string Name { get; set; }

        [Required(ErrorMessage = "Invalid username or password")]
        public string Password { get; set; }
      


    }
}
