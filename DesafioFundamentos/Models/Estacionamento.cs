using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar: (Ex: ABC-1234 ou ABC1D23)");
            string placa = Console.ReadLine();
            
            if (ValidarPlaca(placa))
            {
                veiculos.Add(placa);
                Console.WriteLine($"Veículo {placa.ToUpper()} adicionado com sucesso!"); 
            }
            else
            {
                Console.WriteLine("Placa Inválida! Tente novamente.");
                AdicionarVeiculo();
            }
        }

        private static bool ValidarPlaca(string placa)
        {
            if (placa.Length > 8) { return false; }
            // validação da placa de acordo com padrão brasileiro ou padrão mercosul
            var placaNormal = new Regex("[a-zA-Z]{3}-[0-9]{4}");
            var placaMercosul = new Regex("[a-zA-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{2}");

            if (placaNormal.IsMatch(placa) || placaMercosul.IsMatch(placa))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover: (Ex: ABC-1234 ou ABC1D23)");
            string placa = Console.ReadLine();

            // verificar se a placa á válida
            if (ValidarPlaca(placa))
            {
                // verificar se o carro com essa placa está estacionado
                if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                    int horas = Convert.ToInt32(Console.ReadLine());
                    decimal valorTotal = precoInicial + precoPorHora * horas;

                    veiculos.Remove(placa);

                    Console.WriteLine($"O veículo {placa.ToUpper()} foi removido e o preço total foi de: R$ {valorTotal}");
                }
                else
                {
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui.");
                }
            }
            else
            {
                Console.WriteLine("Placa Inválida! Tente novamente.");
                RemoverVeiculo();
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach(var veiculo in veiculos)
                {
                    Console.WriteLine($"Placa do veículo: {veiculo.ToUpper()}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
