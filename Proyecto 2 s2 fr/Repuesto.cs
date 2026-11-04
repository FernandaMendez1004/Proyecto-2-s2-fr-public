
using System;

namespace Proyecto_2_s2_fr
{
    class Repuesto
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

        private string categoria;

        public string Categoria
        {
            get { return categoria; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    categoria = value;
                }
            }
        }

        private int existencia;

        public int Existencia
        {
            get { return existencia; }
            private set
            {
                if (value >= 0)
                {
                    existencia = value;
                }
            }
        }

        private int existenciaMinima;

        public int ExistenciaMinima
        {
            get { return existenciaMinima; }
            set
            {
                if (value >= 0)
                {
                    existenciaMinima = value;
                }
            }
        }

        private double costoUnitario;

        public double CostoUnitario
        {
            get { return costoUnitario; }
            set
            {
                if (value >= 0)
                {
                    costoUnitario = value;
                }
            }
        }

        private double precioVenta;

        public double PrecioVenta
        {
            get { return precioVenta; }
            set
            {
                if (value >= 0)
                {
                    precioVenta = value;
                }
            }
        }

        private int cantidadUtilizada;

        public int CantidadUtilizada
        {
            get { return cantidadUtilizada; }
            private set
            {
                if (value >= 0)
                {
                    cantidadUtilizada = value;
                }
            }
        }


        public Repuesto(string codigo, string nombre, string categoria, int existencia, int existenciaMinima, double costoUnitario, double precioVenta)
        {
            Codigo = codigo;
            Nombre = nombre;
            Categoria = categoria;
            Existencia = existencia;
            ExistenciaMinima = existenciaMinima;
            CostoUnitario = costoUnitario;
            PrecioVenta = precioVenta;
            CantidadUtilizada = 0;
        }


        public bool UtilizarRepuesto(int cantidad)
        {
            if (cantidad <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("La cantidad debe ser mayor a cero.");
                Console.ResetColor();
                return false;
            }

            if (cantidad > Existencia)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No hay suficientes repuestos.");
                Console.ResetColor();
                return false;
            }

            Existencia = Existencia - cantidad;
            CantidadUtilizada = CantidadUtilizada + cantidad;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Repuesto utilizado correctamente.");
            Console.ResetColor();
            VerificarExistencia();
            return true;
        }


        public bool AgregarExistencia(int cantidad)
        {
            if (cantidad <= 0)
            {
                return false;
            }
            Existencia = Existencia + cantidad;
            return true;
        }

        public void VerificarExistencia()
        {
            if (Existencia == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ALERTA: Repuesto agotado.");
            }

            else if (Existencia <= ExistenciaMinima)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("ADVERTENCIA: Existencia mínima alcanzada.");
            }
            Console.ResetColor();
        }
          

        public double CalcularCosto(int cantidad)
        {
            return CostoUnitario * cantidad;
        }

        public double CalcularPrecio(int cantidad)
        {
            return PrecioVenta * cantidad;
        }


        public void MostrarInformacion()
        {         
            Console.WriteLine("Código: " + Codigo);
            Console.WriteLine("Nombre: " + Nombre);
            Console.WriteLine("Categoría: " + Categoria);
            Console.WriteLine("Existencia: " + Existencia);
            Console.WriteLine("Existencia mínima: " + ExistenciaMinima);
            Console.WriteLine("Costo unitario: Q" + CostoUnitario);
            Console.WriteLine("Precio de venta: Q" + PrecioVenta);
            Console.WriteLine("Cantidad utilizada: " + CantidadUtilizada);
            Console.WriteLine("------------------------------------");
            VerificarExistencia();
        }
    }
}
