using System;
using System.Collections.Generic;
using Entidades;

namespace DAO
{
    class DAOLivro
    {
        private List<Livro> listaLivros = new List<Livro>();



        public int getTotal()
        {
            return listaLivros.Count;
        }

        public void addLivro(Livro livro)
        {
            listaLivros.Add(livro);
        }


        public Livro findLivro(int id)
        {
            return listaLivros.Find(x => x.Id == id);
        }

        public Livro findLivroNome(string nome)
        {
            return listaLivros.Find(x => x.Nome == nome);
        }


        public Livro findLivroAutor(string autor)
        {
            return listaLivros.Find(x => x.Autor == autor);
        }

        public Livro findLivroEditora(string editora)
        {
            return listaLivros.Find(x => x.Editora == editora);
        }

        internal List<Livro> getAllLivros()
        {
            return listaLivros;
        }

        internal void removeLivro(Livro livro)
        {
            listaLivros.Remove(livro);
        }

        public Livro[] getListaLivrosToArray()
        {
            return listaLivros.ToArray();
        }

        internal void setListaDeLivros(List<Livro> lista)
        {
            if (lista != null)
                listaLivros.AddRange(lista);
        }
    }
}
