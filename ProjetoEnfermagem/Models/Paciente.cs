using System.ComponentModel.DataAnnotations;

namespace EnfermariaSenac.Models
{
    public class Paciente
    {
        [Key] 
        public int ID_Paciente { get; set; }
        public string Nome_Paciente { get; set; }
        public int Idade { get; set; }
        public string Data_Nasc { get; set; }
        public string Alergico { get; set; }

    }
}
