using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleEstoque.Models;

[Table("Lote")]
public class Lote
{
    [Key]
    public int LoteId { get; set; }

    [Required(ErrorMessage = "Insira o código de referência do lote")]
    [Display(Name = "Código")]
    [StringLength(20, MinimumLength = 4, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} caracteres")]
    public string Referencia { get; set; }
    [Display(Name = "Fornecedor")]
    public virtual Fornecedor Fornecedor { get; set; }
    public int FornecedorId { get; set; }
    public ICollection<Produto> Produtos { get; set; } 

}
