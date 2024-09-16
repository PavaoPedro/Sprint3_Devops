using Microsoft.AspNetCore.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAI.Models
{
    [Table("TB_MAI_EMPRESA")]
    public class Empresa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEmpresa { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }

        [MaxLength(14,ErrorMessage = "O CNPJ deve conter no maxímo 14 caracteres")]
        public string CNPJ { get; set;}

        [Required]
        public string Email { get; set; }


        [ForeignKey("IdLogin")]
        public int? IdLogin { get; set; }
        public Login? Login {  get; set; }

        public int IdRegiao { get; set; }
        public Regiao? Regiao { get; set; }


    }
}
