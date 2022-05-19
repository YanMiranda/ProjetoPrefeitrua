using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Runtime;

namespace ConsoleApp1
{
    public class Program
    {
        static HashSet<Morador> M1 = new HashSet<Morador>();
        static HashSet<Morador> M2 = new HashSet<Morador>();
        static HashSet<Morador> EsperaRendaMinima = new HashSet<Morador>();
        static HashSet<Morador> EsperaRendaMaxima = new HashSet<Morador>();
        static List<long> sort = new List<long>();
        
        static List<long> sort2 = new List<long>();
        static Morador Tamanho = new Morador();


        public static void Main(String[] args)
        {

            byte opcao = 0;

            Console.WriteLine("Antes de comerçar o programa escolha as proporções do trabalho:");
            Console.WriteLine("Qual será o tamanho da primeira lista de moradores?");
            Tamanho.SetTamanhoM1(int.Parse(Console.ReadLine()));

            Console.WriteLine("Qual será o tamanho da lista de espera?");
            Tamanho.SetTamanhoM2(int.Parse(Console.ReadLine()));

            do
            {
                Console.WriteLine("+----------------------------------------------------+");
                Console.WriteLine("|1-                 Cadastro morador.                |");
                Console.WriteLine("|2-             Imprime lista de moradores           |");
                Console.WriteLine("|3-              Imprime fila de espera              |");
                Console.WriteLine("|4-               Pesquisa de morador                |");
                Console.WriteLine("|5-               Desistência/exclusão               |");
                Console.WriteLine("|6-                     Sorteio                      |");
                Console.WriteLine("|7-                                                  |");
                Console.WriteLine("|9-                Sair do programa                  |");
                Console.WriteLine("+----------------------------------------------------+");
                Console.WriteLine("   Digite apenas o numero da funcionalidade desejada: ");
                opcao = byte.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        CadastroMorador();
                        break;

                    case 2:
                        ImprimeMoradores();
                        break;

                    case 3:
                        ImprimeFilaEspera();
                        break;

                    case 4:
                        ConsultaCpf();
                        break;

                    case 5:
                        Desistencia();
                        break;

                    case 6:
                        Sorteio();
                        break;

                }

            } while (opcao != 9);
        }


