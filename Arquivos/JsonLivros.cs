using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Entidades;
using Newtonsoft.Json;

namespace Arquivos
{
    class JsonLivros
    {

        public Boolean salvarArquivoJSon(List<Livro> listLivros)
        {
            string json = JsonConvert.SerializeObject(listLivros, Formatting.Indented);

            //write string to file
            File.WriteAllText(@"./livros.json", json);
            return true;
        }



        public List<Livro> lerArquivoJSon()
        {
            string jsonFilePath = @"./livros.json";
            if (File.Exists(jsonFilePath))
            {
                string json = File.ReadAllText(jsonFilePath);

                List<Livro> lista = JsonConvert.DeserializeObject<List<Livro>>(json);
                return lista;
            }
            return null;
        }
    }
}
