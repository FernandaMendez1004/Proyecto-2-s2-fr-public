
using System;
using System.Collections.Generic;

namespace Proyecto_2_s2_fr
{
    enum PrioridadSolicitud
    {
        Normal, Urgente
    }

    enum EstadoSolicitud
    {
        Recibida, EnEspera, Asignada, EnDiagnostico, EnReparacion, ListaParaEntregar, Entregada, Cancelada
    }

    class Solicitud
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

        private Cliente cliente;

        public Cliente Cliente
        {
            get { return cliente; }
            set
            {
                if (value != null)
                {
                    cliente = value;
                }
            }
        }

        private Equipo equipo;

        public Equipo Equipo
        {
            get { return equipo; }
            set
            {
                if (value != null)
                {
                    equipo = value;
                }
            }
        }

        private string descripcionProblema;

        public string DescripcionProblema
        {
            get { return descripcionProblema; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    descripcionProblema = value;
                }
            }
        }

        private DateTime fechaRecepcion;

        public DateTime FechaRecepcion
        {
            get { return fechaRecepcion; }
            set { fechaRecepcion = value; }
        }

        private PrioridadSolicitud prioridad;

        public PrioridadSolicitud Prioridad
        {
            get { return prioridad; }
            set { prioridad = value; }
        }

        private EstadoSolicitud estado;

        public EstadoSolicitud Estado
        {
            get { return estado; }
        }

        private Tecnico tecnicoAsignado;

        public Tecnico TecnicoAsignado
        {
            get { return tecnicoAsignado; }
            set { tecnicoAsignado = value; }
        }

        private string diagnostico;

        public string Diagnostico
        {
            get { return diagnostico; }
            set { diagnostico = value; }
        }

        private double costoManoObra;

        public double CostoManoObra
        {
            get { return costoManoObra; }
            set
            {
                if (value >= 0)
                {
                    costoManoObra = value;
                }
            }
        }

        private double costoRepuestos;

        public double CostoRepuestos
        {
            get { return costoRepuestos; }
            set
            {
                if (value >= 0)
                {
                    costoRepuestos = value;
                }
            }
        }

        public double Total
        {
            get
            {
                return CostoManoObra + CostoRepuestos;
            }
        }

        private Stack<EstadoSolicitud> historialEstados;

        public Stack<EstadoSolicitud> HistorialEstados
        {
            get { return historialEstados; }
        }

        public Solicitud(string codigo, Cliente cliente, Equipo equipo, string descripcionProblema, PrioridadSolicitud prioridad)
        {
            Codigo = codigo;
            Cliente = cliente;
            Equipo = equipo;
            DescripcionProblema = descripcionProblema;
            Prioridad = prioridad;
            FechaRecepcion = DateTime.Now;
            estado = EstadoSolicitud.Recibida;
            TecnicoAsignado = null;
            Diagnostico = "";
            CostoManoObra = 0;
            CostoRepuestos = 0;
            historialEstados = new Stack<EstadoSolicitud>();
        }

        public bool CambiarEstado(EstadoSolicitud nuevoEstado)
        {
            bool permitido = false;

            if (estado == EstadoSolicitud.Recibida && nuevoEstado == EstadoSolicitud.EnEspera)
            {
                permitido = true;
            }

            else if (estado == EstadoSolicitud.EnEspera && nuevoEstado == EstadoSolicitud.Asignada)
            {
                if (TecnicoAsignado != null)
                {
                    permitido = true;
                }
            }
            else if (estado == EstadoSolicitud.Asignada && nuevoEstado == EstadoSolicitud.EnDiagnostico)
            {
                permitido = true;
            }
            else if (estado == EstadoSolicitud.EnDiagnostico && nuevoEstado == EstadoSolicitud.EnReparacion)
            {
                if (!string.IsNullOrWhiteSpace(Diagnostico))
                {
                    permitido = true;
                }
            }

            else if (estado == EstadoSolicitud.EnReparacion && nuevoEstado == EstadoSolicitud.ListaParaEntregar)
            {
                permitido = true;
            }

            else if (estado == EstadoSolicitud.ListaParaEntregar && nuevoEstado == EstadoSolicitud.Entregada)
            {
                permitido = true;
            }

            else if (nuevoEstado == EstadoSolicitud.Cancelada && estado != EstadoSolicitud.Entregada && estado != EstadoSolicitud.Cancelada)
            {
                permitido = true;
            }

            if (permitido == true)
            {
                historialEstados.Push(estado);
                estado = nuevoEstado;
            }
            return permitido;
        }

        public bool DeshacerEstado()
        {
            if (estado == EstadoSolicitud.Entregada || estado == EstadoSolicitud.Cancelada)
            {
                return false;
            }

            if (historialEstados.Count > 0)
            {
                estado = historialEstados.Pop();
                return true;
            }

            return false;
        }

        public void MostrarInformacion()
        {
            
            Console.WriteLine("Código: " + Codigo);
            Console.WriteLine("Prioridad: " + Prioridad);
            Console.WriteLine("Estado: " + Estado);
            Console.WriteLine("Fecha: " + FechaRecepcion);
            Console.WriteLine();
            Console.WriteLine("--- CLIENTE Y EQUIPO ---");

            if (Cliente != null)
            {
                Console.WriteLine("Cliente: " + Cliente.Nombre);
            }

            if (Equipo != null)
            {
                Console.WriteLine("Equipo: " + Equipo.TipoEquipo);
                Console.WriteLine("Serie: " + Equipo.NumeroSerie);
            }

            Console.WriteLine("Problema: " + DescripcionProblema);
            if (TecnicoAsignado != null)
            {
                Console.WriteLine("Técnico: " + TecnicoAsignado.Nombre);
            }
            else
            {
                Console.WriteLine("Técnico: Sin asignar");
            }

            Console.WriteLine("Diagnóstico: " + Diagnostico);
            Console.WriteLine();
            Console.WriteLine("--- COSTOS ---");
            Console.WriteLine("Mano de obra: Q" + CostoManoObra);
            Console.WriteLine("Repuestos: Q" + CostoRepuestos);
            Console.WriteLine("TOTAL: Q" + Total);
        }
    }
}
