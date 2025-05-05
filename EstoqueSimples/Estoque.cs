using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace EstoqueSimples
{
    class Estoque
    {
        private List<Produto> produtos = new List<Produto>();

        public void AdicionarProduto(string nome, double preco, int quantidade)
        {
            // A validação detalhada já é feita no construtor de Produto
            Produto prodExistente = produtos.Find(p => p.Nome.ToLower() == nome.ToLower());
            if (prodExistente != null)
            {
                prodExistente.Quant += quantidade;
                Console.WriteLine($"\nForam adicionadas {quantidade} unidades ao produto '{nome}'.");
                Console.WriteLine($"Total atual: {prodExistente.Quant} unidades.");
            }
            else
            {
                Produto prodNovo = new Produto(nome, preco, quantidade);
                produtos.Add(prodNovo);
                Console.WriteLine($"\nProduto '{nome}' adicionado ao estoque com {quantidade} unidades.");
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
                        Console.WriteLine($"O produto '{nome}' foi completamente removido do estoque.");
                    }
                    else
                    {
                        Console.WriteLine($"Restam {prodRemover.Quant} unidades em estoque.");
                    }
                }
                else
                {
                    Console.WriteLine($"\nNão há {quantidade} unidades disponíveis de '{nome}'.");
                    Console.WriteLine($"Quantidade disponível: {prodRemover.Quant} unidades.");
                }
            }
            else
            {
                Console.WriteLine($"\nProduto '{nome}' não encontrado no estoque!");
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
                    Console.WriteLine("\n=== PRODUTOS ORDENADOS POR NOME ===");
                    break;
                case "preço":
                case "preco":
                    lista = produtos.OrderBy(p => p.Preco).ToList();
                    Console.WriteLine("\n=== PRODUTOS ORDENADOS POR PREÇO ===");
                    break;
                case "quantidade":
                    lista = produtos.OrderByDescending(p => p.Quant).ToList();
                    Console.WriteLine("\n=== PRODUTOS ORDENADOS POR QUANTIDADE ===");
                    break;
                case "valor":
                    lista = produtos.OrderByDescending(p => p.ValorTotalEmEstoque()).ToList();
                    Console.WriteLine("\n=== PRODUTOS ORDENADOS POR VALOR TOTAL ===");
                    break;
                default:
                    Console.WriteLine($"\nCritério '{criterio}' inválido! Exibindo em ordem alfabética.");
                    lista = produtos.OrderBy(p => p.Nome).ToList();
                    break;
            }

            // Desenha uma linha horizontal
            string linha = new string('-', 80);
            Console.WriteLine(linha);

            // Lista os produtos
            foreach (Produto p in lista)
            {
                Console.WriteLine(p);
                Console.WriteLine(linha);
            }

            // Resumo
            double valorTotalEstoque = produtos.Sum(p => p.ValorTotalEmEstoque());
            int totalItens = produtos.Sum(p => p.Quant);
            Console.WriteLine($"RESUMO: {produtos.Count} produtos | {totalItens} itens | Valor total: $ {valorTotalEstoque.ToString("F2", CultureInfo.InvariantCulture)}");
        }

        public void BuscarProduto(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("\nNome de busca inválido!");
                return;
            }

            var resultados = produtos.FindAll(p => p.Nome.ToLower().Contains(nome.ToLower()));

            if (resultados.Count == 0)
            {
                Console.WriteLine($"\nNenhum produto encontrado com o termo '{nome}'.");
                return;
            }

            Console.WriteLine($"\n=== {resultados.Count} PRODUTO(S) ENCONTRADO(S) ===");
            string linha = new string('-', 80);
            Console.WriteLine(linha);

            foreach (var produto in resultados)
            {
                Console.WriteLine(produto);
                Console.WriteLine(linha);
            }
        }
    }
}