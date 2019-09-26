using System;
using System.Collections.Generic;
using Entidades;

namespace View
{
    class ViewLivro
    {

        public string menuLivro(int QuantidadeRegistros)
        {
            Console.WriteLine("****************************");
            Console.WriteLine("\nCadastro - Livro" + Environment.NewLine);
            Console.WriteLine($"Menu - Possui {QuantidadeRegistros} livros cadastrados\n");
            Console.WriteLine("01 - Incluir");
            Console.WriteLine("02 - Alterar");
            Console.WriteLine("03 - Excluir");
            Console.WriteLine("04 - Listar");
            Console.WriteLine("05 - Pesquisar");
            Console.WriteLine("06 - Salvar");
            Console.WriteLine("09 - Sair");
            // Console.WriteLine("08 - Ler");
            Console.Write("Digite a opção desejada:");
            return Console.ReadLine();
        }



        public Livro inserirLivro()
        {
            Livro livro = new Livro();
            Console.WriteLine("\nCadastro de Livro");
            livro.Id = Convert.ToInt32(le("Insira o id: "));
            livro.Nome = le("Insira o nome: ");
            livro.Autor = le("Insira o autor: ");
            livro.Editora = le("Insira a editora: ");
            livro.DataLancamento = le("Insira a data de lançamento (Dia/Mês/Ano): ");
            livro.Preco = Convert.ToSingle(le("Insira o preço: "));
            Console.WriteLine("\nCadastro efetuado com sucesso!\n");

            return livro;
        }



        public int leituraIDLivro(string titulo)
        {
            Console.WriteLine(titulo);
            return Convert.ToInt32(le("\nIndique o Id:"));
        }

        public Livro alterarLivro(Livro livro)
        {
            Console.WriteLine("\nEdição de Livro");

            livro.Nome = leAlteracao("Insira o nome: ", livro.Nome);
            livro.Autor = leAlteracao("Insira o autor: ", livro.Autor);
            livro.Editora = leAlteracao("Insira a editora: ", livro.Editora);
            livro.DataLancamento = leAlteracao("Insira a data de lançamento (Dia/Mês/Ano): ", livro.DataLancamento);
            livro.Preco = float.Parse(leAlteracao("Insira o preço: ", livro.Preco.ToString()));
            Console.WriteLine("\nEdição efetuada com sucesso!\n");
            return livro;
        }

        internal void listaLivros(List<Livro> listaLivros)
        {
            Console.WriteLine("\nLista de Livros\n");
            listaLivros.ForEach(livro => Console.WriteLine(livro));
        }

        public string confirmaExclusão(Livro livro)
        {
            Console.WriteLine($"Registro em exclusão: {livro}");
            return le("Deseja excluir esse registro (S/N)?");
        }


        public Dictionary<string, string> pesquisar()
        {
            Dictionary<string, string> elementosDePesquisa = new Dictionary<string, string>();
            Console.WriteLine("01 - Por Id");
            Console.WriteLine("02 - Por Nome");
            Console.WriteLine("03 - Por Autor");
            Console.WriteLine("04 - Por Editora");

            string opcao = le("\nIndique a opção: ");
            string elemento = le("\nDigite o valor de busca: ");

            elementosDePesquisa.Add("opcao", opcao);
            elementosDePesquisa.Add("elemento", elemento);

            return elementosDePesquisa;
        }

        public void mostraLivro(Livro livro)
        {
            Console.WriteLine($" {livro}");
        }




        private string leAlteracao(string mensagem, string valor)
        {
            Console.Write($"{mensagem} ({valor}): ");
            string vlr = Console.ReadLine();
            return !vlr.Equals("")? vlr : valor;
        }

        private string le(string mensagem)
        {
            Console.Write($"{mensagem}: ");
            return Console.ReadLine();
        }

        public void mensagem(string mensagem)
        {
            Console.WriteLine(mensagem);
        }

    }
}
