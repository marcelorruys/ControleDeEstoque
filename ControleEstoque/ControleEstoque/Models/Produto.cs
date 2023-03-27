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
    [Display(Name = "Nome")]
    [StringLength(80, MinimumLength = 10, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O descrição detalhada do produto deve ser informada")]
    [Display(Name = "Descrição")]
    [MinLength(20, ErrorMessage = "Descrição deve ter no mínimo {1} caracteres")]
    [MaxLength(200, ErrorMessage = "Descrição não pode exceder {1} caracteres")]
    public string DescricaoDetalhada { get; set; }

    [Display(Name = "Link Imagem")]
    [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
    public string ImagemUrl { get; set; }

    [Display(Name = "Favorito")]
    public bool IsProdutoPreferido { get; set; }

    [Display(Name = "Estoque Mínimo")]
    public int EstoqueMinimo { get; set; }

    [Display(Name = "Estoque Máximo")]
    public int EstoqueMaximo { get; set; }

    [Display(Name = "Estoque Atual")]
    public int Estoque { get; set; }

    [Display(Name = "Categoria")]
    public int CategoriaId { get; set; }
    public virtual Categoria Categoria { get; set; }

    [Display(Name = "Referência do Lote")]
    public int LoteId { get; set; }
    public virtual Lote Lote { get; set; }
}
