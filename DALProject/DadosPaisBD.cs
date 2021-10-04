﻿using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject
{
    public static class DadosPaisBD
    {
        public static Response InsertDadosPais(DadosPais dadosPais, Aluno aluno)
        {
            try
            {
                DocumentReference doc = DBConection.Getdatabase().Collection("Aluno").Document(aluno.NomeAluno); //Nome do aluno para adicionar no mesmo documento que as outras informações
                Dictionary<string, object> DadosPais = new Dictionary<string, object>(); //Nova coleção
                Dictionary<string, object> infoPais = new Dictionary<string, object>()
                {
                    {"Responsavel Um", dadosPais.ResponsavelUm},
                    {"Nome Responsavel Um", dadosPais.NomeResponsavelUm},
                    {"Data Nascimento Resp Um", dadosPais.DataNascimentoRespUm},
                    {"Telefone Resp Um", dadosPais.TelefoneRespUm},
                    {"Cpf Resp Um", dadosPais.CpfRespUm},
                    {"Rg Resp Um", dadosPais.RgRespUm},
                    {"Data Expedicao Rg Resp Um", dadosPais.DataExpedicaoRgRespUm},
                    {"Uf Rg Resp Um", dadosPais.UfRgRespUm},
                    {"Orgao Emissor Rg Resp Um", dadosPais.orgaoEmissorRgRespUm},
                    {"Estado Civil Resp Um", dadosPais.EstadoCivilRespUm},
                    {"Escolaridade Resp Um", dadosPais.EscolaridadeRespUm},
                    {"Profissao Resp Um", dadosPais.ProfissaoRespUm},
                    {"Local Trabalho Resp Um", dadosPais.LocalTrabalhoRespUm},
                    {"Horario Trabalho Resp Um", dadosPais.HorarioTrabalhoRespUm},
                    {"Ramal Resp Um", dadosPais.RamalRespUm},
                    {"Responsavel Dois", dadosPais.ResponsavelDois},
                    {"Nome Responsavel Dois", dadosPais.NomeResponsavelDois},
                    {"Data Nascimento Resp Dois", dadosPais.DataNascimentoRespDois},
                    {"Telefone Resp Dois", dadosPais.TelefoneRespDois},
                    {"Cpf Resp Dois", dadosPais.CpfRespDois},
                    {"Rg Resp Dois", dadosPais.RgRespDois},
                    {"Data Expedicao Rg Resp Dois", dadosPais.DataExpedicaoRgRespDois},
                    {"Uf Rg Resp Dois", dadosPais.UfRgRespDois},
                    {"Orgao Emissor Rg Resp Dois", dadosPais.orgaoEmissorRgRespDois},
                    {"Estado Civil Resp Dois", dadosPais.EstadoCivilRespDois},
                    {"Escolaridade Resp Dois", dadosPais.EscolaridadeRespDois},
                    {"Profissao Resp Dois", dadosPais.ProfissaoRespDois},
                    {"Local Trabalho Resp Dois", dadosPais.LocalTrabalhoRespDois},
                    {"Horario Trabalho Resp Dois", dadosPais.HorarioTrabalhoRespDois},
                    {"Ramal Resp Dois", dadosPais.RamalRespDois},
                };
                DadosPais.Add("Dados Pais", infoPais);
                Task<WriteResult> t = doc.UpdateAsync(DadosPais);
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
