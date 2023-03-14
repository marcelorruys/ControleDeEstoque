using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ControleEstoque.Models;

[Table("Produto")]
public class Produto
{
    [Key]
    public int ProdutoId { get; set; }

    [Required(ErrorMessage = "O nome do produto deve ser informado")]
    [Display(Name = "Nome do Produto")]
    [StringLength(80, MinimumLength = 10, ErrorMessage = "O {0} deve ter no mínimo {1} e no máximo {2} caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O descrição detalhada do produto deve ser informada")]
    [Display(Name = "Descrição detalhada do Produto")]
    [MinLength(20, ErrorMessage = "Descrição detalhada deve ter no mínimo {1} caracteres")]
    [MaxLength(200, ErrorMessage = "Descrição detalhada pode exceder {1} caracteres")]
    public string DescricaoDetalhada { get; set; }

    [Display(Name = "Caminho Imagem")]
    [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
    public string ImagemUrl { get; set; }

    [Display(Name = "Favorito")]
    public bool IsProdutoPreferido { get; set; }

    [Display(Name = "Estoque Mínimo")]
    public int EstoqueMinimo { get; set; }

    [Display(Name = "Estoque Máximo")]
    public int EstoqueMaximo { get; set; }

    [Display(Name = "Estoque")]
    public int Estoque { get; set; }

    public int CategoriaId { get; set; }
    public virtual Categoria Categoria { get; set; }

    public int LoteId { get; set; }
    public virtual Lote Lote { get; set; }
}
