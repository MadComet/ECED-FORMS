﻿using DALProject;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject
{
     public static class IdentificacaoEscolaDB
    {
        public static Response InsertIdentEscola(IdentificacaoEscolar identEscola, Aluno aluno)
        {
            try
            {
                DocumentReference doc = DBConection.Getdatabase().Collection("Dados Pessoais").Document(aluno.NomeAluno);
                Dictionary<string, object> identeficacao = new Dictionary<string, object>
                {
                    {"Unidade Escolar", identEscola.UnidadeEscolar},
                    {"Código do Inep", identEscola.CodigoDoInep},
                    {"Turno", identEscola.Turno},
                    {"Turma", identEscola.Turma},
                    {"Data da Matrícula", identEscola.DataMatricula},
                    {"Autorizado Buscar Criança", identEscola.AuthBuscarCrianca},
                    {"Telefone Autorizado", identEscola.Telefone},
                    {"Grau Parentesco", identEscola.GrauParent},
                    {"Idade", identEscola.Idade},
                };
              
                Task<WriteResult> t = doc.SetAsync(identeficacao);
                t.Wait();

                return new Response()
                {
                    Executed = true,
                    Message = "Deu Certo"
                };

            }
            catch (Exception)
            {
                return new Response()
                {
                    Executed = false,
                    Message = "Deu Ruim"
                };
            }
        }
    }
}
