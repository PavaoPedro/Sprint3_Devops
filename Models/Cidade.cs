using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAI.Models
{
    [Table("TB_MAI_CIDADE")]
    public class Cidade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCidade { get; set; }

        [Required(ErrorMessage = "O nome da cidade não pode ser nulo")] 
        public string CidadeNome { get; set; }

        public int IdEstado { get; set; }
        public Estado? Estado { get; set; }
    }
}
        
  
