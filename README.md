# Sistema de Gerenciamento de Estoque

Um sistema simples de gerenciamento de estoque desenvolvido em C#, que permite controlar produtos, quantidades e valores.

## Funcionalidades

- **Adicionar Produtos**: Cadastre novos produtos ou adicione unidades a produtos existentes
- **Remover Produtos**: Remova quantidades específicas de produtos do estoque
- **Listar Produtos**: Visualize todos os produtos com diferentes opções de ordenação
- **Buscar Produtos**: Encontre produtos específicos por nome ou palavra-chave

## Requisitos

- .NET SDK (recomendado .NET 6.0 ou superior)
- Ambiente capaz de executar aplicações console em C#

## Estrutura do Projeto

O sistema é composto por três classes principais:

1. **Program.cs**: Contém a interface de usuário e o menu principal
2. **Estoque.cs**: Implementa as operações de gerenciamento do estoque
3. **Produto.cs**: Define o modelo de produto com suas propriedades e validações

## Como Usar

### Compilação e Execução

```bash
dotnet build
dotnet run
```

### Menu de Opções

O sistema apresenta um menu interativo com as seguintes opções:

1. **Adicionar produto**: Insira nome, preço e quantidade
2. **Remover produto**: Especifique o nome e a quantidade a remover
3. **Listar produtos**: Visualize produtos ordenados por nome, preço, quantidade ou valor total
4. **Buscar produto**: Encontre produtos pelo nome ou parte dele
5. **Sair**: Encerra o programa

## Validações Implementadas

- Nomes de produtos não podem ser vazios
- Preços devem ser valores positivos
- Quantidades não podem ser negativas
- Proteção contra entradas de formato inválido

## Exemplo de Uso

1. Adicione alguns produtos ao estoque
2. Liste os produtos para visualizar o inventário atual
3. Remova algumas unidades quando necessário
4. Busque produtos específicos pelo nome

## Recursos Adicionais

- Cálculo automático do valor total de cada produto e do estoque
- Diferentes opções de ordenação na listagem
- Feedback detalhado sobre as operações realizadas
- Tratamento de exceções para maior robustez

---

Desenvolvido como parte de um projeto de estudo em C# e programação orientada a objetos.
