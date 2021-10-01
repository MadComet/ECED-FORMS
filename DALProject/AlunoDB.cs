﻿using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALProject
{
    public static class AlunoDB
    {
        public static Response Insert(Aluno al)
        {
            try
            {
                DocumentReference doc = DBConection.Getdatabase().Collection("Aluno").Document(al.NomeAluno);
                Dictionary<string, object> DadosPessoais = new Dictionary<string, object>();

                Dictionary<string, object> data1 = new Dictionary<string, object>()
                {
                    {"NOME",al.NomeAluno},
                    {"Data de Nascimento",al.DataNascimento},
                    //{"Cor / Raça",cmbCor.Text },
                    //{"Sexo",cmbSexo.Text },
                    //{"Naturalidade",txtNacionalidade.Text },
                    //{"Nacionalidade",txtNacionalidade.Text},
                    //{"Uf",txtUf.Text },
                    //{"Estado civil",txtEstado.Text },
                };
                DadosPessoais.Add("Dados Pessoais", data1);

                doc.SetAsync(DadosPessoais);

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
