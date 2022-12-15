using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade10.Models
{
    public class Veiculo
    {
        public string Placa { get; set; }
        public string NomeMotorista { get; set; }
        public int QtdeLotacaoVeiculo { get; set; }

        public Veiculo()
            : this("", "", 0)
        {

        }
        public Veiculo(string placa, string nomeMotorista, int qtdeLotacaoVeiculo)
        {
            Placa = placa;
            NomeMotorista = nomeMotorista;
            QtdeLotacaoVeiculo = qtdeLotacaoVeiculo;
        }

        public override string ToString()
        {
            return $"{Placa} - {NomeMotorista:20} - {QtdeLotacaoVeiculo}";
        }
        public override bool Equals(object obj)
        {
            return Placa.Equals(((Veiculo)obj).Placa);
        }
    }
}
