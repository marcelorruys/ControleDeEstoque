using ControleEstoque.Models;

namespace ControleEstoque.Models.ViewModels;

public class ProdutoListViewModel
{
    public IEnumerable<Produto> Produtos { get; set; }
    public string CategoriaAtual { get; set; }
}
