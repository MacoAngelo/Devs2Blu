using System.ComponentModel.DataAnnotations;

namespace orcamentor.api.Model
{
    public class Contato
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Numero { get; set; }
    }

    public class Carro
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public int Ano { get; set; }

        [Required]
        public string Placa { get; set; }

        [Required]
        public long Marca { get; set; }
    }
}
