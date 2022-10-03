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
    public class CadastroFornecedor : IMenuCadastro
    {
        public Int32 MenuCadastro()
        {
            Int32 opcao;

            Console.Clear();
            Console.WriteLine("----- Cadastro de Fornecedores --------");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("----- 1- Lista de Fornecedores --------");
            Console.WriteLine("----- 2- Cadastro de Fornecedores -----");
            Console.WriteLine("----- 3- Alterar Fornecedores ---------");
            Console.WriteLine("----- 4- Excluir Fornecedores ---------");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("----- 0- Sair -------------------------");
            Int32.TryParse(Console.ReadLine(), out opcao);
            return opcao;

        }

        public void Listar()
        {
            ListarFornecedores();
        }


        public void ListarFornecedores()
        {
            Console.Clear();

            foreach (Fornecedor fornecedor in Program.Mock.ListaFornecedores)
            {
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine($"Código Fornecedor: {fornecedor.CodigoFornecedor}");
                Console.WriteLine($"Nome: {fornecedor.Nome}");
                Console.WriteLine($"Tipo Fornecedor: {fornecedor.TipoFornecedor}");
                Console.WriteLine($"CPF: {fornecedor.CGCCPF}");
                Console.WriteLine("-----------------------------------------------\n");
            }
            Console.ReadLine();
        }


        public void CadastrarFornecedor(Fornecedor novoFornecedor)
        {
            Program.Mock.ListaFornecedores.Add(novoFornecedor);
        }
        
        public void Cadastrar()
        {


            Console.Clear();

            // Listar a entrada de dados aqui 
            Fornecedor novoFornecedor = new Fornecedor(); // Aqui instancioamos um novo objeto Paciente 
            Random rd = new Random();


            Console.WriteLine("-----------------------------------------");
            Console.WriteLine($"Cadastro de Fornecedores");
            Console.WriteLine("-----------------------------------------");

            novoFornecedor.Codigo = rd.Next(1, 300);
            Console.WriteLine($"Código: {novoFornecedor.Codigo}");

            Console.WriteLine($"Insira o nome do fornecedor");
            novoFornecedor.Nome = Console.ReadLine();

            Console.WriteLine($"Insira o CPF do fornecedor");
            novoFornecedor.CGCCPF = Console.ReadLine();

            Console.WriteLine($"Insira o tipo de fornecedor");
            novoFornecedor.TipoFornecedor = Console.ReadLine();
            

            novoFornecedor.CodigoFornecedor = rd.Next(1, 300);
            Console.WriteLine("Fornecedor Cadastrado com Sucesso!\n");


            CadastrarFornecedor(novoFornecedor);
            Console.ReadKey();




        }


        private void ListarFornecedoresByCodeAndName()
        {
            foreach (Fornecedor fornecedor in Program.Mock.ListaFornecedores)
            {
                Console.Write($"| {fornecedor.CodigoFornecedor} - {fornecedor.Nome} ");
            }
            Console.WriteLine("\n");
        }



        public void AlterarFornecedor(Fornecedor fornecedor)
        {

            var frn = Program.Mock.ListaFornecedores.Find(f => f.CodigoFornecedor == fornecedor.CodigoFornecedor);
            int index = Program.Mock.ListaFornecedores.IndexOf(frn);
            Program.Mock.ListaFornecedores[index] = fornecedor;

        }
        public void Alterar()
        {
            Console.Clear();
            Fornecedor fornecedor;
            int codigoFornecedor;

            Console.WriteLine("Informe o Recepcionista que Deseja Alterar:\n");
            ListarFornecedoresByCodeAndName();

            Int32.TryParse(Console.ReadLine(), out codigoFornecedor);

            fornecedor = Program.Mock.ListaFornecedores.Find(f => f.CodigoFornecedor == codigoFornecedor);

            const int NOME = 1, CPF = 2, TIPOFORNECEDOR = 3;
            int opcaoAlterar;
            bool alterar = true;

            do
            {
                Console.WriteLine($"Código do Fornecedor: {fornecedor.Codigo}/{fornecedor.CodigoFornecedor} | Nome: {fornecedor.Nome} | CPF: {fornecedor.CGCCPF} | Tipo Fornecedor: {fornecedor.TipoFornecedor}");
                Console.WriteLine("Qual campo deseja alterar?");
                Console.WriteLine("1 - Nome | 2 - CPF | 3 - Tipo Fornecedor | 0 - SAIR"); //Ajustar o valor de saída 
                Int32.TryParse(Console.ReadLine(), out opcaoAlterar); 

                switch (opcaoAlterar)
                {
                    case NOME:
                        Console.WriteLine("Informe um novo nome:");
                        fornecedor.Nome = Console.ReadLine();
                        break;
                    case CPF:
                        Console.WriteLine("Informe um novo CPF:");
                        fornecedor.CGCCPF = Console.ReadLine();
                        break;
                    case TIPOFORNECEDOR:
                        Console.WriteLine("Informe o novo Tipo de Fornecedor:");
                        fornecedor.TipoFornecedor = Console.ReadLine();
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

            AlterarFornecedor(fornecedor);


        }


        private void ExcluirFornecedor(Fornecedor fornecedor)
        {

            Program.Mock.ListaFornecedores.Remove(fornecedor);
        }

        public void Excluir()
        {
            Console.Clear();
            Fornecedor fornecedor = new Fornecedor();
            int codFornecedor;

            Console.WriteLine("Informe o Recepcionista que Deseja Excluir:\n");
            ListarFornecedoresByCodeAndName();
            Int32.TryParse(Console.ReadLine(), out codFornecedor);
            fornecedor = Program.Mock.ListaFornecedores.Find(f => f.CodigoFornecedor == codFornecedor);// Função Lambda
            Console.WriteLine($"Fornecedor Excluido: {fornecedor.CodigoFornecedor}\n");
            Console.ReadKey();


            ExcluirFornecedor(fornecedor);
        }
    }
}
