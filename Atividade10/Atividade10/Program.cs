using Atividade10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var jornada = new Jornada();

            var seletor = new Seletor(jornada);

            int opcao = -1;
            while (opcao != 0)
            {
                opcao = seletor.EscolherOpcao();
            }

        }
    }
}

