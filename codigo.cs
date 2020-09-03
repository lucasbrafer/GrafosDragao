using System;

namespace Trabalho_1___Grafos
{
    public class Test
    {
        class Corte
        {
            public int qtdCabeçasCortadas { get; set; }
            public int qtdCabeçasNascidas { get; set; }
        }

        static int[] vet;
        static Corte[] cortes;
        static int menorPasso;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string aux = "";
            while (n > 0)
            {

                menorPasso = int.MaxValue;
                vet = new int[2000];
                for (int i = 0; i < vet.Length; i++)
                {
                    vet[i] = 0;
                }

                cortes = new Corte[n];
                for (int i = 0; i < cortes.Length; i++)
                {
                    cortes[i] = new Corte();
                }

                string linha = Console.ReadLine();
                string[] linhaSplit = linha.Split(' ');
                for (int i = 0; i < cortes.Length; i++)
                {
                    cortes[i].qtdCabeçasCortadas = int.Parse(linhaSplit[i]);
                }
                linha = Console.ReadLine();
                linhaSplit = linha.Split(' ');
                for (int i = 0; i < cortes.Length; i++)
                {
                    cortes[i].qtdCabeçasNascidas = int.Parse(linhaSplit[i]);
                }

                Start(100, 0);

                if (menorPasso != int.MaxValue)
                {
                    aux += Convert.ToString(menorPasso) + " ";
                }
                else
                {
                    aux += "-1 ";
                }


                n = int.Parse(Console.ReadLine());
            }
            string[] resp = aux.Split(' ');
            for (int i = 0; i < resp.Length; i++)
            {
                if (resp[i] == "-1")
                    Console.WriteLine("cavaleiro morreu");
                else
                    Console.WriteLine(resp[i]);
            }
        }

        static void Start(int qtdCabeças, int passos)
        {
            for (int i = 0; i < cortes.Length; i++)
            {
                if (cortes[i].qtdCabeçasCortadas <= qtdCabeças)
                    Mutilar(qtdCabeças, i, passos + 1);
            }
        }

        static void Mutilar(int qtdCabeças, int corte, int passos)
        {
            qtdCabeças -= cortes[corte].qtdCabeçasCortadas;
            if (qtdCabeças == 0)
            {
                if (passos < menorPasso)
                    menorPasso = passos;
            }
            else
            {
                qtdCabeças += cortes[corte].qtdCabeçasNascidas;

                if (vet[qtdCabeças] != 0 && vet[qtdCabeças] <= passos)
                    return;
                else
                    vet[qtdCabeças] = passos;

                if (qtdCabeças >= 1000)
                    return;

                for (int i = 0; i < cortes.Length; i++)
                {
                    if (cortes[i].qtdCabeçasCortadas <= qtdCabeças)
                        Mutilar(qtdCabeças, i, passos + 1);
                }

            }

        }
    }
}