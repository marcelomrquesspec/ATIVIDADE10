using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade10.Models
{
    public class Jornada
    {
        public List<Viagem> Viagens { get; set; }
        public bool? Encerrada { get; private set; }

        public List<Veiculo> Veiculos { get; private set; }
        public List<Garagem> Garagens { get; private set; }

        public Jornada()
        {
            Viagens = new List<Viagem>();
            Encerrada = null;

            Veiculos = new List<Veiculo>();
            Garagens = new List<Garagem>();
        }

        public void LiberarViagem(Garagem origem, Garagem destino, int qtdePassageiros)
        {
            var newViagem = new Viagem(origem, destino, qtdePassageiros);

            newViagem.RealizarViagem();

            Viagens.Add(newViagem);
        }
        public int QuantidadePassageiros(Garagem origem, Garagem destino)
        {
            var viagens = ViagensRealizadas(origem, destino);

            var qtdePessoasPorViagem = viagens.Select(v => v.QtdePassageiros);

            return qtdePessoasPorViagem.Sum();
        }
        public List<Viagem> ViagensRealizadas(Garagem origem, Garagem destino)
        {
            var viagens = Viagens.Where(v => v.Origem.Equals(origem) && v.Destino.Equals(destino)).ToList();

            return viagens;
        }
        public Dictionary<string, int> Encerrar()
        {
            var veiculosQtdePassageiros = new Dictionary<string, int>();

            foreach (var veiculo in Veiculos)
            {
                var qtdPassageirosPorViagem = Viagens
                        .Where(v => v.Veiculo.Equals(veiculo))
                        .Select(v => v.QtdePassageiros);

                veiculosQtdePassageiros.Add(veiculo.Placa, qtdPassageirosPorViagem.Sum());
            }
            

            Encerrada = true;
            Viagens = new List<Viagem>();

            foreach (var garagem in Garagens)
            {
                garagem.EsvaziarEstacionamento();
            }

            return veiculosQtdePassageiros;
        }
        public void Iniciar()
        {

            int qtdGaragens = Garagens.Count;
            int indexGaragem = 0;

            if (qtdGaragens <= 0)
                throw new Exception("Não é possivel iniciar a jornada, pois não há garagens cadastradas");

            if (Veiculos.Count <= 0)
                throw new Exception("Não é possivel iniciar a jornada, pois não há veiculos cadastrados");


            foreach (var veiculo in Veiculos)
            {
                Garagens[indexGaragem].EstacionarVeiculo(veiculo);

                if (indexGaragem + 1 >= qtdGaragens)
                    indexGaragem = 0;
                else
                    indexGaragem++;
            }

            Encerrada = false;
        }

        public void AdicionarVeiculo(Veiculo veiculo)
        {
            if (Encerrada.HasValue && !(bool)Encerrada)
                throw new Exception("Não é possivel cadastrar veiculo, pois a jornada diária foi iniciada");

            Veiculos.Add(veiculo);
        }

        public void AdicionarGaragem(Garagem garagem)
        {
            if (Encerrada.HasValue && !(bool)Encerrada)
                throw new Exception("Não é possivel cadastrar a garagem, pois a jornada diária foi iniciada");

            Garagens.Add(garagem);
        }

        public List<Veiculo> VeiculosEstacionados(Garagem garagem)
        {
            var garagemPesquisa = Garagens.FirstOrDefault(g => g.Equals(garagem));
            
            if (garagemPesquisa == null)
                throw new Exception("Garagem não cadastrada.");

            return garagemPesquisa.Estacionamento.ToList();
        }
    }
}
