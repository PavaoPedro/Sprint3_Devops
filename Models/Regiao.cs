using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAI.Models
{
    [Table("TB_MAI_REGIAO")]
    public class Regiao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRegiao { get; set; }

        [Required(ErrorMessage = "O nome da região não pode ser nulo")]
        public string RegiaoNome { get; set; }

        public int IdCidade { get; set; }
        public Cidade? Cidade {  get; set; }  
    }
}
