
using System;

namespace Proyecto_2_s2_fr
{
    class Equipo
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

        private string numeroSerie;

        public string NumeroSerie
        {
            get { return numeroSerie; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    numeroSerie = value;
                }
            }
        }

        private string marca;

        public string Marca
        {
            get { return marca; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    marca = value;
                }
            }
        }

        private string modelo;

        public string Modelo
        {
            get { return modelo; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    modelo = value;
                }
            }
        }

        private Cliente propietario;

        public Cliente Propietario
        {
            get { return propietario; }
            set
            {
                if (value != null)
                {
                    propietario = value;
                }
            }
        }

        private string tipoEquipo;

        public string TipoEquipo
        {
            get { return tipoEquipo; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    tipoEquipo = value;
                }
            }
        }

        private string estadoFisico;

        public string EstadoFisico
        {
            get { return estadoFisico; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    estadoFisico = value;
                }
            }
        }

        private string accesorios;

        public string Accesorios
        {
            get { return accesorios; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    accesorios = value;
                }
            }
        }

        public Equipo(string codigo, string numeroSerie, string marca, string modelo, Cliente propietario, string tipoEquipo, string estadoFisico, string accesorios)
        {
            Codigo = codigo;
            NumeroSerie = numeroSerie;
            Marca = marca;
            Modelo = modelo;
            Propietario = propietario;
            TipoEquipo = tipoEquipo;
            EstadoFisico = estadoFisico;
            Accesorios = accesorios;
        }

        public virtual void MostrarInformacion()
        {
            Console.WriteLine("Código: " + Codigo);
            Console.WriteLine("Número de serie: " + NumeroSerie);
            Console.WriteLine("Marca: " + Marca);
            Console.WriteLine("Modelo: " + Modelo);

            if (Propietario != null)
            {
                Console.WriteLine("Propietario: " + Propietario.Nombre);
            }

            Console.WriteLine("Tipo: " + TipoEquipo);
            Console.WriteLine("Estado físico: " + EstadoFisico);
            Console.WriteLine("Accesorios: " + Accesorios);
        }

        public virtual double CalcularCostoRevision()
        {
            return 0;
        }
    }

    class ComputadoraPortatil : Equipo
    {
        private bool incluyeCargador;

        public bool IncluyeCargador
        {
            get { return incluyeCargador; }
            set { incluyeCargador = value; }
        }

        public ComputadoraPortatil(string codigo, string numeroSerie, string marca, string modelo, Cliente propietario, string estadoFisico, string accesorios, bool incluyeCargador)
            : base(codigo, numeroSerie, marca, modelo, propietario, "Computadora portátil", estadoFisico, accesorios)
        {
            IncluyeCargador = incluyeCargador;
        }

        public override double CalcularCostoRevision()
        {
            return 100;
        }

        public override void MostrarInformacion()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==================================");
            Console.WriteLine("       COMPUTADORA PORTÁTIL");
            Console.WriteLine("==================================");
            Console.ResetColor();
            base.MostrarInformacion();
            if (IncluyeCargador == true)
            {
                Console.WriteLine("Cargador: Incluido");
            }
            else
            {
                Console.WriteLine("Cargador: No incluido");
            }
            Console.WriteLine("Costo revisión: Q" + CalcularCostoRevision());
            Console.WriteLine("==================================");
        }
    }

    class ComputadoraEscritorio : Equipo
    {
        private bool incluyeMonitor;

        public bool IncluyeMonitor
        {
            get { return incluyeMonitor; }
            set { incluyeMonitor = value; }
        }

        public ComputadoraEscritorio(string codigo, string numeroSerie, string marca, string modelo, Cliente propietario, string estadoFisico, string accesorios, bool incluyeMonitor)
            : base(codigo, numeroSerie, marca, modelo, propietario, "Computadora de escritorio", estadoFisico, accesorios)
        {
            IncluyeMonitor = incluyeMonitor;
        }

        public override double CalcularCostoRevision()
        {
            return 125;
        }

        public override void MostrarInformacion()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==================================");
            Console.WriteLine("     COMPUTADORA DE ESCRITORIO");
            Console.WriteLine("==================================");
            Console.ResetColor();
            base.MostrarInformacion();
            if (IncluyeMonitor == true)
            {
                Console.WriteLine("Monitor: Incluido");
            }
            else
            {
                Console.WriteLine("Monitor: No incluido");
            }
            Console.WriteLine("Costo revisión: Q" + CalcularCostoRevision());
            Console.WriteLine("==================================");
        }
    }

    class Impresora : Equipo
    {
        private string tipoImpresion;

        public string TipoImpresion
        {
            get { return tipoImpresion; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    tipoImpresion = value;
                }
            }
        }

        public Impresora(string codigo, string numeroSerie, string marca, string modelo, Cliente propietario,string estadoFisico, string accesorios, string tipoImpresion)
            : base(codigo, numeroSerie, marca, modelo, propietario, "Impresora", estadoFisico, accesorios)
        {
            TipoImpresion = tipoImpresion;
        }

        public override double CalcularCostoRevision()
        {
            return 75;
        }

        public override void MostrarInformacion()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==================================");
            Console.WriteLine("           IMPRESORA");
            Console.WriteLine("==================================");
            Console.ResetColor();
            base.MostrarInformacion();
            Console.WriteLine("Tipo impresión: " + TipoImpresion);
            Console.WriteLine("Costo revisión: Q" + CalcularCostoRevision());
            Console.WriteLine("==================================");
        }
    }
}
