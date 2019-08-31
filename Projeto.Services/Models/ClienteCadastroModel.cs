using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Services.Models
{
    public class ClienteCadastroModel
    {
        [Required(ErrorMessage = "O campo {0} não pode ser nulo.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} não pode ser nulo.")]
        public string Email { get; set; }
    }
}