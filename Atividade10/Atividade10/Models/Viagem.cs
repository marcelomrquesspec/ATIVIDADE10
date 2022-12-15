using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade10.Models
{
    public class Viagem
    {
        public Garagem Origem { get; set; }
        public Garagem Destino { get; set; }
        public DateTime DataViagem { get; private set; }
        public Veiculo Veiculo { get; private set; }
        public int QtdePassageiros { get; set; }

        public Viagem(Garagem origem, Garagem destino, int qtdePassageiros)
        {
            Origem = origem;
            Destino = destino;
            QtdePassageiros = qtdePassageiros;
        }


        public bool RealizarViagem()
        {
            DataViagem = DateTime.Now;
            var veiculo = Origem.SairVeiculo();

            if (veiculo == null)
                return false;

            Destino.EstacionarVeiculo(veiculo);
            DataViagem = DateTime.Now;

            return true;
        }

        public override string ToString()
        {
            return $"{Origem.NomeAeroporto} (origem) - {Destino.NomeAeroporto} (destino) - {QtdePassageiros} passageiros - {DataViagem.ToString("dd/MM/yy HH:mm:ss")}";
        }
    }
}
