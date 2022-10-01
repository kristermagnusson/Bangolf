using BangolfWeb.Validations;

namespace BangolfWeb.Models
{
    public class PlayerCreateViewModel
    {
     [Personnummer(ErrorMessage = " Ej giltigt personnummer")]
     public string Name { get; set; }
     public string Club { get; set; }     

    }
}
