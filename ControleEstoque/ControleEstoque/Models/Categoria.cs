using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ControleEstoque.Models;

[Table("Categoria")]
public class Categoria
{
    [Key]
    public int CategoriaId { get; set; }

    [StringLength(100, ErrorMessage = "O tamanho máximo é 100 caracteres")]
    [Required(ErrorMessage = "Informe o nome da categoria")]
    [Display(Name = "Nome")]
    public string CategoriaNome { get; set; }

    [StringLength(200, ErrorMessage = "O tamanho máximo é 200 caracteres")]
    [Required(ErrorMessage = "Informe a descrição da categoria")]
    [Display(Name = "Descrição")]
    public string Descricao { get; set; }

    public List<Produto> Produtos { get; set; } = new List<Produto>();

    public Categoria()
    {
    }

    public Categoria(int categoriaId, string categoriaNome, string descricao)
    {
        CategoriaId = categoriaId;
        CategoriaNome = categoriaNome;
        Descricao = descricao;
    }
}