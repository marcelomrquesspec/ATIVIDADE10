using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade10.Models
{
    public class Garagem
    {
        public string NomeAeroporto { get; set; }
        public Stack<Veiculo> Estacionamento { get; private set; }

        public Garagem() : this("")
        {

        }
        public Garagem(string nomeAeroporto)
        {
            NomeAeroporto = nomeAeroporto;
            Estacionamento = new Stack<Veiculo>();
        }

        public Veiculo SairVeiculo()
        {
            if (!HasVeiculos())
                return null;

            return Estacionamento.Pop();
        }
        public void EstacionarVeiculo(Veiculo veiculo)
        {
            Estacionamento.Push(veiculo);
        }
        public bool HasVeiculos() => Estacionamento.Count() > 0;

        public override bool Equals(object obj)
        {
            return NomeAeroporto.Equals(((Garagem)obj).NomeAeroporto);
        }

        public void EsvaziarEstacionamento()
        {
            Estacionamento = new Stack<Veiculo>();
        }
    }
}
