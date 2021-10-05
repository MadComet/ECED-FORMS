﻿using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject
{
    public static class SaudeAlunoDB
    {
        public static Response InsertSaude(SaudeAluno saude, Aluno al)
        {
            try
            {
                DocumentReference doc = DBConection.Getdatabase().Collection("Aluno").Document(al.NomeAluno);
                Dictionary<string, object> SaudeAluno = new Dictionary<string, object>();
                Dictionary<string, object> saudeInfo = new Dictionary<string, object>()
                {
                    {"Problema Saude", saude.ProblemaSaude},
                    {"Problema Saude Detalhe", saude.ProblemaSaudeDetalhe},
                    {"Alergia Medicamento", saude.AlergiaMedicamento},
                    {"Alergia Medicamento Detalhe", saude.AlergiaMedicamentoDetalhe},
                    {"Intolerancia Alimento", saude.IntoleranciaAlimento},
                    {"Intolerancia Alimento Detalhe", saude.IntoleranciaAlimentoDetalhe},
                    {"Dieta Especifica", saude.DietaEspecifica},
                    {"Dieta Especifica Detalhe", saude.DietaEspecificaDetalhe},
                    {"Contato Emergencia Um", saude.ContatoEmergUm},
                    {"Telefone Emergencia Um", saude.TelefoneEmergUm},
                    {"Contato Emergencia Dois", saude.ContatoEmergDois},
                    {"Telefone Emergencia Dois", saude.TelefoneEmergDois},
                    {"Telefone Contato", saude.TelefoneContato},
                };
                SaudeAluno.Add("Saúde Aluno", saudeInfo);
                Task<WriteResult> t = doc.UpdateAsync(SaudeAluno);
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
