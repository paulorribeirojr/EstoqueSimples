using EstoqueSimples;
using System;
using System.Globalization;

namespace Principal
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continuar = true;
            Estoque estoque = new Estoque();

            Console.WriteLine("=== SISTEMA DE GERENCIAMENTO DE ESTOQUE ===");

            while (continuar)
            {
                Console.WriteLine("\n============ MENU PRINCIPAL ============");
                Console.WriteLine("1 - Adicionar produto");
                Console.WriteLine("2 - Remover produto");
                Console.WriteLine("3 - Listar produtos");
                Console.WriteLine("4 - Buscar produto");
                Console.WriteLine("5 - Sair");
                Console.Write("\nEscolha uma opção: ");

                string opcao = Console.ReadLine();
                Console.WriteLine();

                try
                {
                    switch (opcao)
                    {
                        case "1":
                            AdicionarProduto(estoque);
                            break;
                        case "2":
                            RemoverProduto(estoque);
                            break;
                        case "3":
                            ListarProdutos(estoque);
                            break;
                        case "4":
                            BuscarProduto(estoque);
                            break;
                        case "5":
                            Console.WriteLine("Obrigado por utilizar o Sistema de Estoque!");
                            continuar = false;
                            break;
                        default:
                            Console.WriteLine("Opção inválida! Tente novamente.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Erro: Formato de entrada inválido. Verifique se você digitou números corretamente.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Erro de validação: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro inesperado: {ex.Message}");
                }
            }
        }

        private static void AdicionarProduto(Estoque estoque)
        {
            Console.WriteLine("=== ADICIONAR PRODUTO ===");

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            double preco = 0;
            bool precoValido = false;
            while (!precoValido)
            {
                Console.Write("Preço: ");
                precoValido = double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out preco);
                if (!precoValido)
                    Console.WriteLine("Preço inválido! Digite um número válido.");
            }

            int quantidade = 0;
            bool quantValida = false;
            while (!quantValida)
            {
                Console.Write("Quantidade: ");
                quantValida = int.TryParse(Console.ReadLine(), out quantidade);
                if (!quantValida)
                    Console.WriteLine("Quantidade inválida! Digite um número inteiro.");
            }

            estoque.AdicionarProduto(nome, preco, quantidade);
        }

        private static void RemoverProduto(Estoque estoque)
        {
            Console.WriteLine("=== REMOVER PRODUTO ===");

            Console.Write("Nome do produto: ");
            string nome = Console.ReadLine();

            int quantidade = 0;
            bool quantValida = false;
            while (!quantValida)
            {
                Console.Write("Quantidade a remover: ");
                quantValida = int.TryParse(Console.ReadLine(), out quantidade);
                if (!quantValida)
                    Console.WriteLine("Quantidade inválida! Digite um número inteiro.");
            }

            estoque.RemoverProduto(nome, quantidade);
        }

        private static void ListarProdutos(Estoque estoque)
        {
            Console.WriteLine("=== LISTAR PRODUTOS ===");
            Console.WriteLine("Opções de ordenação:");
            Console.WriteLine("1 - Por nome");
            Console.WriteLine("2 - Por preço");
            Console.WriteLine("3 - Por quantidade");
            Console.WriteLine("4 - Por valor total");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();
            string criterio;

            switch (opcao)
            {
                case "1":
                    criterio = "nome";
                    break;
                case "2":
                    criterio = "preco";
                    break;
                case "3":
                    criterio = "quantidade";
                    break;
                case "4":
                    criterio = "valor";
                    break;
                default:
                    Console.WriteLine("Opção inválida! Usando ordenação padrão (nome).");
                    criterio = "nome";
                    break;
            }

            estoque.ListarProdutos(criterio);
        }

        private static void BuscarProduto(Estoque estoque)
        {
            Console.WriteLine("=== BUSCAR PRODUTO ===");
            Console.Write("Digite o nome (ou parte do nome) do produto: ");
            string termo = Console.ReadLine();

            estoque.BuscarProduto(termo);
        }
    }
}