using Atividade10.Models;
using Atividade10.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade10
{
    public class Seletor
    {
        private Jornada _jornada;

        public Seletor(Jornada jornada)
        {
            _jornada = jornada;
        }

        public int EscolherOpcao()
        {
            int opcao = 1;

            do
            {
                Console.WriteLine("0\tFinalizar\r\n1\tCadastrar veículo\r\n2\tCadastrar garagem\r\n3\tIniciar jornada\r\n4\tEncerrar jornada\r\n5\tLiberar viagem de uma determinada origem para um determinado destino\r\n6\tListar veículos em determinada garagem (informando a quantidade de veículos e seu potencial de transporte)\r\n7\tInformar quantidade de viagens efetuadas de uma determinada origem para um determinado destino\r\n8\tListar viagens efetuadas de uma determinada origem para um determinado destino\r\n9\tInformar quantidade de passageiros transportados de uma determinada origem para um determinado destino\r\n");
                Console.Write("\nDigite a opção: ");
                opcao = int.Parse(Console.ReadLine());

                separador();

                try
                {
                    switch (opcao)
                    {
                        case (int)OpcoesEnum.Finalizar:
                            finalizar();
                            break;
                        case (int)OpcoesEnum.CadastrarVeiculo:
                            cadastrarVeiculo();
                            break;
                        case (int)OpcoesEnum.CadastrarGaragem:
                            cadastrarGaragem();
                            break;
                        case (int)OpcoesEnum.IniciarJornada:
                            iniciarJornada();
                            break;
                        case (int)OpcoesEnum.EncerrarJornada:
                            encerrarJornada();
                            break;
                        case (int)OpcoesEnum.LiberarViagem:
                            liberarViagem();
                            break;
                        case (int)OpcoesEnum.ListarVeiculos:
                            listarVeiculos();
                            break;
                        case (int)OpcoesEnum.InformarQtdViagens:
                            informarQtdViagens();
                            break;
                        case (int)OpcoesEnum.ListarViagens:
                            listarViagens();
                            break;
                        case (int)OpcoesEnum.InformarQtdPassageiros:
                            informarQtdPassageiros();
                            break;
                        default:
                            Console.WriteLine("\n\nopção invalida, por favor selecione um valor entre 0 e 9\n\n");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"\n\n{e.Message}\n");
                }

                separador();
            } while (opcao < 0 || opcao > 10);

            return opcao;
        }

        private void informarQtdPassageiros()
        {
            var origem = inputGaragem("Digite o nome do aeroportode de origem: ");
            var destino = inputGaragem("Digite o nome do aeroportode de destino: ");

            var qtdPassageiros = _jornada.QuantidadePassageiros(origem, destino);

            if (qtdPassageiros <= 0)
            {
                Console.WriteLine("\n\nNão houveram viagens desta origem para esse destino\n");
            }
            else
            {
                Console.WriteLine($"\n\nHouveram {qtdPassageiros} passageiros transportados {origem.NomeAeroporto} (origem) - {destino.NomeAeroporto} (destino)\n");
            }
        }

        private void listarViagens()
        {
            var origem = inputGaragem("Digite o nome do aeroportode de origem: ");
            var destino = inputGaragem("Digite o nome do aeroportode de destino: ");

            var viagens = _jornada.ViagensRealizadas(origem, destino);

            if (viagens.Count <= 0)
            {
                Console.WriteLine("\n\nNão houveram viagens desta origem para esse destino\n");
                return;
            }

            Console.WriteLine("\n\nLista viagens:\n");
            foreach (var viagem in viagens)
            {
                Console.WriteLine(viagem.ToString());
            }

        }

        private void informarQtdViagens()
        {
            var origem = inputGaragem("Digite o nome do aeroportode de origem: ");
            var destino = inputGaragem("Digite o nome do aeroportode de destino: ");

            var viagens = _jornada.ViagensRealizadas(origem, destino);

            if (viagens.Count <= 0)
            {
                Console.WriteLine("\n\nNão houveram viagens desta origem para esse destino\n");
                return;
            }

            Console.WriteLine($"\n\nForam realizadas {viagens.Count} viagens de {origem.NomeAeroporto} para {destino.NomeAeroporto}\n");
        }

        private void listarVeiculos()
        {
            var garagem = inputGaragem();

            var veiculos = _jornada.VeiculosEstacionados(garagem);

            if (veiculos.Count <= 0)
            {
                Console.WriteLine($"\n\nNão há veiculos na garagem {garagem.NomeAeroporto}\n");
                return;
            }

            Console.WriteLine("\n\nLista veiculos:\n");
            foreach (var veiculo in veiculos)
            {
                Console.WriteLine($"Placa: {veiculo.Placa} - Qtde lotação: {veiculo.QtdeLotacaoVeiculo}");
            }
        }

        private void liberarViagem()
        {
            var origem = inputGaragem("Digite o nome do aeroportode de origem: ");
            var destino = inputGaragem("Digite o nome do aeroportode de destino: ");

            Console.Write("Digite a quantidade da viagem: ");
            int qtdeLotacaoVeiculo = int.Parse(Console.ReadLine());

            _jornada.LiberarViagem(origem, destino, qtdeLotacaoVeiculo);
        }

        private void encerrarJornada()
        {
            var veiculosQtdePassageiros = _jornada.Encerrar();

            if (veiculosQtdePassageiros.Count <= 0)
            {
                Console.WriteLine("\n\nNão houveram viagens nesta jornada\n");
                return;
            }

            Console.WriteLine("\n\nLista veiculos e quantiade de passageiros\n");
            foreach (var item in veiculosQtdePassageiros)
            {
                Console.WriteLine($"Placa: {item.Key} - Qtde. passageiros: {item.Value}");
            }
        }

        private void iniciarJornada()
        {
            _jornada.Iniciar();
            Console.WriteLine("\n\nJornada diária iniciada\n");

        }

        private void cadastrarGaragem()
        {

            Garagem garagem = inputGaragem();

            _jornada.AdicionarGaragem(garagem);

            Console.WriteLine("\n\nGaragem cadastrado com sucesso!\n");

        }

        private void cadastrarVeiculo()
        {
            Veiculo veiculo = new Veiculo();

            Console.Write("Digite a placa do veiculo: ");
            veiculo.Placa = Console.ReadLine();

            Console.Write("Digite o nome do motorista do veiculo: ");
            veiculo.NomeMotorista = Console.ReadLine();

            Console.Write("Digite a quantidade de pessoas para a lotação do veiculo: ");
            veiculo.QtdeLotacaoVeiculo = int.Parse(Console.ReadLine());

            _jornada.AdicionarVeiculo(veiculo);

            Console.WriteLine("\n\nVeiculo cadastrado com sucesso!\n");

        }

        private void finalizar()
        {
            Console.WriteLine("Obrigado por usar o programa...");
            Console.WriteLine("Até a proxima :)");
            Console.ReadKey();
        }

        private Garagem inputGaragem(string mensagem = "Digite o nome do aeroporto: ")
        {
            Garagem garagem = new Garagem();

            Console.Write(mensagem);
            garagem.NomeAeroporto = Console.ReadLine();

            return garagem;
        }
        private void separador()
        {
            Console.WriteLine();
            for (int i = 0; i < 30; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine("\n");
        }

    }
}

