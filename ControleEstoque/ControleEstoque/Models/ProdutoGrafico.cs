namespace ControleEstoque.Models
{
    public class ProdutoGrafico
    {
        public string ProdutoNome { get; set; }
        public int ProdutoQuantidadeTotal { get; set; }
        public int ProdutoQuantidadeIdeal { get; set; }
        public int ProdutoQuantidadeAbaixo { get; set; }
        public int ProdutoQuantidadeAcima { get; set; }

    }
}
