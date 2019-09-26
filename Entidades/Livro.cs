using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Livro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }

        public string  DataLancamento { get; set; }

        public float Preco { get; set; }


        public override string ToString()
        {
            return $"ID: {Id}, Nome: {Nome}, Autor: {Autor}, Editora: {Editora}, Data Lançamento: {DataLancamento}, Preço: {Preco}";
        }


    }


}
