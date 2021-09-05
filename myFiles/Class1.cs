using System;
using System.IO;

namespace myFiles
//Rama Gabriel Gómez SMIS019220
{
    public class EditFiles
    {
        public static void List()
        {
            Console.Clear();
            Console.WriteLine("Seleccione una opcion");
            // get files from relative directory in project
            string path = Path.Combine(Environment.CurrentDirectory, @"Files");
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                Console.WriteLine("{0}. {1}", Array.IndexOf(files, file) + 1, Path.GetFileName(file));
            }

            var fileNumber = Console.ReadLine();

            OpenFile(int.Parse(fileNumber));
        }

        static void OpenFile(int index)
        {
            // get files from relative directory in project
            string path = Path.Combine(Environment.CurrentDirectory, @"Files");
            string[] files = Directory.GetFiles(path);
            Console.WriteLine(File.ReadAllText(files[index - 1]));
            Console.ReadKey();
        }


        public static void Delete()
        {
            Console.Clear();
            Console.WriteLine("Seleccione una opcion");
            // get files from relative directory in project
            string path = Path.Combine(Environment.CurrentDirectory, @"Files");
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                Console.WriteLine("{0}. {1}", Array.IndexOf(files, file) + 1, Path.GetFileName(file));
            }

            var fileNumber = Console.ReadLine();

            DeleteFile(int.Parse(fileNumber));
        }

        // delete selected file
        static void DeleteFile(int index)
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"Files");
            string[] files = Directory.GetFiles(path);
            File.Delete(files[index - 1 ]);
            Console.WriteLine("Archivo borrado con exito");
            Console.ReadKey();
        }
    }
}
