using Devs2Blu.ProjetosAula.OOP3.Main.Interfaces;
using Devs2Blu.ProjetosAula.OOP3.Main.Utils.Enums;
using Devs2Blu.ProjetosAula.OOP3.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.ProjetosAula.OOP3.Main.Cadastros
{
    public class CadastroRecepcionista : IMenuCadastro
    {
        public Int32 MenuCadastro()
        {
            Int32 opcao;

            Console.Clear();
            Console.WriteLine("----- Cadastro de Recepcionistas --------");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("----- 1- Lista de Recepcionistas --------");
            Console.WriteLine("----- 2- Cadastro de Recepcionistas -----");
            Console.WriteLine("----- 3- Alterar Recepcionistas ---------");
            Console.WriteLine("----- 4- Excluir Recepcionistas ---------");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("----- 0- Sair ---------------------------");
            Int32.TryParse(Console.ReadLine(), out opcao);
            return opcao;

        }

        public void Listar()
        {
            ListarRecepcionistas();
        }


        public void ListarRecepcionistas()
        {
            Console.Clear();

            foreach (var recepcionista in Program.Mock.ListaRecepcionistas)
            {
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine($"Código Recepcionista: {recepcionista.CodigoRecepcionista}");
                Console.WriteLine($"Nome: {recepcionista.Nome}");
                Console.WriteLine($"Setor: {recepcionista.Setor}");
                Console.WriteLine($"CPF: {recepcionista.CGCCPF}");
                Console.WriteLine("--------------------------------------------------------\n");
            }
            Console.ReadLine();
        }


        public void CadastrarRecepcionista(Recepcionista novoRecepcionista)
        {
            Program.Mock.ListaRecepcionistas.Add(novoRecepcionista);
        }
        
        public void Cadastrar()
        {


            Console.Clear();

            // Listar a entrada de dados aqui 
            Recepcionista novoRecepcionista = new Recepcionista(); // Aqui instancioamos um novo objeto Paciente 
            Random rd = new Random();
            
            
            
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine($"Cadastro de Recepcionistas");
            Console.WriteLine("-----------------------------------------");

            novoRecepcionista.Codigo = rd.Next(1, 300);
            Console.WriteLine($"Código: {novoRecepcionista.Codigo}");

            Console.WriteLine($"Insira o nome do recepcionista");
            novoRecepcionista.Nome = Console.ReadLine();

            Console.WriteLine($"Insira o CPF do recepcionista");
            novoRecepcionista.CGCCPF = Console.ReadLine();
            
            Console.WriteLine($"Insira qual o setor");
            novoRecepcionista.Setor = Console.ReadLine();


            novoRecepcionista.CodigoRecepcionista = rd.Next(1, 300);
            Console.WriteLine("Recepcionista Cadastrado com Sucesso!\n");

            CadastrarRecepcionista(novoRecepcionista);
            Console.ReadKey();



        }


        private void ListarRecepcionistasByCodeAndName()
        {
            foreach (Recepcionista recepcionista in Program.Mock.ListaRecepcionistas)
            {
                Console.Write($"| {recepcionista.CodigoRecepcionista} - {recepcionista.Nome} ");
            }
            Console.WriteLine("\n");
        }



        public void AlterarRecepcionista(Recepcionista recepcionista)
        {

            var rec = Program.Mock.ListaRecepcionistas.Find(r => r.CodigoRecepcionista == recepcionista.CodigoRecepcionista);
            int index = Program.Mock.ListaRecepcionistas.IndexOf(rec);
            Program.Mock.ListaRecepcionistas[index] = recepcionista;

        }
        public void Alterar()
        {
            Console.Clear();
            Recepcionista recepcionista;
            int codigoRecepcionista;

            Console.WriteLine("Informe o Recepcionista que Deseja Alterar:\n");
            ListarRecepcionistasByCodeAndName();

            Int32.TryParse(Console.ReadLine(), out codigoRecepcionista);

            recepcionista = Program.Mock.ListaRecepcionistas.Find(r => r.CodigoRecepcionista == codigoRecepcionista);

            const int NOME = 1, CPF = 2, SETOR = 3;
            int opcaoAlterar;
            bool alterar = true;

            do
            {
                Console.WriteLine($"Código Recepcionista: {recepcionista.Codigo}/{recepcionista.CodigoRecepcionista} | Nome: {recepcionista.Nome} | CPF: {recepcionista.CGCCPF} | Setor: {recepcionista.Setor}");
                Console.WriteLine("Qual campo deseja alterar?");
                Console.WriteLine("1 - Nome | 2 - CPF | 3 - Setor | 0 - SAIR"); //Ajustar o valor de saída 
                Int32.TryParse(Console.ReadLine(), out opcaoAlterar); 

                switch (opcaoAlterar)
                {
                    case NOME:
                        Console.WriteLine("Informe um novo nome:");
                        recepcionista.Nome = Console.ReadLine();
                        break;
                    case CPF:
                        Console.WriteLine("Informe um novo CPF:");
                        recepcionista.CGCCPF = Console.ReadLine();
                        break;
                    case SETOR:
                        Console.WriteLine("Informe o novo Setor:");
                        recepcionista.Setor = Console.ReadLine();
                        break;

                    default:
                        alterar = false;
                        break;
                }

                if (alterar)
                {
                    Console.Clear();
                    Console.WriteLine("Dado Alterado com Sucesso!");
                }
            } while (alterar);

            AlterarRecepcionista(recepcionista);


        }


        private void ExcluirRecepcionista(Recepcionista recepcionista)
        {

            Program.Mock.ListaRecepcionistas.Remove(recepcionista);
        }

        public void Excluir()
        {
            Console.Clear();
            Recepcionista recepcionista = new Recepcionista();
            int codRecepcionista;

            Console.WriteLine("Informe o Recepcionista que Deseja Excluir:\n");
            ListarRecepcionistasByCodeAndName();
            Int32.TryParse(Console.ReadLine(), out codRecepcionista);
            recepcionista = Program.Mock.ListaRecepcionistas.Find(r => r.CodigoRecepcionista == codRecepcionista);// Função Lambda
            Console.WriteLine($"Recepcionista Excluido: {recepcionista.CodigoRecepcionista}\n");
            Console.ReadKey();




            ExcluirRecepcionista(recepcionista);
        }
    }
}
