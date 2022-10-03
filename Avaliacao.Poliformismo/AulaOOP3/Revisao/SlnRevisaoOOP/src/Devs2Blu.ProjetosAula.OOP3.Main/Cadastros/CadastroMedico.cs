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
    public class CadastroMedico : IMenuCadastro
    {
        public Int32 MenuCadastro()
        {
            Int32 opcao;

            Console.Clear();
            Console.WriteLine("----- Cadastro de Médicos --------");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("----- 1- Lista de Médicos --------");
            Console.WriteLine("----- 2- Cadastro de Médicos -----");
            Console.WriteLine("----- 3- Alterar Médicos ---------");
            Console.WriteLine("----- 4- Excluir Médicos ---------");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("----- 0- Sair --------------------");
            Int32.TryParse(Console.ReadLine(), out opcao);
            return opcao;

        }

        public void Listar()
        {
            ListarMedicos();
        }


        public void ListarMedicos()
        {
            Console.Clear();

            foreach (var medico in Program.Mock.ListaMedicos)
            {
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine($"Código Médico: {medico.CodigoMedico}");
                Console.WriteLine($"Nome: {medico.Nome}");
                Console.WriteLine($"Especialidade: {medico.Especialidade}");
                Console.WriteLine($"CRM: {medico.CRM}");
                Console.WriteLine("---------------------------------------\n");
            }
            Console.ReadLine();
        }


        public void CadastrarMedico(Medico novoMedico)
        {
            Program.Mock.ListaMedicos.Add(novoMedico);
        }
        
        public void Cadastrar()
        {


            Console.Clear();

            // Listar a entrada de dados aqui 
            Medico novoMedico = new Medico(); // Aqui instancioamos um novo objeto Paciente 
            Random rd = new Random();
            
            
            
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine($"Cadastro de Médicos");
            Console.WriteLine("-----------------------------------------");

            novoMedico.Codigo = rd.Next(1, 300);
            Console.WriteLine($"Código: {novoMedico.Codigo}");

            Console.WriteLine($"Insira o nome do médico");
            novoMedico.Nome = Console.ReadLine();

            Console.WriteLine($"Insira o CPF do médico");
            novoMedico.CGCCPF = Console.ReadLine();

            Console.WriteLine($"Insira o CRM");
            int newCrm = 0;
            Int32.TryParse(Console.ReadLine(), out newCrm);
            novoMedico.CRM = newCrm; 
            
            Console.WriteLine($"Insira qual especialidade");
            novoMedico.Especialidade = Console.ReadLine();
            

            novoMedico.CodigoMedico = rd.Next(1, 300);
            Console.WriteLine("Médico Cadastrado com Sucesso!\n");

            CadastrarMedico(novoMedico);
            Console.ReadKey();



        }


        private void ListarMedicosByCodeAndName()
        {
            foreach (Medico medico in Program.Mock.ListaMedicos)
            {
                Console.Write($"| {medico.CodigoMedico} - {medico.Nome} ");
            }
            Console.WriteLine("\n");
        }



        public void AlterarMedico(Medico medico)
        {

            var med = Program.Mock.ListaMedicos.Find(m => m.CodigoMedico == medico.CodigoMedico);
            int index = Program.Mock.ListaMedicos.IndexOf(med);
            Program.Mock.ListaMedicos[index] = medico;

        }
        public void Alterar()
        {
            Console.Clear();
            Medico medico;
            int codigoMedico;

            Console.WriteLine("Informe o Médico que Deseja Alterar:\n");
            ListarMedicosByCodeAndName();

            Int32.TryParse(Console.ReadLine(), out codigoMedico);

            medico = Program.Mock.ListaMedicos.Find(m => m.CodigoMedico == codigoMedico);

            const int NOME = 1, CPF = 2, ESPECIALIDADE = 3, CRM = 4;
            int opcaoAlterar;
            bool alterar = true;

            do
            {
                Console.WriteLine($"Código Médico: {medico.Codigo}/{medico.CodigoMedico} | Nome: {medico.Nome} | CPF: {medico.CGCCPF} | Convênio: {medico.Especialidade}");
                Console.WriteLine("Qual campo deseja alterar?");
                Console.WriteLine("1 - Nome | 2 - CPF | 3 - Especialidade | 4 - CRM | 0 - SAIR"); //Ajustar o valor de saída 
                Int32.TryParse(Console.ReadLine(), out opcaoAlterar); 

                switch (opcaoAlterar)
                {
                    case NOME:
                        Console.WriteLine("Informe um novo nome:");
                        medico.Nome = Console.ReadLine();
                        break;
                    case CPF:
                        Console.WriteLine("Informe um novo CPF:");
                        medico.CGCCPF = Console.ReadLine();
                        break;
                    case ESPECIALIDADE:
                        Console.WriteLine("Informe uma nova especialidade:");
                        medico.Especialidade = Console.ReadLine();
                        break;


                    case CRM:
                        Console.WriteLine("Informe um novo CRM:");
                        int newCrm = 0;
                        Int32.TryParse(Console.ReadLine(), out newCrm);
                        medico.CRM = newCrm;
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

            AlterarMedico(medico);



        }




        private void ExcluirMedico(Medico medico)
        {

            Program.Mock.ListaMedicos.Remove(medico);
        }

        public void Excluir()
        {
            Console.Clear();
            Medico medico = new Medico();
            int codMedico;

            Console.WriteLine("Informe o Médico que Deseja Excluir:\n");
            ListarMedicosByCodeAndName();
            Int32.TryParse(Console.ReadLine(), out codMedico);
            medico = Program.Mock.ListaMedicos.Find(m => m.CodigoMedico == codMedico);// Função Lambda
            Console.WriteLine($"Médico Excluido: {medico.CodigoMedico}\n");
            Console.ReadKey();




            ExcluirMedico(medico);
        }
    }
}
