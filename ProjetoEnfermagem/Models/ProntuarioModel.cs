using System.ComponentModel.DataAnnotations;

namespace EnfermariaSenac.Models
{
    public class ProntuarioModel : Paciente
    {

        public int ID_Prontuario { get; set; }
        public int ID_Paciente { get; set; }
        public int ID_Enfermagem { get; set; }
        public string Relatorioatendimento { get; set; }
        public string Nome_Paciente { get; set; }
        public string Nome_Enfermagem { get; set; }
        public string Data { get; set; }
        public string Horario { get; set; }


        public List<Paciente> listadePaciente { get; set;}

        public List<Enfermagem> listadeEnfermagem { get;set; }
    }
}
