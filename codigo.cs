using System;

namespace Trabalho_1___Grafos
{
    public class Test
    {
        class Corte
        {
            public int qtdCabe�asCortadas { get; set; }
            public int qtdCabe�asNascidas { get; set; }
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
                    cortes[i].qtdCabe�asCortadas = int.Parse(linhaSplit[i]);
                }
                linha = Console.ReadLine();
                linhaSplit = linha.Split(' ');
                for (int i = 0; i < cortes.Length; i++)
                {
                    cortes[i].qtdCabe�asNascidas = int.Parse(linhaSplit[i]);
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

        static void Start(int qtdCabe�as, int passos)
        {
            for (int i = 0; i < cortes.Length; i++)
            {
                if (cortes[i].qtdCabe�asCortadas <= qtdCabe�as)
                    Mutilar(qtdCabe�as, i, passos + 1);
            }
        }

        static void Mutilar(int qtdCabe�as, int corte, int passos)
        {
            qtdCabe�as -= cortes[corte].qtdCabe�asCortadas;
            if (qtdCabe�as == 0)
            {
                if (passos < menorPasso)
                    menorPasso = passos;
            }
            else
            {
                qtdCabe�as += cortes[corte].qtdCabe�asNascidas;

                if (vet[qtdCabe�as] != 0 && vet[qtdCabe�as] <= passos)
                    return;
                else
                    vet[qtdCabe�as] = passos;

                if (qtdCabe�as >= 1000)
                    return;

                for (int i = 0; i < cortes.Length; i++)
                {
                    if (cortes[i].qtdCabe�asCortadas <= qtdCabe�as)
                        Mutilar(qtdCabe�as, i, passos + 1);
                }

            }

        }
    }
}