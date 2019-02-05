﻿using System;
using System.Threading;
using static System.Console;

namespace Atividade1
{
    class Aplicacao
    {
        public const decimal Juros = 0.6M;
        
        static void Main(string[] args)
        {
            int sum = 0;
            int id_contaCorrente = 1;
            int id_contaPoupanca = 1;

            Banco banco = new Banco();
            bool init = true;
            while (init)
            {
                MenuAgencia();
                int op = int.Parse(ReadLine());
                switch (op)
                {
                    case 1:
                        Agencia agencia = new Agencia();
                        sum++;
                        agencia.IdAgencia = sum;
                        banco.AdicionarAgencia(agencia);
                        break;
                    case 2:
                        Cliente cliente = new Cliente();
                        WriteLine("Tipo de conta?");
                        WriteLine("1-Conta Corrente, 2-Conta Poupança");

                        int tipo_conta = int.Parse(ReadLine());
                        if (tipo_conta == 1)
                        {
                            ContaCorrente cc = new ContaCorrente(cliente.Nome);
                            if(banco.listaIdAgencias() == false)
                            { break; }
                            
                            Write("\nSelecione a Agência: ");

                            int numAgencia = int.Parse(ReadLine());

                            Agencia ag = banco.buscaAgencia(numAgencia);
                            if (ag != null)
                            {
                                cc.Id = id_contaCorrente;
                                ag.addContaCorrente(cc);
                                id_contaCorrente++;
                            }
                            else
                            {
                                WriteLine("Dados errado, tente novamente.");
                            }

                        }
                        else if (tipo_conta == 2)
                        {
                            ContaPoupanca cp = new ContaPoupanca(Juros, DateTime.Now, cliente.Nome);


                            if (banco.listaIdAgencias() == false)
                            { break; }

                            Write("\nSelecione a Agência: ");
                            int numAgencia = int.Parse(ReadLine());

                            Agencia ag = banco.buscaAgencia(numAgencia);
                            if (ag != null)
                            {

                                cp.Id = id_contaPoupanca;
                                ag.addContaPoupanca(cp);
                                id_contaPoupanca++;
                            }
                            else
                            {
                                WriteLine("Dados errado, tente novamente.");
                            }

                        }
                        break;
                    case 3:
                        Solicitacao solicitacao = new Solicitacao();
                        solicitacao.realizarSolicitacao(banco);
                        break;
                    case 4:
                        banco.listaIdAgencias();
                        break;
                    case 5:
                        Console.Clear();
                        break;
                    case 0:
                        init = false;
                        break;
                    default:
                        WriteLine("Comando Inválido");
                        break;

                }


            }
        }

        public static void MenuAgencia()
        {
            WriteLine("Banco TOGETHER");
            WriteLine("1 - Cadastrar Agência  ");
            WriteLine("2 - Criar Conta ");
            WriteLine("3 - Abrir uma Sessão ");
            WriteLine("4 - Listar agências ");
            WriteLine("5 - Limpar tela");
            WriteLine("0 - Sair");
        }



    }
}
