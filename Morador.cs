using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;



namespace ConsoleApp1
{
    internal class Morador
    {
        private string nome;
        private long cpf; 
        private long tel;
        private double renda; 
        private byte dependentes; 
        private string endereco;
        private int tamanhoM1;
        private int tamanhoM2;
        public int GetTamanhoM1()
        {
            return tamanhoM1;
        }
        public int SetTamanhoM1(int t1) => tamanhoM1 = t1;
        public int GetTamanhoM2()
        {
            return tamanhoM2;
        }
        public int SetTamanhoM2(int t2) => tamanhoM2 = t2;
        public void SetNome(string n)
        {
            nome = n;
        }
        public long GetCpf()
        {
            return cpf;
        }
        public void SetCpf(long c)
        {
            cpf = c;
        }
        public long GetTel()
        {
            return tel;
        }
        public void SetTel(long t)
        {

            if (t > 10000000000)
                tel = t;

        }
        public double GetRenda()
        {
            return renda;
        }
        public void SetRenda(double r)
        {
            if (r > 0)
                renda = r;
        }
        public byte GetDependentes()
        {
            return dependentes;
        }
        public void SetDependentes(byte d)
        {
            if (d > 0)
                dependentes = d;
        }
        public string GetEndereco()
        {
            return endereco;
        }
        public void SetEndereco(string e)
        {

            endereco = e;

        }

        public string ImprimeTudo()
        {
            return "Morador: "+ nome+"\n"+"CPF: "+cpf+"\n"+
            "Tel: "+tel+"\n"+
            "Endereço: "+endereco+"\n"+
            "Dependentes: "+dependentes+"\n"+
            "Renda: "+renda+"\n\n";

        }

    }
}