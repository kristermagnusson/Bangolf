using BangolfWeb.Models;
using System.ComponentModel.DataAnnotations;

namespace BangolfWeb.Validations
{
    public class Personnummer:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            if (value is string input) 
            {
               var viewModel = validationContext.ObjectInstance as PlayerCreateViewModel;
                if (viewModel is not null) 
                {
                    //if (TestPersNr(viewModel.Name) == true) 
                    if (TestPersNr(input) == true)
                    { 
                    return ValidationResult.Success;
                    }
                    else 
                    {
                        return new ValidationResult(ErrorMessage);
                    }
                }

            }
                return new ValidationResult(ErrorMessage);

        }

      static  bool TestPersNr(string personnummer)
        {
            string Pnr=personnummer;
            


            if (Pnr.Length != 10 || int.TryParse(Pnr, out int a)!) 
            { return false; }
            int Total = 0;
            int Temp = 0;
            for (int i = 0; i < Pnr.Length - 1; i++)
            {
                Temp = int.Parse(Pnr[i].ToString());
                if (i % 2 == 1)
                {
                    Total = Total + Temp;
                }
                if (i % 2 == 0)
                {
                    Temp = 2 * Temp;
                    if (Temp > 9)
                    {

                        Temp = Temp % 10 + Temp / 10;
                    }
                    Total = Total + Temp;
                }
            }

            if ((Total % 10 + int.Parse(personnummer[9].ToString())) % 10 == 0)
                return true;
            else return false;

        }


    }
}
