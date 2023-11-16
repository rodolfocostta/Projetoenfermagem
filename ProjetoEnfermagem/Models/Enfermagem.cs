using System.ComponentModel.DataAnnotations;

namespace EnfermariaSenac.Models
{
    public class Enfermagem
    {
        [Key]
        public int ID_Enfermagem { get; set; }
        public string Nome_Enfermagem { get; set; }
        public string Coren  { get; set; }
       
    }
}
