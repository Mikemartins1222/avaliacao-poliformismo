using Devs2Blu.ProjetosAula.OOP3.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs2Blu.ProjetosAula.OOP3.Main.Utils
{
    public class Mocks
    {
        public List<Paciente> ListaPacientes { get; set; }
        public List<Medico> ListaMedicos { get; set; }
        public List<Recepcionista> ListaRecepcionistas { get; set; }
        public List<Fornecedor> ListaFornecedores { get; set; }

        public Mocks()
        {
            ListaPacientes = new List<Paciente>();
            ListaMedicos = new List<Medico>();
            ListaRecepcionistas = new List<Recepcionista>();
            ListaFornecedores = new List<Fornecedor>();

            CargaMock();
        }
        public void CargaMock()
        {
            CargaPacientes();
            CargaMedicos();
            CargaRecepcionistas();
            CargaFornecedores();
        }

        public void CargaPacientes()
        {
            for (int i = 0; i < 10; i++)
            {
                Paciente paciente = new Paciente(i, $"Paciente {i+1}", $"{i}23{i}56{i}891{i}","Unimed");
                ListaPacientes.Add(paciente);
            }
        }

        public void CargaMedicos()
        {
            Random rd = new Random();
            String[] especialidades = {"Clínico Geral", "Neurologista", "Ginecologista", "Pediatra"};
            for (int i = 0; i < 4; i++)
            {
                Medico medico = new Medico(i, $"Médico {i + 1}", $"{i + rd.Next(0, 5)}23{i + rd.Next(0, 5)}56{i + rd.Next(0, 5)}891{i + rd.Next(0, 5)}",rd.Next(321, 789) , especialidades[rd.Next(0, 3)]);
                ListaMedicos.Add(medico);
            }
        }



        public void CargaRecepcionistas()
        {

            Random rd = new Random();
            string[] setor = new string[] { "setor 1", "setor 2", "setor 3", "setor 4" };

            for (int i = 0; i < 5; i++)
            {

                Recepcionista recepcionista = new Recepcionista(rd.Next(0, 10), $"Recepcionista {i + 1}", $"{i}23{i}56{i}891{i}", setor[rd.Next(0, 3)]);
                ListaRecepcionistas.Add(recepcionista);
            }



        }

        #region  Teste
        /*TESTANDO A REGIÃO AQUI*/
        #endregion


        public void CargaFornecedores()
        {

            Random rd = new Random();

            string[] tipoFornecedor = new string[] { "Ze", "Dirceu", "Ana", "Amanda" };/*PADRONIZAR A GERAÇÃO DE NOMES PARA AS OUTRAS CARGAS*/
            
            for (int i = 0; i < 5; i++)
            {

                Fornecedor fornecedor = new Fornecedor(rd.Next(0, 10), $"Fornecedor {i + 1}", $"{i}23{i}56{i}891{i}", tipoFornecedor[rd.Next(0, 3)]);
                ListaFornecedores.Add(fornecedor);
            }



        }
    }
}
