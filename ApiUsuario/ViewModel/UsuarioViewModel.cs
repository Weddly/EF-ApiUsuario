using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUsuario.ViewModel
{
    public class UsuarioViewModel
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DtNascimento { get; set; }
        public int Escolaridade { get; set; }
    }
}
