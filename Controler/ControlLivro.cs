using System;
using System.Collections.Generic;
using Entidades;
using View;
using DAO;
using Arquivos;

namespace Controler
{
    class ControlLivro
    {
        private ViewLivro viewLivro = new ViewLivro();
        private DAOLivro daoLivro = new DAOLivro();

        public void cadastroLivro()
        {
            Boolean continuar = true;
            carregaDadosDoArquivoJSon();



            do
            {

                string opcao = viewLivro.menuLivro(daoLivro.getTotal());
                switch (opcao)
                {
                    case "1":
                    case "01":
                        incluir();
                        break;
                    case "2":
                    case "02":
                        alterar();
                        break;
                    case "3":
                    case "03":
                        excluir();
                        break;
                    case "4":
                    case "04":
                        lista();
                        break;
                    case "5":
                    case "05":
                        pesquisar();
                        break;
                    case "6":
                    case "06":
                        salvar();
                        break;
                    case "9":
                    case "09":
                        viewLivro.mensagem("Seu aplicativo foi encerrado!");
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opção não existente!");
                        break;
                }
            } while (continuar);
        }

        private void carregaDadosDoArquivoJSon()
        {
            List<Livro> lista = (new JsonLivros()).lerArquivoJSon();
            daoLivro.setListaDeLivros(lista);
        }

        private void salvar()
        {
            new JsonLivros().salvarArquivoJSon(daoLivro.getAllLivros());
        }

        private void pesquisar()
        {
            Livro livro = null;
            Dictionary<string, string> elemento = viewLivro.pesquisar();
            viewLivro.mensagem("Resultado");
            switch (elemento["opcao"])
            {
                case "01": //"Insira o Id: "
                    livro = daoLivro.findLivro(int.Parse(elemento["elemento"]));
                    break;
                case "02": //"Insira o Nome: "
                    livro = daoLivro.findLivroNome(elemento["elemento"]);
                    break;
                case "03": //"Insira o Autor: "
                    livro = daoLivro.findLivroAutor(elemento["elemento"]);
                    break;
                case "04": //"Insira o Editora: "
                    livro = daoLivro.findLivroAutor(elemento["elemento"]);
                    break;
                default:
                    Console.WriteLine("\nOpção não existente!");
                    break;
            }
            mostraResultadoPesquisa(livro);
        }

        private void mostraResultadoPesquisa(Livro livro)
        {
            if (livro != null)
            {
                viewLivro.mostraLivro(livro);
            }
            else
            {
                viewLivro.mensagem("Registro não encontrado!");
            }
        }

        private void lista()
        {
            List<Livro> listaLivros = daoLivro.getAllLivros();
            viewLivro.listaLivros(listaLivros);
        }

        private void excluir()
        {
            int id = viewLivro.leituraIDLivro("EXCLUSÃO");
            Livro livro = daoLivro.findLivro(id);
            if (livro != null)
            {
                string confirmacao = viewLivro.confirmaExclusão(livro);
                if (confirmacao.Contains("S") || confirmacao.Contains("s"))
                {
                    daoLivro.removeLivro(livro);
                }
            }
            else
            {
                viewLivro.mensagem("Registro não encontrado");
            }
        }

        private void incluir()
        {
            Livro livro = viewLivro.inserirLivro();
            daoLivro.addLivro(livro);
        }

        private void alterar()
        {
            int id = viewLivro.leituraIDLivro("ALTERAÇÃO");
            Livro livro = daoLivro.findLivro(id);
            if (livro != null)
            {
                viewLivro.alterarLivro(livro);
            }
            else
            {
                viewLivro.mensagem("Item não encontrado");
            }
        }
    }
}

