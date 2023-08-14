using System;
using System.IO;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que você desejar fazer?");
            Console.WriteLine("1 - Abrir arquivo de texto");
            Console.WriteLine("2 - Criar arquivo");
            Console.WriteLine("0 - Sair do programa");

            short option;
            while(!short.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Opção inválida. Por favor selecione uma opção válida:");
            }
            
            switch (option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: Open(); break;
                case 2: Edit(); break;
                default: Menu(); break;
            }
        }

        static void Open()
        {
            Console.Clear();
            Console.WriteLine("Qual caminho do arquivo?");
            var path = Console.ReadLine();

            if(path != null)
            {
                using(var file = new StreamReader(path)) 
                {
                    Console.Clear();
                    string text = file.ReadToEnd();
                    Console.WriteLine(text);
                }

                Console.WriteLine("");
                Console.WriteLine("Aperte ENTER para voltar ao Menu...");
                Console.ReadLine();
                Menu();
            }
            else
            {
                Console.WriteLine("Digite um caminho válido.");
                Open();
            }

        }

        static void Edit()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo :");
            Console.WriteLine("(ESC para sair e ENTER para quebra de linha)");
            Console.WriteLine("-----------------------");
            string text = "";
            ConsoleKeyInfo cki;

            do
            {
                cki = Console.ReadKey();
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            while (cki.Key != ConsoleKey.Escape);

            Save(text);
        }

        static void Save(string text)
        {
            Console.Clear();
            Console.WriteLine("- Qual caminho para salvar o arquivo?");
            
            var path = Console.ReadLine();
            if(path != null)
            {
                using(var file = new StreamWriter(path)) 
                {
                    file.Write(text);
                }
                Console.WriteLine($"Arquivo salvo em {path} com sucesso!");
                Console.WriteLine("Aperte ENTER para voltar ao Menu...");
                Console.ReadLine();
                Menu();
            }
            else
            {
                Console.WriteLine("Digite um caminho válido.");
                Save(text);
            }

        }
    }   
}