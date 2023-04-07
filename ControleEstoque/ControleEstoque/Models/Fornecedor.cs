using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.Models;

public class Fornecedor
{
    [Key]
    public int FornecedorId { get; set; }

    [Required(ErrorMessage = "O nome do fornecedor deve ser informado")]
    [Display(Name = "Nome")]
    [StringLength(80, MinimumLength = 10, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "A Razão Social do fornecedor deve ser informada")]
    [Display(Name = "Razão Social")]
    [StringLength(80, MinimumLength = 10, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracteres")]
    public string RazaoSocial { get; set; }


    [Required(ErrorMessage = "O CPF/CNPJ do fornecedor deve ser informadO")]
    [Display(Name = "CPF/CNPJ")]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "O {0} deve ter {1} catacteres")]
    public string Cnpj { get; set; }

    [Required(ErrorMessage = "Informe o seu telefone")]
    [StringLength(25)]
    [DataType(DataType.PhoneNumber)]
    public string Telefone { get; set; }

    [Required(ErrorMessage = "Informe o email.")]
    [StringLength(50)]
    [DataType(DataType.EmailAddress)]
    [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
        ErrorMessage = "O email não possui um formato correto")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Informe o endereço")]
    [StringLength(100)]
    [Display(Name = "Endereço")]
    public string Endereco1 { get; set; }

    [StringLength(100)]
    [Display(Name = "Complemento")]
    public string Endereco2 { get; set; }

    [Required(ErrorMessage = "Informe o CEP")]
    [Display(Name = "CEP")]
    [StringLength(10, MinimumLength = 8)]
    [DataType(DataType.PostalCode)]
    public string Cep { get; set; }

    [Required(ErrorMessage = "Informe o Estado")]
    [StringLength(10)]
    public string Estado { get; set; }

    [Required(ErrorMessage = "Informe a cidade")]
    [StringLength(50)]
    public string Cidade { get; set; }

    [Required(ErrorMessage = "A descrição do Fornecedor deve ser informada")]
    [Display(Name = "Descrição")]
    [MinLength(20, ErrorMessage = "Descrição detalhada deve ter no mínimo {1} caracteres")]
    [MaxLength(200, ErrorMessage = "Descrição detalhada pode exceder {1} caracteres")]
    public string DescricaoDetalhada { get; set; }

    public ICollection<Lote> Lotes { get; set; }
}
