using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAI.Models
{
    [Table("TB_MAI_LOGIN")]
    public class Login
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLogin { get; set; }

        [Column("Email", TypeName = "varchar(255)")]
        [EmailAddress]
        public string EmailLogin {  get; set; }

        [Required(ErrorMessage = "A senha não pode ser nula")]
        public string Senha {  get; set; }

    }
}
