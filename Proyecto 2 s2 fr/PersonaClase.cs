using System;

namespace Proyecto_2_s2_fr
{
    class Persona
    {
        private string codigo;

        public string Codigo
        {
            get { return codigo; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    codigo = value;
                }
            }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    nombre = value;
                }
            }
        }

        public Persona(string codigo, string nombre)
        {
            Codigo = codigo;
            Nombre = nombre;
        }

        public virtual void MostrarInformacion()
        {
            Console.WriteLine("Código: " + Codigo);
            Console.WriteLine("Nombre: " + Nombre);
        }
    }

    class Cliente : Persona
    {
        private string numeroTelefono;

        public string NumeroTelefono
        {
            get { return numeroTelefono; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    numeroTelefono = value;
                }
            }
        }

        private string correoElectronico;

        public string CorreoElectronico
        {
            get { return correoElectronico; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    correoElectronico = value;
                }
            }
        }

        private string tipoCliente;
        public string TipoCliente
        {
            get { return tipoCliente; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    tipoCliente = value;
                }
            }
        }

        private int cantidadSolicitudes;

        public int CantidadSolicitudes
        {
            get { return cantidadSolicitudes; }
            set
            {
                if (value >= 0)
                {
                    cantidadSolicitudes = value;
                }
            }
        }

        public Cliente(string codigo, string nombre, string numeroTelefono, string correoElectronico, string tipoCliente, int cantidadSolicitudes)
            : base(codigo, nombre)
        {
            NumeroTelefono = numeroTelefono;
            CorreoElectronico = correoElectronico;
            TipoCliente = tipoCliente;
            CantidadSolicitudes = cantidadSolicitudes;
        }

        public override void MostrarInformacion()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==================================");
            Console.WriteLine("         FICHA de CLIENTE");
            Console.WriteLine("==================================");
            Console.ResetColor();
            base.MostrarInformacion();
            Console.WriteLine("Teléfono: " + NumeroTelefono);
            Console.WriteLine("Correo: " + CorreoElectronico);
            Console.WriteLine("Tipo de cliente: " + TipoCliente);
            Console.WriteLine("Solicitudes: " + CantidadSolicitudes);
            Console.WriteLine("==================================");
        }
    }

    enum Especialidad
    {
        Computadoras, Impresoras, General
    }

    class Tecnico : Persona
    {
        private Especialidad especialidad;

        public Especialidad Especialidad
        {
            get { return especialidad; }
            set { especialidad = value; }
        }

        private bool disponibilidad;

        public bool Disponibilidad
        {
            get { return disponibilidad; }
            set { disponibilidad = value; }
        }

        private int trabajosActivos;

        public int TrabajosActivos
        {
            get { return trabajosActivos; }
            set
            {
                if (value >= 0)
                {
                    trabajosActivos = value;
                }
            }
        }

        private int serviciosFinalizados;

        public int ServiciosFinalizados
        {
            get { return serviciosFinalizados; }
            set
            {
                if (value >= 0)
                {
                    serviciosFinalizados = value;
                }
            }
        }

        private double calificacionPromedio;

        public double CalificacionPromedio
        {
            get { return calificacionPromedio; }
            set
            {
                if (value >= 0 && value <= 5)
                {
                    calificacionPromedio = value;
                }
            }
        }

        public Tecnico(string codigo, string nombre, Especialidad especialidad, bool disponibilidad, int trabajosActivos, int serviciosFinalizados, double calificacionPromedio)
            : base(codigo, nombre)
        {
            Especialidad = especialidad;
            Disponibilidad = disponibilidad;
            TrabajosActivos = trabajosActivos;
            ServiciosFinalizados = serviciosFinalizados;
            CalificacionPromedio = calificacionPromedio;
        }

        public override void MostrarInformacion()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==================================");
            Console.WriteLine("         FICHA de TECNICO");
            Console.WriteLine("==================================");
            Console.ResetColor();
            base.MostrarInformacion();
            Console.WriteLine("Especialidad: " + Especialidad);
            if (Disponibilidad == true)
            {
                Console.WriteLine("Estado: Disponible");
            }
            else
            {
                Console.WriteLine("Estado: No disponible");
            }
            Console.WriteLine("Trabajos activos: " + TrabajosActivos);
            Console.WriteLine("Servicios finalizados: " + ServiciosFinalizados);
            Console.WriteLine("Calificación: " + CalificacionPromedio);
            Console.WriteLine("==================================");
        }
    }

  
}