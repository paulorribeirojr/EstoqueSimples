using System.Globalization;

namespace EstoqueSimples
{
    class Produto
    {
        private string _nome;
        private double _preco;
        private int _quant;
        
        public Produto(string nome, double preco, int quant)
        {
            Nome = nome;
            Preco = preco;
            Quant = quant;
        }

        public string Nome
        {
            get => _nome;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _nome = value;                
                else
                    throw new ArgumentException("Atenção! O nome do produto é obrigatório.");
            }
        }
        
        public double Preco
        {
            get => _preco;
            set
            {
                if (value > 0)
                    _preco = value;
                else
                    throw new ArgumentException("Atenção! O valor do produto precisa ser maior que zero.");
            }
        }
        
        public int Quant
        {
            get => _quant;
            set
            {
                if (value >= 0)
                    _quant = value;
                else
                    throw new ArgumentException("Atenção! A quantidade do produto não pode ser negativa.");
            }
        }

        public double ValorTotalEmEstoque()
        {
            return Preco * Quant;
        }

        public override string ToString()
        {
            return Nome
                + " | $ "
                + Preco.ToString("F2", CultureInfo.InvariantCulture)
                +" | "
                +Quant
                +" em estoque | Valor Total: $ "
                + ValorTotalEmEstoque().ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
