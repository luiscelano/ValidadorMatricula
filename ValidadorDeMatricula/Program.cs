using System;
using System.IO;

namespace ValidadorDeMatricula
{
    class Program
    {
        public static string filename = "\\matriculas.txt";
        public static string directory = Directory.GetCurrentDirectory();
        public static string path = directory + filename;

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Ingrese el no. de matricula a registrar");
                string noMatricula = Console.ReadLine();
                AgregarMatricula(noMatricula);
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void ValidarArchivo()
        {
            if(!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            if(!File.Exists(path))
            {
                FileStream fileStream = File.Create(path);
                fileStream.Close();
            }
        }

        static void AgregarMatricula(string noMatricula)
        {
            //Valida la existencia del archivo
            ValidarArchivo();

            string[] matriculas = File.ReadAllLines(path); //obtenemos todas las matriculas

            //Validamos la existencia de la matricula
            foreach(string matricula in matriculas)
            {
                if (matricula == noMatricula) throw new Exception("La matricula ingresada ya existe");
            }

            StreamWriter stream = File.AppendText(path);

            stream.WriteLine(noMatricula);
            stream.Close();
        }
    }
}
