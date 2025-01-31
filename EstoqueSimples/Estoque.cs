namespace EstoqueSimples
{
    class Estoque
    {
        private List<Produto> produtos = new List<Produto>();

        public void AdicionarProduto(string nome, double preco, int quantidade)
        {
            Produto prodExistente = produtos.Find(p => p.Nome.ToLower() == nome.ToLower());

            if (prodExistente != null)
            {
                prodExistente.Quant += quantidade;
                Console.WriteLine($"\nForam adicionadas {quantidade} unidades ao produto '{nome}'.");
            }
            else
            {
                Produto prodNovo = new Produto(nome, preco, quantidade);
                produtos.Add(prodNovo);
                Console.WriteLine($"\nProduto {nome} adicionado ao estoque.");
            }
        }

        public void RemoverProduto(string nome, int quantidade)
        {
            Produto prodRemover = produtos.Find(p => p.Nome.ToLower() == nome.ToLower());
            
            if (prodRemover != null)
            {
                if (prodRemover.Quant >= quantidade)
                {
                    prodRemover.Quant -= quantidade;
                    Console.WriteLine($"\nForam removidas {quantidade} unidades do produto '{nome}'.");
                    
                    if (prodRemover.Quant == 0)
                    {
                        produtos.Remove(prodRemover);
                        Console.WriteLine($"\nO produto '{nome}' foi completamente removido do estoque.");
                    }
                }
                else
                {
                    Console.WriteLine($"\nNão há {quantidade} unidades disponíveis de '{nome}'.");
                }
            }
            else
            {
                Console.WriteLine($"\nProduto '{nome}' não encontrado!\n");
            }
        }

        public void ListarProdutos(string criterio)
        {
            if (produtos.Count == 0)
            {
                Console.WriteLine("\nO estoque está vazio!");
                return;
            }

            List<Produto> lista;
            switch (criterio.ToLower())
            {
                case "nome":
                    lista = produtos.OrderBy(p => p.Nome).ToList();
                    break;

                case "preço":
                    lista = produtos.OrderBy(p => p.Preco).ToList();
                    break;

                case "quantidade":
                    lista = produtos.OrderBy(p => p.Quant).ToList();
                    break;

                default:
                    Console.WriteLine("\nCritério invalido! Exibindo em ordem padrão.");
                    lista = produtos;
                    break;
            }

            Console.WriteLine("\nLista de produtos no estoque:");
            foreach (Produto p in lista)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();
        }
    }
}
