using System;
using System.ComponentModel.DataAnnotations;

namespace DrCash.Teste.Api.ViewModel
{
    public class LivroViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Titulo { get; set; }
        public AutorViewModel AutorViewModel { get; set; }
        public GeneroViewModel GeneroViewModel { get; set; }

       
    }
}

