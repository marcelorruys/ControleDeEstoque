using ControleEstoque.Models;

namespace ControleEstoque.Repositories.Interfaces;

public interface ICategoriaRepository
{
    IEnumerable<Categoria> Categorias { get; }
}
