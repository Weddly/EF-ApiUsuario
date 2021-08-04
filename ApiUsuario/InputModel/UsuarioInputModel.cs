using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUsuario.InputModel
{
    public class UsuarioInputModel
    {

        [StringLength(30, MinimumLength = 3, ErrorMessage = "O nome do usuario deve conter entre 3 e 30 caracteres")]
        public string Nome { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O sobrenome do usuario deve conter entre 3 e 50 caracteres")]
        public string Sobrenome { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O email deve conter entre 3 e 50 caracteres")]
        public string Email { get; set; }
        public DateTime DtNascimento { get; set; }

        [Range(0, 3, ErrorMessage = "Escolaridade vai de 0 a 3")]
        public int Escolaridade { get; set; }
    }
}
