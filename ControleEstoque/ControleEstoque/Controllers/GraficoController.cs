using ControleEstoque.Service;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.Controllers
{
    public class GraficoController : Controller
    {
        private readonly GraficoService _graficoProduto;

        public GraficoController(GraficoService graficoProduto)
        {
            _graficoProduto = graficoProduto ?? throw new ArgumentNullException(nameof(graficoProduto));
        }

        public JsonResult ProdutosQuantidade(int dias)
        {
            var ProdutosTotal = _graficoProduto.GetQntdProdutos(dias);
            return Json(ProdutosTotal);
        }
        [HttpGet]
        public IActionResult ProdutoTotal(int dias)
        {
            return View();
        }

        [HttpGet]
        public IActionResult EstoqueAbaixo(int dias)
        {
            return View();
        }

        [HttpGet]
        public IActionResult EstoqueAcima(int dias)
        {
            return View();
        }
    }
}
