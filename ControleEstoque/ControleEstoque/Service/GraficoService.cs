using ControleEstoque.Context;
using ControleEstoque.Models;

namespace ControleEstoque.Service
{
    public class GraficoService
    {
        private readonly AppDbContext context;

        public GraficoService(AppDbContext context)
        {
            this.context = context;
        }

        public List<ProdutoGrafico> GetQntdProdutos(int dias = 360)
        {
            var data = DateTime.Now.AddDays(-dias);

            var produtos = context.Produto;

            var lista = new List<ProdutoGrafico>();

            foreach (var item in produtos)
            {
                var produto = new ProdutoGrafico();
                produto.ProdutoNome = item.Nome;
                produto.ProdutoQuantidadeTotal = context.Produto.Count();
                produto.ProdutoQuantidadeIdeal = context.Produto.Where( p => p.Estoque >= p.EstoqueMinimo && p.Estoque <= p.EstoqueMaximo).Count();
                produto.ProdutoQuantidadeAbaixo = context.Produto.Where(p => p.Estoque < p.EstoqueMinimo).Count();
                produto.ProdutoQuantidadeAcima = context.Produto.Where(p => p.Estoque > p.EstoqueMaximo).Count();
                lista.Add(produto);
            }
            return lista;
        }
    }
}
