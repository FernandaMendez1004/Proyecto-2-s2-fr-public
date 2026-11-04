namespace Proyecto_2_s2_fr
{
    internal class Program
    {
        public static List<Cliente> clientes = new List<Cliente>();
        public static List<Tecnico> tecnicos = new List<Tecnico>();
        public static List<Equipo> equipos = new List<Equipo>();
        public static List<Solicitud> solicitudes = new List<Solicitud>();
        public static List<Repuesto> repuestos = new List<Repuesto>();

        public static Queue<Solicitud> colaNormal =
            new Queue<Solicitud>();

        public static Queue<Solicitud> colaUrgente =
            new Queue<Solicitud>();

        static void Main(string[] args)
        {
            Menus.MenuPrincipal();
        }
    }
}
