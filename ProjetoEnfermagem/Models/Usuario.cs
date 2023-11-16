using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace EnfermariaSenac.Models
{
    public class Usuario
    {
        [Key] public int IdUsuario { get; set; }   
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }

        public string SenhaMascarada
        {
            get
            {
                // Retornar uma string mascarada com asteriscos
                return new string('*', Senha.Length);
            }
        }
    }

}
