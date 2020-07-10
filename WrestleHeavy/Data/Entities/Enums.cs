using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Enums
    {
        public enum Gender
        {
            Male=1,
            Female
        }

        public enum Nationality
        {
            American=1,
            Canadian,
            Mexican,
            Japanese,
            British,
            Irish,
            Brazilian,
            Indian,
            Austrlian,
            Welsh,
            [Display(Name = "New Zealander")]
            NewZealander
        }
    }
}
