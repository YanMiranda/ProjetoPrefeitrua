using System;
using System.Collections.Generic;
using System.Collections;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(String[] args)
        {

            byte opcao = 0;
            do 
            {
                Console.WriteLine("+----------------------------------------------------+");
                Console.WriteLine("|1-                 Cadastro morador.                |");
                Console.WriteLine("|2-             Imprime lista de moradores           |");
                Console.WriteLine("|3-              Imprime fila de espera              |");
                Console.WriteLine("|4-               Pesquisa de morador                |");
                Console.WriteLine("|5-               Desistência/exclusão               |");
                Console.WriteLine("|6-                     Sorteio                      |");
                Console.WriteLine("|7-               Verifica um numero.                |");
                Console.WriteLine("|9-                Sair do programa                  |");
                Console.WriteLine("+----------------------------------------------------+");
                Console.WriteLine("   Digite apenas o numero da funcionalidade desejada: ");
                opcao = byte.Parse(Console.ReadLine());
                switch (opcao) 
                { 
                    case 1:
                    CadastroMorador();
                    break;
                }

            }while(opcao == 9);      
        }

        public static void CadastroMorador() 
        { 
            char flag;
            HashSet<Morador> M1 = new HashSet<Morador>();
            do
            {
                
                Morador MRD = new Morador();

                Console.WriteLine("Qual o nome do morador:");
                MRD.SetNome(Console.ReadLine());

                Console.WriteLine("Qual o endereço do morador:");
                MRD.SetEndereco(Console.ReadLine());

                Console.WriteLine("Qual o tel do morador:");
                MRD.SetTel(long.Parse(Console.ReadLine()));

                Console.WriteLine("Qual o numero de dependentes do morador:");
                MRD.SetDependentes(byte.Parse(Console.ReadLine()));

                Console.WriteLine("Qual a renda do morador:");
                MRD.SetRenda(double.Parse(Console.ReadLine()));

                Console.WriteLine("Qual o CPF do morador:");
                MRD.SetCpf(long.Parse(Console.ReadLine()));

                if(MRD.GetRenda() <= 1212)
                {
                    M1.Add(MRD);
                }
                else {
                    Console.WriteLine("O Morador não é apto a participar do programa. Possui renda maior que" +
                        " 1 salário minimo");
                }

                Console.WriteLine("Deseja inserir outro morador? (S/N)");
                flag = char.Parse(Console.ReadLine());


            } while (flag == 's' || flag == 'S');

            Console.WriteLine("Insira o cpf para pesquisa: ");
            long busca = long.Parse(Console.ReadLine());

            foreach(Morador m in M1)
            {
                if (busca == m.GetCpf())
                    Console.WriteLine(m.ImprimeTudo());
                else
                    Console.WriteLine("Morador inexistente.");
            }
            Console.ReadKey();

        }

    }
}