using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaUsuarios
{
    class Program
    {
        private static List<LoginEntitie> ListLogin = new List<LoginEntitie>();
        private static LoginEntitie SessionLogin = null;
        private static string OpcionSeleccionada = "";
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                if (SessionLogin != null)
                {
                    Console.WriteLine($"Hola! {SessionLogin.User}");
                    Console.WriteLine("-------------------------");
                    if (SessionLogin.Role.Equals("admin"))
                    {
                        Console.WriteLine("1 Registrar Usuario");
                        Console.WriteLine("2 Crear Archivo");
                        Console.WriteLine("3 Borrar Archivo");
                        Console.WriteLine("4 Login");
                        Console.WriteLine("5 Salir");
                        Console.WriteLine("-------------------------");

                        OpcionSeleccionada = Console.ReadLine();

                        switch (OpcionSeleccionada)
                        {
                            case "1":
                                RegistrarUsuario();
                                break;
                            case "2":
                                CrearArchivos();
                                break;
                            case "3":
                                myFiles.EditFiles.Delete();
                                break;
                            case "4":
                                SessionLogin = null;
                                Login();
                                break;
                            case "5":
                                Environment.Exit(0);
                                break;
                        }
                    }
                    else
                    {
                        //aqui podria ir el codigo para leer
                        Console.ReadLine();
                    }
                }
                else
                {
                    Login();

                }
            }
        }

        public class LoginEntitie
        {
            public string User { get; set; }
            public string Pass { get; set; }
            public string Role { get; set; } = "admin";
            public string Archivo1 { get; set; }
            public string Archivo2 { get; set; }
        }

        private static void RegistrarUsuario()
        {
            string usuario = "";
            string pass;

            while (usuario.Equals(""))
            {
                Console.Clear();
                Console.WriteLine("-------------------------");
                Console.WriteLine("Registro de usuario");
                Console.WriteLine("-------------------------");
                Console.WriteLine("Ingresa tu usuario");
                usuario = Console.ReadLine();

                if (ListLogin.Exists(u => u.User.Equals(usuario)))
                {
                    Console.WriteLine("El usuario ya existe, prueba con otro usuario.");
                    usuario = "";
                    Console.ReadKey();
                }
            }


            Console.WriteLine("Ingresa tu contraseña");
            pass = Console.ReadLine();

            ListLogin.Add(new LoginEntitie()
            {
                Role = "otro",
                Pass = pass,
                User = usuario
            });

            Console.Write("Se ha registrado el usuario.");
            Console.ReadKey();

        }
        private static void CrearArchivos()
        {
            Console.Clear();
            Console.WriteLine("-------------------------");
            Console.WriteLine("Crea un archivo");
            Console.WriteLine("-------------------------");
            Console.WriteLine();

            Console.WriteLine("Escribe el nombre del archivo .txt. Ejemplo: MiArchivo");
            string filename = Console.ReadLine();
            string path = Path.Combine(Environment.CurrentDirectory, @"Files\", filename + ".txt");

            Console.WriteLine("Ingresa el contenido");

            string text = "";
            text = Console.ReadLine();
            File.WriteAllText(path, text);
        }
        private static void Login()
        {
            OpcionSeleccionada = "";


            while (SessionLogin == null)
            {
                Console.Clear();
                Console.WriteLine("Login");
                Console.WriteLine("Ingresa tu usuario");
                string user = Console.ReadLine();
                Console.WriteLine("Digita tu contraseña");
                string pass = Console.ReadLine();
                if (user.Equals("admin") && pass.Equals("123"))
                {
                    SessionLogin = new LoginEntitie()
                    {
                        Pass = pass,
                        User = user
                    };
                    Console.WriteLine("Login Exitoso");
                }
                else if (ListLogin.Exists(u => u.User.Equals(user) && u.Pass.Equals(pass)))
                {
                    SessionLogin = new LoginEntitie()
                    {
                        Role = "otro",
                        Pass = pass,
                        User = user
                    };
                    Console.WriteLine("Login Exitoso");

                    Console.Clear();
                    Console.WriteLine("1. Abrir archivos");
                    Console.WriteLine("2. Cerrar Programa");
                    var opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":
                            myFiles.EditFiles.List();
                            break;
                        case "2":
                            Environment.Exit(0);
                            break;
                    }

                }
                else
                {
                    Console.WriteLine("Los datos no son correctos");
                }

                Console.ReadKey();

            }

        }
    }
}
