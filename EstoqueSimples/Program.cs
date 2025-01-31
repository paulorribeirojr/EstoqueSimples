using EstoqueSimples;
using System;
using System.Globalization;

namespace Principal
{
    class Program
    {
        static void Main(string[] args)
        {
            bool rep = true;
            Estoque estoque = new Estoque();

            while (rep == true)
            {
                Console.WriteLine("\n============ MENU ============");
                Console.WriteLine("1 - Adicionar produto");
                Console.WriteLine("2 - Remover produto");
                Console.WriteLine("3 - Listar produtos");
                Console.WriteLine("4 - Sair");

                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();
                Console.WriteLine();

                try
                {
                    switch (opcao)
                    {
                        case "1":
                            Console.WriteLine("Informe os dados do produto:");
                            Console.Write("Nome: ");
                            string nome = Console.ReadLine();

                            Console.Write("Preço: ");
                            double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                            Console.Write("Quantidade: ");
                            int quant = int.Parse(Console.ReadLine());

                            estoque.AdicionarProduto(nome, preco, quant);
                            break;

                        case "2":
                            Console.Write("Digite o nome do produto a ser removido: ");
                            string nomeRem = Console.ReadLine();

                            Console.Write("Digite a quantidade a remover: ");
                            int quantRem = int.Parse(Console.ReadLine());

                            estoque.RemoverProduto(nomeRem, quantRem);
                            break;

                        case "3":
                            Console.WriteLine("Como deseja listar os produtos?");
                            Console.WriteLine("Opções: nome, preço ou quantidade");
                            Console.Write("Digite a opção desejada: ");
                            string criterio = Console.ReadLine();

                            estoque.ListarProdutos(criterio);
                            break;

                        case "4":
                            Console.WriteLine("Obrigado por utilizar...");
                            rep = false;
                            break;

                        default:
                            Console.WriteLine("Opção inválida! Tente novamente.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro inesperado: {ex.Message}");
                }
            }
        }
    }
}
