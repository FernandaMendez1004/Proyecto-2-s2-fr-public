
using System;

namespace Proyecto_2_s2_fr
{
    internal class SirvePaTodo
    {
        private static Random random = new Random();

        public static string GenerarCodigo(string prefijo)
        {
            int numero = random.Next(10000, 100000);
            return prefijo + numero;
        }

        public static void Titulo(string texto, ConsoleColor colorTitulo)
        {
            Console.Clear();
            Console.ResetColor();

            int ancho = 70;

            Console.ForegroundColor = colorTitulo;
            Console.WriteLine("╔" + new string('═', ancho) + "╗");
            string nombre = "XELATECH SOPORTE";
            int espaciosNombre = (ancho - nombre.Length) / 2;
            Console.WriteLine("║" + new string(' ', espaciosNombre) + nombre.PadRight(ancho - espaciosNombre) + "║");
            Console.ForegroundColor = ConsoleColor.White;

            int espaciosTitulo = (ancho - texto.Length) / 2;
            Console.WriteLine("║" + new string(' ', espaciosTitulo) + texto.PadRight(ancho - espaciosTitulo) + "║");
            Console.ForegroundColor = colorTitulo;
            Console.WriteLine("╚" + new string('═', ancho) + "╝");

            Console.ResetColor();
            Console.WriteLine();
        }

        public static void OpcionMenu(string numero, string texto, ConsoleColor colorTexto)
        { //fuck u
            Console.ForegroundColor = colorTexto;
            Console.Write("  [" + numero + "] ");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(texto);

            Console.ResetColor();
            Console.WriteLine();
        }

        public static void PieMenu(ConsoleColor colorLinea)
        {
            Console.ForegroundColor = colorLinea;
            Console.WriteLine(new string('─', 72));
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Seleccione una opción: ");
            Console.ResetColor();
        }

        public static void MensajeError(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {mensaje}");
            Console.ResetColor();
        }

        public static void MensajeExito(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(mensaje);
            Console.ResetColor();
        }

        public static void Pausa()
        {
            Console.WriteLine();
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }


        public static bool ValidarNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                return false;
            }

            nombre = nombre.Trim();

            if (nombre.Length < 2)
            {
                return false;
            }

            foreach (char letra in nombre)
            {
                if (!char.IsLetter(letra) && letra != ' ')
                {
                    return false;
                }
            }
            return true;
        }

        public static bool ValidarTelefono(string telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono))
            {
                return false;
            }

            if (telefono.Length != 8)
            {
                return false;
            }

            foreach (char numero in telefono)
            {
                if (numero < '0' || numero > '9')
                {
                    return false;
                }
            }
            return true;
        }

        public static bool ValidarCorreo(string correo)
        {
            if (string.IsNullOrWhiteSpace(correo))
            {
                return false;
            }

            correo = correo.Trim();
            int arroba = correo.IndexOf('@');
            int ultimaArroba = correo.LastIndexOf('@');
            int punto = correo.LastIndexOf('.');

            if (arroba <= 0 || arroba != ultimaArroba)
            {
                return false;
            }

            if (punto <= arroba + 1 || punto >= correo.Length - 1)
            {
                return false;
            }

            if (correo.Contains(" "))
            {
                return false;
            }
            return true;
        }

    }
}
