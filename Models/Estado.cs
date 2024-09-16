using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAI.Models
{
    [Table("TB_MAI_ESTADO")]
    public class Estado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEstado { get; set; }

        [Required(ErrorMessage = "O nome do estado não pode ser nulo")]
        public string EstadoNome { get; set; }

        [MaxLength(2,ErrorMessage = "A sigla deve conter no máximo 2 caracteres")]
        public string Sigla { get; set; }
        
    }
}
