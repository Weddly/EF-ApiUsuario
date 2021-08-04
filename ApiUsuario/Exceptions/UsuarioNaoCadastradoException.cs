using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUsuario.Exceptions
{
    public class UsuarioNaoCadastradoException : Exception
    {
        public UsuarioNaoCadastradoException() : base ("Usuário não está cadastrado")
        { }
    }
}