        private static void CadastroMorador()
        {
            byte i = 0;
            byte j = 0;
            char flag;
            char novoMorador;

            do
            {
                Morador MRD = new Morador();

                Console.WriteLine("Qual o nome do morador:");
                MRD.SetNome(Console.ReadLine());

                Console.WriteLine("Qual o endereço do morador:");
                MRD.SetEndereco(Console.ReadLine());

                Console.WriteLine("Qual o tel do morador com o (ddd):");
                MRD.SetTel(long.Parse(Console.ReadLine()));

                Console.WriteLine("Qual o numero de dependentes do morador:");
                MRD.SetDependentes(byte.Parse(Console.ReadLine()));

                Console.WriteLine("Qual a renda do morador:");
                MRD.SetRenda(double.Parse(Console.ReadLine()));

                Console.WriteLine("Qual o CPF do morador:");
                MRD.SetCpf(long.Parse(Console.ReadLine()));

                if (MRD.GetRenda() <= 1212)
                {
                    M1.Add(MRD);
                    Console.WriteLine("Morador adicionado a lista 1 de renda até " +
                    "um salário mínimo.");
                    sort.Add(MRD.GetCpf());
                }
                else if (MRD.GetRenda() > 1212 && MRD.GetRenda() <= 3636)
                {
                    M2.Add(MRD);
                    Console.WriteLine("Morador adicionado a lista 2 de renda até " +
                    "três salários mínimos.");
                    sort2.Add(MRD.GetCpf());
                }
                else
                {
                    Console.WriteLine("O Morador não se encaixa dentro de nenhuma" + "\n" +
                    "das listas por ter renda maior que o permitido.");
                }
                
                i++;
                if (i < Tamanho.GetTamanhoM1())
                {
                    Console.WriteLine("Deseja inserir outro morador? (S/N)");
                    flag = char.Parse(Console.ReadLine());
                }
                else
                    break;

            } while (flag == 'S' || flag == 's');
            if (i == Tamanho.GetTamanhoM1())
            {
                Console.WriteLine("A lista do sorteio está cheia. Novos moradores serão " +
                "cadastrados na fila de espera com limite de até três moradores.");
                Console.WriteLine("Se deseja adicionar mais moradores digite 's', se não digite 'n'.");
                novoMorador = char.Parse(Console.ReadLine());

                if (novoMorador == 'S' || novoMorador == 's')
                {
                    do
                    {
                        Morador MRDE = new Morador();

                        Console.WriteLine("Qual o nome do morador:");
                        MRDE.SetNome(Console.ReadLine());

                        Console.WriteLine("Qual o endereço do morador:");
                        MRDE.SetEndereco(Console.ReadLine());

                        Console.WriteLine("Qual o tel do morador com o (ddd):");
                        MRDE.SetTel(long.Parse(Console.ReadLine()));

                        Console.WriteLine("Qual o numero de dependentes do morador:");
                        MRDE.SetDependentes(byte.Parse(Console.ReadLine()));

                        Console.WriteLine("Qual a renda do morador:");
                        MRDE.SetRenda(double.Parse(Console.ReadLine()));

                        Console.WriteLine("Qual o CPF do morador:");
                        MRDE.SetCpf(long.Parse(Console.ReadLine()));

                        if (MRDE.GetRenda() <= 1212)
                        {
                            EsperaRendaMinima.Add(MRDE);
                            Console.WriteLine("Morador adicionado a lista 1 de renda até " +
                            "um salário mínimo.");
                        }
                        else if (MRDE.GetRenda() > 1212 && MRDE.GetRenda() <= 3636)
                        {
                            EsperaRendaMaxima.Add(MRDE);
                            Console.WriteLine("Morador adicionado a lista 2 de renda até " +
                            "três salários mínimos.");
                        }
                        else
                        {
                            Console.WriteLine("O Morador não se encaixa dentro de nenhuma" + "\n" +
                            "das listas por ter renda maior que o permitido.");
                        }

                        j++;

                        if (j <
                         Tamanho.GetTamanhoM2())
                        {
                            Console.WriteLine("Deseja inserir outro morador na fila de espera? (S/N)");
                            flag = char.Parse(Console.ReadLine());
                        }
                        else
                            break;


                    } while (flag == 's' || flag == 'S');

                    Console.WriteLine("Infelizmente não temos mais vagas.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Cadastro finalizados. =)");
                Console.WriteLine("Aperte qualquer tecla para voltar ao menu.");
                Console.ReadKey();
            }

        }

        private static void ImprimeMoradores()
        {
            foreach (Morador m in M1)
            {
                Console.WriteLine(m.ImprimeTudo());
            }
            foreach (Morador m in M2)
            {
                Console.WriteLine(m.ImprimeTudo());
            }
            Console.WriteLine("Aperte qualquer tecla para voltar ao menu.");
            Console.ReadKey();
        }

        private static void ImprimeFilaEspera()
        {
            foreach (Morador m in EsperaRendaMaxima)
            {
                Console.WriteLine(m.ImprimeTudo());
            }
            foreach (Morador m in EsperaRendaMinima)
            {
                Console.WriteLine(m.ImprimeTudo());
            }
            Console.WriteLine("Aperte qualquer tecla para voltar ao menu.");
            Console.ReadKey();
        }

        private static void ConsultaCpf()
        {
            Console.WriteLine("Insira o cpf para pesquisa: ");
            long busca = long.Parse(Console.ReadLine());

            foreach (Morador m in M1)
            {
                if (busca == m.GetCpf())
                    Console.WriteLine(m.ImprimeTudo());
                else
                    Console.WriteLine("Morador inexistente.");
            }
            foreach (Morador m in M2)
            {
                if (busca == m.GetCpf())
                    Console.WriteLine(m.ImprimeTudo());
                else
                    Console.WriteLine("Morador inexistente.");
            }
            foreach (Morador m in EsperaRendaMaxima)
            {
                if (busca == m.GetCpf())
                    Console.WriteLine(m.ImprimeTudo());
                else
                    Console.WriteLine("Morador inexistente.");
            }
            foreach (Morador m in EsperaRendaMinima)
            {
                if (busca == m.GetCpf())
                    Console.WriteLine(m.ImprimeTudo());
                else
                    Console.WriteLine("Morador inexistente.");
            }
            Console.WriteLine("Aperte qualquer tecla para voltar ao menu.");
            Console.ReadKey();
        }

        private static void Desistencia()
        {
            HashSet<Morador> aux1 = M1;
            HashSet<Morador> aux2 = M2;
            HashSet<Morador> filaAux = EsperaRendaMaxima;
            Console.WriteLine("Insira o CPF para pesquisa de exclusão: ");
            long busca = long.Parse(Console.ReadLine());
            char confirmacxclui = ' ';


            foreach (Morador m in M1)
            {
                if (busca == m.GetCpf())
                {
                    Console.WriteLine(m.ImprimeTudo());
                    Console.WriteLine("Realmente deseja excluir esse morador? S/N");
                    confirmacxclui = char.Parse(Console.ReadLine());
                    if (confirmacxclui == 's' || confirmacxclui == 'S')
                    {
                        foreach (Morador m1 in aux1)
                        {
                            if (busca == m.GetCpf())
                            {
                                M1.Remove(m1);
                            }
                        }
                        /*foreach(Morador novo in filaAux)
                        {
                               M1.Add(novo);
                             EsperaRendaMaxima.Remove(novo); 
                        }*/
                    }
                }
                else
                    Console.WriteLine("Morador inexistente.");
            }
            foreach (Morador m in M2)
            {
                if (busca == m.GetCpf())
                {
                    Console.WriteLine(m.ImprimeTudo());
                    Console.WriteLine("Realmente deseja excluir esse morador? S/N");
                    confirmacxclui = char.Parse(Console.ReadLine());
                    if (confirmacxclui == 's' || confirmacxclui == 'S')
                    {
                        foreach (Morador m2 in aux2)
                        {
                            if (busca == m.GetCpf())
                            {
                                M2.Remove(m2);
                            }
                        }
                    }
                }
                else
                    Console.WriteLine("Morador inexistente.");
            }

        }
        private static void Sorteio()
        {

            Random Sorteio1 = new Random();
            int aux = Sorteio1.Next(sort.Count);
            int aux2 = Sorteio1.Next(sort2.Count);
            Console.WriteLine(sort[aux]);
            Console.WriteLine(sort2[aux2]);
            Console.WriteLine("PARABENS!!");
             foreach (Morador m in M1)
            {
                if (sort[aux] == m.GetCpf())
                    Console.WriteLine(m.ImprimeTudo());
                else
                    Console.WriteLine("Morador inexistente.");
            }
            foreach (Morador m in M2)
            {
                if (sort[aux2] == m.GetCpf())
                    Console.WriteLine(m.ImprimeTudo());
                else
                    Console.WriteLine("Morador inexistente.");
            }
            Console.ReadKey();
        }


    }
}


