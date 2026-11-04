using System;
namespace Proyecto_2_s2_fr
{
    internal class Menus
    {
        public static void MenuPrincipal()
        {
            int opcionMain = 0;
            do
            {
                SirvePaTodo.Titulo("MENÚ PRINCIPAL", ConsoleColor.Cyan);
                SirvePaTodo.OpcionMenu("1", "Gestión de Clientes", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("2", "Gestión de tecnicos", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("3", "Gestión de Equipos", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("4", "Gestión de Solicitudes", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("5", "Gestión de Repuestos", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("6", "Atención y Diagnósticos", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("7", "Reportes ", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("8", "Generar datos de prueba", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("9", "Salir", ConsoleColor.DarkRed);
                SirvePaTodo.PieMenu(ConsoleColor.DarkGray);

                if (!int.TryParse(Console.ReadLine(), out opcionMain))
                {
                    SirvePaTodo.MensajeError("Ingrese la opcion utilizando números enteros");
                    SirvePaTodo.Pausa();
                }
                else
                {
                    switch (opcionMain)
                    {
                        case 1:
                            MenuClientes();
                            break;
                        case 2:
                            MenuTecnicos();
                            break;
                        case 3:
                            MenuEquipos();
                            break;
                        case 4:
                            MenuSolicitudes();
                            break;
                        case 5:
                            MenuRepuestos();
                            break;
                        case 6:
                            MenuAtencionDiagnosticos();
                            break;
                        case 7:
                            MenuReportes();
                            break;
                        case 9:
                            Console.Clear();
                            SirvePaTodo.MensajeExito("                   Bye Gracias por utilizar mi pryecto :) ");
                            break;
                        case 8:
                            GenerarDatosPrueba();
                            break;
                        default:
                            SirvePaTodo.MensajeError("La opcion seleccionada no existe");
                            SirvePaTodo.Pausa();
                            break;
                    }
                }
            } while (opcionMain != 9);
        }
        public static void MenuClientes()
        {
            int opcion = 0;
            do
            {
                SirvePaTodo.Titulo("GESTIÓN DE CLIENTES", ConsoleColor.Cyan);
                SirvePaTodo.OpcionMenu("1", "Registrar cliente", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("2", "Buscar cliente", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("3", "Modificar cliente", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("4", "Mostrar clientes", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("5", "Regresar", ConsoleColor.Yellow);
                SirvePaTodo.PieMenu(ConsoleColor.DarkGray);

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    SirvePaTodo.MensajeError("Ingrese la opcion utilizando números enteros");
                    SirvePaTodo.Pausa();
                }
                else
                {
                    switch (opcion)
                    {
                        case 1:
                            RegistrarCliente();
                            break;
                        case 2:
                            BuscarCliente();
                            break;
                        case 3:
                            ModificarCliente();
                            break;
                        case 4:
                            MostrarClientes();
                            break;
                        case 5:
                            break;
                        default:
                            SirvePaTodo.MensajeError("La opcion seleccionada no existe");
                            SirvePaTodo.Pausa();
                            break;
                    }
                }
            } while (opcion != 5);
        }
        public static void RegistrarCliente()
        {
            SirvePaTodo.Titulo("REGISTRAR CLIENTE", ConsoleColor.Cyan);
            string nombre = "", telefono = "", correo = "", tipo = "",  codigo = "";
            int opcionTipo = 0;
            bool repetido = false, correoValido = false;
            Console.ForegroundColor = ConsoleColor.White;

            do
            {
                Console.WriteLine("Ingrese el nombre:");
                nombre = Console.ReadLine();

                if (!SirvePaTodo.ValidarNombre(nombre))
                { SirvePaTodo.MensajeError("Ingrese un nombre válido, solo letras y espacios"); }

            } while (!SirvePaTodo.ValidarNombre(nombre));
            nombre = nombre.Trim();

            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Ingrese el número de teléfono:");
                telefono = Console.ReadLine();

                if (!SirvePaTodo.ValidarTelefono(telefono))
                {SirvePaTodo.MensajeError("El telefono debe tener 8 numeros"); }

            } while (!SirvePaTodo.ValidarTelefono(telefono));

            do
            {
                correoValido = false;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Ingrese el correo electrónico:");
                correo = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(correo))
                {
                    correo = correo.Trim();
                    int posicionArroba = correo.IndexOf('@');
                    int ultimaArroba = correo.LastIndexOf('@');
                    int posicionPunto = correo.LastIndexOf('.');
                    if (posicionArroba > 0 && posicionArroba == ultimaArroba && posicionPunto > posicionArroba + 1 && posicionPunto < correo.Length - 1 )
                    { correoValido = true; }
                }

                if (correoValido == false)
                {
                    SirvePaTodo.MensajeError("El correo electrónico ingresado no es válido.");
                }

            } while (correoValido == false);

            do
            {
                Console.WriteLine();
                SirvePaTodo.OpcionMenu("1", "Estudiante", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("2", "Profesional", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("3", "Negocio", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("4", "Institución", ConsoleColor.Yellow);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Seleccione el tipo de cliente: ");

                if (!int.TryParse(Console.ReadLine(), out opcionTipo))
                {
                    SirvePaTodo.MensajeError("Debe ingresar un número entero.");
                }

                else
                {
                    if (opcionTipo < 1 || opcionTipo > 4)
                    {
                        SirvePaTodo.MensajeError("Seleccione una opcion valida");
                    }
                }
            } while (opcionTipo < 1 || opcionTipo > 4);

            switch (opcionTipo)
            {
                case 1:
                    tipo = "Estudiante";
                    break;
                case 2:
                    tipo = "Profesional";
                    break;
                case 3:
                    tipo = "Negocio";
                    break;
                case 4:
                    tipo = "Institución";
                    break;
            }

            do
            {
                codigo = SirvePaTodo.GenerarCodigo("CLI");
                repetido = false;

                foreach (Cliente cliente in Program.clientes)
                {
                    if (cliente.Codigo == codigo)
                    {
                        repetido = true;
                    }
                }
            } while (repetido == true);

            Cliente nuevoCliente = new Cliente(codigo, nombre, telefono, correo, tipo, 0);
            Program.clientes.Add(nuevoCliente);
            Console.WriteLine();
            SirvePaTodo.MensajeExito("CORRECTO: Cliente agregado correctamente");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Código del cliente: "+ codigo);
            Console.ResetColor();
            SirvePaTodo.Pausa();
        }
        public static Cliente BuscarClientePorCodigo(string codigo)
        {
            foreach (Cliente cliente in Program.clientes)
            {
                if (cliente.Codigo.ToUpper() == codigo.ToUpper())
                {
                    return cliente;
                }
            }
            return null;
        }
        public static void BuscarCliente()
        {
            SirvePaTodo.Titulo("BUSCAR CLIENTE", ConsoleColor.Cyan);
            if (Program.clientes.Count == 0)
            {
                SirvePaTodo.MensajeError("No existen clientes registrados");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Ingrese el codigo del cliente: ");
                string codigo = Console.ReadLine();
                Cliente encontrado = BuscarClientePorCodigo(codigo);

                if (encontrado == null)
                {
                    SirvePaTodo.MensajeError("No se encontro ningun cliente con ese cdigo");
                }

                else
                {
                    Console.WriteLine();
                    SirvePaTodo.MensajeExito("Cliente encontrado");
                    encontrado.MostrarInformacion();
                }
            }SirvePaTodo.Pausa();
        }
        public static void ModificarCliente()
        {
            SirvePaTodo.Titulo("MODIFICAR CLIENTE", ConsoleColor.Cyan);
            if (Program.clientes.Count == 0)
            {SirvePaTodo.MensajeError("No existen clientes registrados"); }

            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("CLIENTES REGISTRADOS");
                Console.ResetColor();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;

                foreach (Cliente cliente in Program.clientes)
                {
                    Console.WriteLine($"Código: {cliente.Codigo}  |  Nombre: {cliente.Nombre}");
                }

                Console.WriteLine(@"
----------------------------------------
");
                Console.Write("Ingrese el codigo del cliente: ");
                string codigo = Console.ReadLine();
                Cliente encontrado = BuscarClientePorCodigo(codigo);

                if (encontrado == null)
                {
                    SirvePaTodo.MensajeError("Cliente no encontrado");
                }

                else
                {
                    int opcion = 0;
                    do
                    {
                        SirvePaTodo.Titulo("MODIFICAR CLIENTE", ConsoleColor.Cyan);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(@$"Cliente: {encontrado.Nombre}
Codigo: { encontrado.Codigo}
");
                        SirvePaTodo.OpcionMenu("1", "Modificar nombre", ConsoleColor.Yellow);
                        SirvePaTodo.OpcionMenu("2", "Modificar teléfono", ConsoleColor.Yellow);
                        SirvePaTodo.OpcionMenu("3", "Modificar correo", ConsoleColor.Yellow);
                        SirvePaTodo.OpcionMenu("4", "Modificar tipo de cliente", ConsoleColor.Yellow);
                        SirvePaTodo.OpcionMenu("5", "Regresar", ConsoleColor.DarkRed);
                        SirvePaTodo.PieMenu(ConsoleColor.DarkGray);

                        if (!int.TryParse(Console.ReadLine(), out opcion))
                        {
                            SirvePaTodo.MensajeError("Ingrese un número entero.");
                            SirvePaTodo.Pausa();
                        }

                        else
                        {
                            switch (opcion)
                            {
                                case 1:
                                    string nombre;

                                    do
                                    {
                                        Console.Write("Nuevo nombre: ");
                                        nombre = Console.ReadLine();

                                        if (!SirvePaTodo.ValidarNombre(nombre))
                                        {
                                            SirvePaTodo.MensajeError("Solo se permiten letras y espacios en blanco :)");
                                        }

                                    } while (!SirvePaTodo.ValidarNombre(nombre));
                                    encontrado.Nombre = nombre.Trim();
                                    SirvePaTodo.MensajeExito("Nombre actualizado correctamente");
                                    SirvePaTodo.Pausa();
                                    break;

                                case 2:
                                    string telefono;
                                    do
                                    {
                                        Console.Write("Nuevo teléfono: ");
                                        telefono = Console.ReadLine();

                                        if (!SirvePaTodo.ValidarTelefono(telefono))
                                        {
                                            SirvePaTodo.MensajeError("El numero de teléfono debe tener 8 dígitos");
                                        }

                                    } while (!SirvePaTodo.ValidarTelefono(telefono));
                                    encontrado.NumeroTelefono = telefono;
                                    SirvePaTodo.MensajeExito("Telefono actualizado correctamente");
                                    SirvePaTodo.Pausa();
                                    break;

                                case 3:
                                    string correo;
                                    do
                                    {
                                        Console.Write("Nuevo correo: ");
                                        correo = Console.ReadLine();

                                        if (!SirvePaTodo.ValidarCorreo(correo))
                                        {
                                            SirvePaTodo.MensajeError("Ingrese un correo valido");
                                        }
                                    } while (!SirvePaTodo.ValidarCorreo(correo));

                                    encontrado.CorreoElectronico = correo.Trim();
                                    SirvePaTodo.MensajeExito("Correo actualizado correctamente");
                                    SirvePaTodo.Pausa();
                                    break;

                                case 4:
                                    int tipo = 0;
                                    do
                                    {
                                        SirvePaTodo.OpcionMenu("1", "Estudiante", ConsoleColor.Yellow);
                                        SirvePaTodo.OpcionMenu("2", "Profesional", ConsoleColor.Yellow);
                                        SirvePaTodo.OpcionMenu("3", "Negocio", ConsoleColor.Yellow);
                                        SirvePaTodo.OpcionMenu("4", "Institución", ConsoleColor.Yellow);
                                        Console.Write("Seleccione el nuevo tipo: ");

                                        if (!int.TryParse(Console.ReadLine(), out tipo))
                                        {
                                            SirvePaTodo.MensajeError("Ingrese un numero entero");
                                        }

                                        else if (tipo < 1 || tipo > 4)
                                        {
                                            SirvePaTodo.MensajeError("Seleccione una opcion valida");
                                        }

                                    } while (tipo < 1 || tipo > 4);

                                    switch (tipo)
                                    {
                                        case 1:
                                            encontrado.TipoCliente = "Estudiante";
                                            break;
                                        case 2:
                                            encontrado.TipoCliente = "Profesional";
                                            break;
                                        case 3:
                                            encontrado.TipoCliente = "Negocio";
                                            break;
                                        case 4:
                                            encontrado.TipoCliente = "Institución";
                                            break;
                                    }

                                    SirvePaTodo.MensajeExito("Tipo de cliente actualizado");
                                    SirvePaTodo.Pausa();
                                    break;

                                case 5:
                                    break;

                                default:
                                    SirvePaTodo.MensajeError("La opcioon seleccionada no existe");
                                    SirvePaTodo.Pausa();
                                    break;
                            }
                        }
                    } while (opcion != 5);
                }
            }
        }
        public static void MostrarClientes()
        {
            SirvePaTodo.Titulo("CLIENTES REGISTRADOS", ConsoleColor.Cyan);
            if (Program.clientes.Count == 0)
            {
                SirvePaTodo.MensajeError("No existen clientes registrados");
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Total de clientes: {Program.clientes.Count}");
                Console.WriteLine();
                foreach (Cliente cliente in Program.clientes)
                {
                    Console.WriteLine("----------------------------------------");
                    cliente.MostrarInformacion();
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine();
                }
            } SirvePaTodo.Pausa();
        }
        public static void MenuTecnicos()
        {
            int opcion = 0;
            do
            {
                SirvePaTodo.Titulo("GESTIÓN DE TECNICOS", ConsoleColor.Cyan);
                SirvePaTodo.OpcionMenu("1", "Registrar tecnico", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("2", "Buscar tecnico", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("3", "Modificar tecnico", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("4", "Mostrar tecnicos", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("5", "Regresar", ConsoleColor.DarkRed);
                SirvePaTodo.PieMenu(ConsoleColor.DarkGray);

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    SirvePaTodo.MensajeError("Ingrese solos numeros enteros");
                    SirvePaTodo.Pausa();
                }

                else
                {
                    switch (opcion)
                    {
                        case 1:
                            RegistrarTecnico();
                            break;

                        case 2:
                            BuscarTecnico();
                            break;

                        case 3:
                            ModificarTecnico();
                            break;

                        case 4:
                            MostrarTecnicos();
                            break;

                        case 5:
                            break;

                        default:
                            SirvePaTodo.MensajeError("La opcion no existe");
                            SirvePaTodo.Pausa();
                            break;
                    }
                }
            } while (opcion != 5);
        }
        public static void RegistrarTecnico()
        {
            SirvePaTodo.Titulo("REGISTRAR tecnico", ConsoleColor.Cyan);
            string nombre = "", codigo = "";
            int opcionEspecialidad = 0;
            Especialidad especialidad = Especialidad.General;
            bool repetido = false;
            Console.ForegroundColor = ConsoleColor.White;

            do
            {
                Console.WriteLine("Ingrese el nombre:");
                nombre = Console.ReadLine();

                if (!SirvePaTodo.ValidarNombre(nombre))
                {
                    SirvePaTodo.MensajeError("El nombre solo debe tener letras y espacios en blancos");
                }

            } while (!SirvePaTodo.ValidarNombre(nombre));

            do
            {
                Console.WriteLine();
                SirvePaTodo.OpcionMenu("1", "Computadoras", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("2", "Impresoras", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("3", "General", ConsoleColor.Yellow);
                Console.Write("Seleccione la especialidad: ");

                if (!int.TryParse(Console.ReadLine(), out opcionEspecialidad))
                {
                    SirvePaTodo.MensajeError("Ingrese un numero entero");
                }

                else if (opcionEspecialidad < 1 || opcionEspecialidad > 3)
                {
                    SirvePaTodo.MensajeError("Seleccione una especialidad valida sino se cae el programa");
                }
            } while (opcionEspecialidad < 1 || opcionEspecialidad > 3);

            switch (opcionEspecialidad)
            {
                case 1:
                    especialidad = Especialidad.Computadoras;
                    break;
                case 2:
                    especialidad = Especialidad.Impresoras;
                    break;
                case 3:
                    especialidad = Especialidad.General;
                    break;
            }

            do
            {
                codigo = SirvePaTodo.GenerarCodigo("TEC");
                repetido = false;

                foreach (Tecnico tecnico in Program.tecnicos)
                {
                    if (tecnico.Codigo == codigo)
                    { repetido = true; }
                }
            } while (repetido == true);

            Tecnico nuevoTecnico = new Tecnico(codigo, nombre.Trim(), especialidad, true, 0, 0, 0);
            Program.tecnicos.Add(nuevoTecnico);
            Console.WriteLine();

            SirvePaTodo.MensajeExito("CORRECTO: Tecnico registrado correctamente");
            Console.WriteLine($"Codigo generado: {codigo}");
            SirvePaTodo.Pausa();
        }    
        public static Tecnico BuscarTecnicoPorCodigo(string codigo)
        {
            foreach (Tecnico tecnico in Program.tecnicos)
            {
                if (tecnico.Codigo.ToUpper() == codigo.ToUpper())
                { return tecnico; }

            }
            return null;
        }
        public static void BuscarTecnico()
        {
            SirvePaTodo.Titulo("BUSCAR TECNICO", ConsoleColor.Cyan);
            if (Program.tecnicos.Count == 0)
            {
                SirvePaTodo.MensajeError("No existen tecnicos registrados");
            }

            else
            {
                Console.WriteLine("TECNICOS REGISTRADOS");
                Console.WriteLine();

                foreach (Tecnico tecnico in Program.tecnicos)
                {
                    Console.WriteLine(@$"Codigo: {tecnico.Codigo} | Nombre: {tecnico.Nombre}");
                }

                Console.WriteLine();
                Console.Write("Ingrese el codigo del tecnico: ");
                string codigo = Console.ReadLine();
                Tecnico encontrado = BuscarTecnicoPorCodigo(codigo);

                if (encontrado == null)
                {
                    SirvePaTodo.MensajeError("Tecnico no encontrado.");
                }

                else
                {
                    encontrado.MostrarInformacion();
                }
            }SirvePaTodo.Pausa();
        }
        public static void ModificarTecnico()
        {
            SirvePaTodo.Titulo("MODIFICAR TECNICO", ConsoleColor.Cyan);
            if (Program.tecnicos.Count == 0)
            {
                SirvePaTodo.MensajeError("No existen tecnicos registrados");
                SirvePaTodo.Pausa();
            }

            else
            {
                Console.WriteLine("TECNICOS REGISTRADOS");
                Console.WriteLine();

                foreach (Tecnico tecnico in Program.tecnicos)
                {
                    Console.WriteLine($"Código: {tecnico.Codigo} | Nombre: {tecnico.Nombre}");
                }

                Console.WriteLine();
                Console.Write("Ingrese el codigo del tecnico: ");
                string codigo = Console.ReadLine();
                Tecnico encontrado = BuscarTecnicoPorCodigo(codigo);

                if (encontrado == null)
                {
                    SirvePaTodo.MensajeError("Tecnico no encontrado");
                    SirvePaTodo.Pausa();
                }

                else
                {
                    int opcion = 0;
                    do
                    {
                        SirvePaTodo.Titulo("MODIFICAR TECNICO", ConsoleColor.Cyan);
                        Console.WriteLine($"Tecnico: {encontrado.Nombre}");
                        Console.WriteLine($"Codigo: {encontrado.Codigo}");
                        Console.WriteLine();
                        SirvePaTodo.OpcionMenu("1", "Modificar nombre", ConsoleColor.Yellow);
                        SirvePaTodo.OpcionMenu("2", "Modificar especialidad", ConsoleColor.Yellow);
                        SirvePaTodo.OpcionMenu("3", "Modificar disponibilidad", ConsoleColor.Yellow);
                        SirvePaTodo.OpcionMenu("4", "Regresar", ConsoleColor.DarkRed);
                        SirvePaTodo.PieMenu(ConsoleColor.DarkGray);

                        if (!int.TryParse(Console.ReadLine(), out opcion))
                        {
                            SirvePaTodo.MensajeError("Ingrese un numero entero");
                            SirvePaTodo.Pausa();
                        }

                        else
                        {
                            switch (opcion)
                            {
                                case 1:
                                    string nombre;

                                    do
                                    {
                                        Console.Write("Nuevo nombre: ");
                                        nombre = Console.ReadLine();
                                        if (!SirvePaTodo.ValidarNombre(nombre))
                                        {
                                            SirvePaTodo.MensajeError("Nombre no valido");
                                        }
                                    } while (!SirvePaTodo.ValidarNombre(nombre));
                                    encontrado.Nombre = nombre.Trim();
                                    SirvePaTodo.MensajeExito("Nombre actualizado correctamente");
                                    SirvePaTodo.Pausa();
                                    break;

                                case 2:
                                    int especialidad = 0;
                                    do
                                    {
                                        SirvePaTodo.OpcionMenu("1", "Computadoras", ConsoleColor.Yellow);
                                        SirvePaTodo.OpcionMenu("2", "Impresoras", ConsoleColor.Yellow);
                                        SirvePaTodo.OpcionMenu("3", "General", ConsoleColor.Yellow);
                                        Console.Write("Seleccione la especialidad: ");

                                        if (!int.TryParse(Console.ReadLine(), out especialidad))
                                        {
                                            SirvePaTodo.MensajeError("Ingrese un numero entero");
                                        }

                                        else if (especialidad < 1 || especialidad > 3)
                                        {
                                            SirvePaTodo.MensajeError("Opcion no valida");
                                        }

                                    } while (especialidad < 1 || especialidad > 3);

                                    switch (especialidad)
                                    {
                                        case 1:
                                            encontrado.Especialidad = Especialidad.Computadoras;
                                            break;

                                        case 2:
                                            encontrado.Especialidad = Especialidad.Impresoras;
                                            break;

                                        case 3:
                                            encontrado.Especialidad = Especialidad.General;
                                            break;
                                    }
                                    SirvePaTodo.MensajeExito("Especialidad actualizada");
                                    SirvePaTodo.Pausa();
                                    break;

                                case 3:
                                    int disponibilidad = 0;
                                    do
                                    {
                                        SirvePaTodo.OpcionMenu("1", "Disponible", ConsoleColor.Yellow);
                                        SirvePaTodo.OpcionMenu("2", "No disponible", ConsoleColor.Yellow);
                                        Console.Write("Seleccione el estado: ");

                                        if (!int.TryParse(Console.ReadLine(), out disponibilidad))
                                        {
                                            SirvePaTodo.MensajeError("Ingrese un numero entero");
                                        }

                                        else if (disponibilidad < 1 || disponibilidad > 2)
                                        {
                                            SirvePaTodo.MensajeError("Opcion no valida");
                                        }
                                    } while (disponibilidad < 1 || disponibilidad > 2);

                                    if (disponibilidad == 1)
                                    {encontrado.Disponibilidad = true;}

                                    else
                                    {encontrado.Disponibilidad = false;}

                                    SirvePaTodo.MensajeExito("Disponibilidad actualizada.");
                                    SirvePaTodo.Pausa();
                                    break;

                                case 4:
                                    break;

                                default:
                                    SirvePaTodo.MensajeError("La opcion no existe.");
                                    SirvePaTodo.Pausa();
                                    break;
                            }
                        }
                    } while (opcion != 4);
                }
            }
        }

        public static void MostrarTecnicos()
        {
            SirvePaTodo.Titulo("TECNICOS REGISTRADOS", ConsoleColor.Cyan);

            if (Program.tecnicos.Count == 0)
            {
                SirvePaTodo.MensajeError("No existen tecnicos registrados.");
            }

            else
            {
                Console.WriteLine($"Total de tecnicos: {Program.tecnicos.Count}");
                Console.WriteLine();
                foreach (Tecnico tecnico in Program.tecnicos)
                {
                    tecnico.MostrarInformacion();
                    Console.WriteLine();
                }
            }
            SirvePaTodo.Pausa();
        }
        public static void MenuEquipos()
        {
            int opcion = 0;
            do
            {
                SirvePaTodo.Titulo("GESTION DE EQUIPOS", ConsoleColor.Cyan);
                SirvePaTodo.OpcionMenu("1", "Registrar equipo", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("2", "Buscar equipo", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("3", "Modificar equipo", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("4", "Mostrar equipos", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("5", "Regresar", ConsoleColor.DarkRed);
                SirvePaTodo.PieMenu(ConsoleColor.DarkGray);

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    SirvePaTodo.MensajeError("Ingrese un numero entero");
                    SirvePaTodo.Pausa();
                }

                else
                {
                    switch (opcion)
                    {
                        case 1:
                            RegistrarEquipo();
                            break;
                        case 2:
                            BuscarEquipo();
                            break;
                        case 3:
                            ModificarEquipo();
                            break;
                        case 4:
                            MostrarEquipos();
                            break;
                        case 5:
                            break;
                        default:
                            SirvePaTodo.MensajeError("La opcion seleccionada no existe");
                            SirvePaTodo.Pausa();
                            break;
                    }
                }
            } while (opcion != 5);
        }

        public static void RegistrarEquipo()
        {
            SirvePaTodo.Titulo("REGISTRAR EQUIPO", ConsoleColor.Cyan);

            if (Program.clientes.Count == 0)
            {
                SirvePaTodo.MensajeError("Debe registrar al menos un cliente");
                SirvePaTodo.Pausa();
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("CLIENTES REGISTRADOS");
                Console.ResetColor();

                foreach (Cliente cliente in Program.clientes)
                {
                    Console.WriteLine($"Codigo:  {cliente.Codigo} | Nombre: {cliente.Nombre}");
                }

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Ingrese el codigo del propietario: ");
                string codigoCliente = Console.ReadLine();
                Cliente propietario = BuscarClientePorCodigo(codigoCliente);

                if (propietario == null)
                {
                    SirvePaTodo.MensajeError("El cliente seleccionado no existe.");
                    SirvePaTodo.Pausa();
                }

                else
                {
                    int tipo = 0;
                    do
                    {
                        Console.WriteLine();
                        SirvePaTodo.OpcionMenu("1", "Computadora portátil", ConsoleColor.Yellow);
                        SirvePaTodo.OpcionMenu("2", "Computadora de escritorio", ConsoleColor.Yellow);
                        SirvePaTodo.OpcionMenu("3", "Impresora", ConsoleColor.Yellow);
                        Console.Write("Seleccione el tipo de equipo: ");

                        if (!int.TryParse(Console.ReadLine(), out tipo))
                        {
                            SirvePaTodo.MensajeError("Ingrese un numero entero");
                        }

                        else if (tipo < 1 || tipo > 3)
                        {
                            SirvePaTodo.MensajeError("Seleccione una opcion valida");
                        }
                    } while (tipo < 1 || tipo > 3);

                    string serie = "";
                    bool repetida;

                    do
                    {
                        repetida = false;
                        Console.Write("Numero de serie: ");
                        serie = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(serie))
                        {
                            SirvePaTodo.MensajeError("El numero de serie no puede estar vacio");
                            repetida = true;
                        }

                        else
                        {
                            serie = serie.Trim();
                            foreach (Equipo equipo in Program.equipos)
                            {
                                if (equipo.NumeroSerie.ToUpper() == serie.ToUpper())
                                {
                                    repetida = true;
                                }
                            }

                            if (repetida)
                            {
                                SirvePaTodo.MensajeError("El número de serie ya esta registrado");
                            }
                        }
                    } while (repetida);

                    string marca = "", modelo = "", estado = "", accesorios = "";
                    do
                    {
                        Console.Write("Marca: ");
                        marca = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(marca))
                        {
                            SirvePaTodo.MensajeError("La marca no puede estar vacia");
                        }
                    } while (string.IsNullOrWhiteSpace(marca));

                    do
                    {
                        Console.Write("Modelo: ");
                        modelo = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(modelo))
                        {
                            SirvePaTodo.MensajeError("El modelo no puede estar vacío");
                        }
                    } while (string.IsNullOrWhiteSpace(modelo));

                    do
                    {
                        Console.Write("Estado fisico: ");
                        estado = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(estado))
                        {
                            SirvePaTodo.MensajeError("Debe indicar el estado físico");
                        }
                    } while (string.IsNullOrWhiteSpace(estado));

                    Console.Write("Accesorios incluidos (ninguno si no tiene): ");
                    accesorios = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(accesorios))
                    {
                        accesorios = "Ninguno";
                    }

                    string codigo = "";
                    bool codigoRepetido;

                    do
                    {
                        codigoRepetido = false;
                        if (tipo == 1)
                        {
                            codigo = SirvePaTodo.GenerarCodigo("POR");
                        }

                        else if (tipo == 2)
                        {
                            codigo = SirvePaTodo.GenerarCodigo("ESC");
                        }

                        else
                        {
                            codigo = SirvePaTodo.GenerarCodigo("IMP");
                        }

                        foreach (Equipo equipo in Program.equipos)
                        {
                            if (equipo.Codigo == codigo)
                            {
                                codigoRepetido = true;
                            }
                        }
                    } while (codigoRepetido);

                    Equipo nuevoEquipo = null;
                    if (tipo == 1)
                    {
                        nuevoEquipo = new ComputadoraPortatil(codigo, serie, marca.Trim(), modelo.Trim(), propietario, estado.Trim(), accesorios.Trim(), false);
                    }

                    else if (tipo == 2)
                    {
                        nuevoEquipo = new ComputadoraEscritorio(codigo, serie, marca.Trim(), modelo.Trim(), propietario, estado.Trim(), accesorios.Trim(), false);
                    }

                    else
                    {
                        nuevoEquipo = new Impresora(codigo, serie, marca.Trim(), modelo.Trim(), propietario, estado.Trim(), accesorios.Trim(), "No especificado");
                    }

                    Program.equipos.Add(nuevoEquipo);
                    Console.WriteLine();
                    SirvePaTodo.MensajeExito("CORRECTO: Equipo registrado correctamente");
                    Console.WriteLine($"Codigo generado: {codigo}");
                    SirvePaTodo.Pausa();
                }
            }
        }
        public static Equipo BuscarEquipoPorCodigo(string codigo)
        {
            foreach (Equipo equipo in Program.equipos)
            {
                if (equipo.Codigo.ToUpper() == codigo.ToUpper())
                {
                    return equipo;
                }
            }
            return null;
        }
        public static void BuscarEquipo()
        {
            SirvePaTodo.Titulo("BUSCAR EQUIPO", ConsoleColor.Cyan);
            if (Program.equipos.Count == 0)
            {
                SirvePaTodo.MensajeError("No existen equipos registrados");
            }

            else
            {
                Console.WriteLine("EQUIPOS REGISTRADOS");
                Console.WriteLine();

                foreach (Equipo equipo in Program.equipos)
                {
                    Console.WriteLine($"Código: {equipo.Codigo} | Marca: {equipo.Marca} | Modelo: {equipo.Modelo}");
                }

                Console.WriteLine();
                Console.Write("Ingrese el código del equipo: ");
                string codigo = Console.ReadLine();
                Equipo encontrado = BuscarEquipoPorCodigo(codigo);

                if (encontrado == null)
                {
                    SirvePaTodo.MensajeError("Equipo no encontrado");
                }

                else
                {
                    Console.WriteLine();
                    encontrado.MostrarInformacion();
                }
            }
            SirvePaTodo.Pausa();
        }
        public static void ModificarEquipo()
        {
            SirvePaTodo.Titulo("MODIFICAR EQUIPO", ConsoleColor.Cyan);
            if (Program.equipos.Count == 0)
            {
                SirvePaTodo.MensajeError("No existen equipos registrados");
                SirvePaTodo.Pausa();
            }

            else
            {
                Console.WriteLine("EQUIPOS REGISTRADOS");
                Console.WriteLine();

                foreach (Equipo equipo in Program.equipos)
                {
                    Console.WriteLine($"Código:  {equipo.Codigo}  | Marca: {equipo.Marca} | Modelo: {equipo.Modelo}");
                }

                Console.WriteLine();
                Console.Write("Ingrese el codigo del equipo: ");
                string codigo = Console.ReadLine();
                Equipo encontrado = BuscarEquipoPorCodigo(codigo);

                if (encontrado == null)
                {
                    SirvePaTodo.MensajeError("Equipo no encontrado");
                    SirvePaTodo.Pausa();
                }

                else
                {
                    int opcion = 0;
                    do
                    {
                        SirvePaTodo.Titulo("MODIFICAR EQUIPO", ConsoleColor.Cyan);
                        Console.WriteLine($"Código: {encontrado.Codigo}");
                        Console.WriteLine($"Equipo: {encontrado.Marca}   {encontrado.Modelo}");
                        Console.WriteLine();
                        SirvePaTodo.OpcionMenu("1", "Modificar marca", ConsoleColor.Yellow);
                        SirvePaTodo.OpcionMenu("2", "Modificar modelo", ConsoleColor.Yellow);
                        SirvePaTodo.OpcionMenu("3", "Modificar estado físico", ConsoleColor.Yellow);
                        SirvePaTodo.OpcionMenu("4", "Modificar accesorios", ConsoleColor.Yellow);
                        SirvePaTodo.OpcionMenu("5", "Regresar", ConsoleColor.DarkRed);
                        SirvePaTodo.PieMenu(ConsoleColor.DarkGray);

                        if (!int.TryParse(Console.ReadLine(), out opcion))
                        {
                            SirvePaTodo.MensajeError("Ingrese un numero entero");
                            SirvePaTodo.Pausa();
                        }

                        else
                        {
                            switch (opcion)
                            {
                                case 1:
                                    string marca = "";
                                    do
                                    {
                                        Console.Write("Nueva marca: ");
                                        marca = Console.ReadLine();

                                        if (string.IsNullOrWhiteSpace(marca))
                                        {
                                            SirvePaTodo.MensajeError("La marca no puede estar vacia");
                                        }
                                    } while (string.IsNullOrWhiteSpace(marca));

                                    encontrado.Marca = marca.Trim();
                                    SirvePaTodo.MensajeExito("Marca actualizada");
                                    SirvePaTodo.Pausa();
                                    break;

                                case 2:
                                    string modelo = "";
                                    do
                                    {
                                        Console.Write("Nuevo modelo: ");
                                        modelo = Console.ReadLine();

                                        if (string.IsNullOrWhiteSpace(modelo))
                                        {
                                            SirvePaTodo.MensajeError("El modelo no puede estar vacio");
                                        }
                                    } while (string.IsNullOrWhiteSpace(modelo));

                                    encontrado.Modelo = modelo.Trim();
                                    SirvePaTodo.MensajeExito("Modelo actualizado");
                                    SirvePaTodo.Pausa();
                                    break;

                                case 3:
                                    string estado = "";
                                    do
                                    {
                                        Console.Write("Nuevo estado físico: ");
                                        estado = Console.ReadLine();

                                        if (string.IsNullOrWhiteSpace(estado))
                                        {
                                            SirvePaTodo.MensajeError("El estado no puede estar vacío.");
                                        }
                                    } while (string.IsNullOrWhiteSpace(estado));

                                    encontrado.EstadoFisico = estado.Trim();
                                    SirvePaTodo.MensajeExito("Estado físico actualizado");
                                    SirvePaTodo.Pausa();
                                    break;

                                case 4:
                                    Console.Write("Nuevos accesorios: ");
                                    string accesorios = Console.ReadLine();

                                    if (string.IsNullOrWhiteSpace(accesorios))
                                    {
                                        accesorios = "Ninguno";
                                    }

                                    encontrado.Accesorios = accesorios.Trim();
                                    SirvePaTodo.MensajeExito("Accesorios actualizados");
                                    SirvePaTodo.Pausa();
                                    break;

                                case 5:
                                    break;

                                default:
                                    SirvePaTodo.MensajeError("La opcion seleccionada no existe");
                                    SirvePaTodo.Pausa();
                                    break;
                            }
                        }
                    } while (opcion != 5);
                }
            }
        }

        public static void MostrarEquipos()
        {
            SirvePaTodo.Titulo("EQUIPOS REGISTRADOS", ConsoleColor.Cyan);
            if (Program.equipos.Count == 0)
            {
                SirvePaTodo.MensajeError("No existen equipos registrados");
            }

            else
            {
                Console.WriteLine($"Total de equipos: {Program.equipos.Count}");
                Console.WriteLine();
                foreach (Equipo equipo in Program.equipos)
                {
                    equipo.MostrarInformacion();
                    Console.WriteLine();
                }
            }
            SirvePaTodo.Pausa();
        }

        public static void MenuSolicitudes()
        {
            int opcion = 0;
            do
            {
                SirvePaTodo.Titulo("GESTIÓN DE SOLICITUDES", ConsoleColor.Cyan);
                SirvePaTodo.OpcionMenu("1", "Registrar solicitud", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("2", "Buscar solicitud", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("3", "Asignar tecnico", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("4", "Cambiar estado de solicitud", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("5", "Mostrar solicitudes", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("6", "Regresar", ConsoleColor.DarkRed);
                SirvePaTodo.PieMenu(ConsoleColor.DarkGray);

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    SirvePaTodo.MensajeError("Ingrese un número entero");
                    SirvePaTodo.Pausa();
                }

                else
                {
                    switch (opcion)
                    {
                        case 1:
                            RegistrarSolicitud();
                            break;
                        case 2:
                            BuscarSolicitud();
                            break;
                        case 3:
                            AsignarTecnico();
                            break;
                        case 4:
                            CambiarEstadoSolicitud();
                            break;
                        case 5:
                            MostrarSolicitudes();
                            break;
                        case 6:
                            break;
                        default:
                            SirvePaTodo.MensajeError("La opcion seleccionada no existe");
                            SirvePaTodo.Pausa();
                            break;
                    }
                }
            } while (opcion != 6);
        }
        public static void RegistrarSolicitud()
        {
            SirvePaTodo.Titulo("REGISTRAR SOLICITUD", ConsoleColor.Cyan);
            if (Program.clientes.Count == 0)
            {
                SirvePaTodo.MensajeError("Primero debe registrar un cliente");
                SirvePaTodo.Pausa();
                return;
            }

            if (Program.equipos.Count == 0)
            {
                SirvePaTodo.MensajeError("Primero debe registrar un equipo");
                SirvePaTodo.Pausa();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("CLIENTES REGISTRADOS");
            Console.ForegroundColor = ConsoleColor.White;

            foreach (Cliente cliente in Program.clientes)
            {
                Console.WriteLine($"Código: {cliente.Codigo} | Nombre: {cliente.Nombre}");
            }
            Console.WriteLine();
            Cliente propietario = null;

            do
            {
                Console.Write("Ingrese el codigo del cliente: ");
                string codigoCliente = Console.ReadLine();
                propietario = BuscarClientePorCodigo(codigoCliente);

                if (propietario == null)
                {
                    SirvePaTodo.MensajeError("El cliente no existe");
                }
            } while (propietario == null);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("EQUIPOS DEL CLIENTE");
            Console.ForegroundColor = ConsoleColor.White;
            int cantidadEquipos = 0;

            foreach (Equipo equipo in Program.equipos)
            {
                if (equipo.Propietario.Codigo == propietario.Codigo)
                {
                    Console.WriteLine($"Código: {equipo.Codigo} | Tipo:  { equipo.TipoEquipo} | Marca: {equipo.Marca} | Modelo: {equipo.Modelo}");
                    cantidadEquipos++;
                }
            }

            if (cantidadEquipos == 0)
            {
                SirvePaTodo.MensajeError("Este cliente no tiene equipos registrado");
                SirvePaTodo.Pausa();
                return;
            }

            Console.WriteLine();
            Equipo equipoSeleccionado = null;
            do
            {
                Console.Write("Ingrese el codigo del equipo: ");
                string codigoEquipo = Console.ReadLine();
                Equipo equipoEncontrado = BuscarEquipoPorCodigo(codigoEquipo);

                if (equipoEncontrado == null)
                {
                    SirvePaTodo.MensajeError("El equipo no existe");
                }

                else if (equipoEncontrado.Propietario.Codigo != propietario.Codigo)
                {
                    SirvePaTodo.MensajeError("El equipo no pertenece al cliente seleccionado");
                }

                else
                {
                    equipoSeleccionado = equipoEncontrado;
                }

            } while (equipoSeleccionado == null);

            Console.WriteLine();
            string descripcion = "";

            do
            {
                Console.WriteLine("Describa el problema del equipo:");
                descripcion = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(descripcion))
                {
                    SirvePaTodo.MensajeError(" La descripción no puede estar vacía.");
                }
            } while (string.IsNullOrWhiteSpace(descripcion));

            int opcionPrioridad = 0;
            do
            {
                Console.WriteLine();
                SirvePaTodo.OpcionMenu("1", "Normal", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("2", "Urgente", ConsoleColor.Yellow);
                Console.Write("Seleccione la prioridad: ");

                if (!int.TryParse(Console.ReadLine(), out opcionPrioridad))
                {
                    SirvePaTodo.MensajeError(" Ingrese un número entero.");
                }

                else if (opcionPrioridad < 1 || opcionPrioridad > 2)
                {
                    SirvePaTodo.MensajeError(" Seleccione una opcion válida.");
                }
            } while (opcionPrioridad < 1 || opcionPrioridad > 2);

            PrioridadSolicitud prioridad = PrioridadSolicitud.Normal;

            if (opcionPrioridad == 2)
            {
                prioridad = PrioridadSolicitud.Urgente;
            }

            string codigo = "";
            bool repetido;

            do
            {
                codigo = SirvePaTodo.GenerarCodigo("SOL");
                repetido = false;
                foreach (Solicitud solicitud in Program.solicitudes)
                {
                    if (solicitud.Codigo == codigo)
                    {
                        repetido = true;
                    }
                }
            } while (repetido);
            Solicitud nuevaSolicitud = new Solicitud( codigo, propietario, equipoSeleccionado, descripcion.Trim(), prioridad);
            Program.solicitudes.Add(nuevaSolicitud);
          
            nuevaSolicitud.CambiarEstado(EstadoSolicitud.EnEspera);
            if (prioridad == PrioridadSolicitud.Urgente)
            {
                Program.colaUrgente.Enqueue(nuevaSolicitud);
            }

            else
            {
                Program.colaNormal.Enqueue(nuevaSolicitud);
            }

            propietario.CantidadSolicitudes++;
            Console.WriteLine();
            SirvePaTodo.MensajeExito("CORRECTO: Solicitud registrada correctamente");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Código: "+ codigo);
            Console.WriteLine("Cliente: "+ propietario.Nombre);
            Console.WriteLine("Equipo: "+ equipoSeleccionado.TipoEquipo);
            Console.WriteLine("Prioridad: "+ prioridad);
            Console.WriteLine("Estado: "+ nuevaSolicitud.Estado);
            SirvePaTodo.Pausa();
        }

        public static Solicitud BuscarSolicitudPorCodigo(string codigo)
        {
            foreach (Solicitud solicitud in Program.solicitudes)
            {
                if (solicitud.Codigo.ToUpper() == codigo.ToUpper())
                {
                    return solicitud;
                }
            }
            return null;
        }

        public static void BuscarSolicitud()
        {
            SirvePaTodo.Titulo("BUSCAR SOLICITUD", ConsoleColor.Cyan);
            if (Program.solicitudes.Count == 0)
            {
                SirvePaTodo.MensajeError(" No existen solicitudes registradas");
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("SOLICITUDES REGISTRADAS");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();

                foreach (Solicitud solicitud in Program.solicitudes)
                {
                    Console.WriteLine("Código: "+ solicitud.Codigo + "| Cliente: "+ solicitud.Cliente.Nombre + "| Estado: "+ solicitud.Estado);
                }

                Console.WriteLine();
                Console.Write("Ingrese el código de la solicitud: ");
                string codigo = Console.ReadLine();
                Solicitud encontrada = BuscarSolicitudPorCodigo(codigo);

                if (encontrada == null)
                {
                    SirvePaTodo.MensajeError(" No se encontró la solicitud.");
                }

                else
                {
                    Console.WriteLine();
                    SirvePaTodo.MensajeExito("Solicitud encontrada correctamente.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    encontrada.MostrarInformacion();
                }
            }
            SirvePaTodo.Pausa();
        }
        public static void AsignarTecnico()
        {
            SirvePaTodo.Titulo("ASIGNAR tecnico", ConsoleColor.Cyan);
            if (Program.solicitudes.Count == 0)
            {
                SirvePaTodo.MensajeError("No existen solicitudes registradas.");
                SirvePaTodo.Pausa();
                return;
            }

            if (Program.tecnicos.Count == 0)
            {
                SirvePaTodo.MensajeError("No existen tecnicos registrados.");
                SirvePaTodo.Pausa();
                return;
            }
                        
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("SOLICITUDES EN ESPERA");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            int pendientes = 0;
            foreach (Solicitud solicitud in Program.solicitudes)
            {
                if (solicitud.Estado == EstadoSolicitud.EnEspera)
                {
                    Console.WriteLine("Código: "+ solicitud.Codigo + "| Prioridad: "+ solicitud.Prioridad + "| Equipo: "+ solicitud.Equipo.TipoEquipo);
                    pendientes++;
                }
            }

            if (pendientes == 0)
            {
                SirvePaTodo.MensajeError(" No existen solicitudes pendientes.");
                SirvePaTodo.Pausa();
                return;
            }

            Console.WriteLine();
            Solicitud primeraUrgente = null;

            foreach (Solicitud solicitud in Program.colaUrgente)
            {
                if (solicitud.Estado == EstadoSolicitud.EnEspera)
                {
                    primeraUrgente = solicitud;
                    break;
                }
            }
            Solicitud primeraNormal = null;

            if (primeraUrgente == null)
            {
                foreach (Solicitud solicitud in Program.colaNormal)
                {
                    if (solicitud.Estado == EstadoSolicitud.EnEspera)
                    {
                        primeraNormal = solicitud;
                        break;
                    }
                }
            }
            Solicitud seleccionada = null;

            do
            {
                Console.Write("Ingrese el código de la solicitud: ");
                string codigo = Console.ReadLine();
                seleccionada = BuscarSolicitudPorCodigo(codigo);

                if (seleccionada == null)
                {
                    SirvePaTodo.MensajeError(" La solicitud no existe.");
                }

                else if (seleccionada.Estado != EstadoSolicitud.EnEspera)
                {
                    SirvePaTodo.MensajeError(" La solicitud no está en espera.");
                    seleccionada = null;
                }

                else if (primeraUrgente != null && seleccionada.Codigo != primeraUrgente.Codigo)
                {
                    SirvePaTodo.MensajeError(" Debe atender primero la solicitud urgente "+ primeraUrgente.Codigo);
                    seleccionada = null;
                }

                else if (primeraNormal != null && seleccionada.Codigo != primeraNormal.Codigo)
                {
                    SirvePaTodo.MensajeError(" Debe atender primero la solicitud normal "+ primeraNormal.Codigo);
                    seleccionada = null;
                }
            } while (seleccionada == null);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("tecnicoS DISPONIBLES");
            Console.ForegroundColor = ConsoleColor.White;
            int disponibles = 0;

            foreach (Tecnico tecnico in Program.tecnicos)
            {
                if (tecnico.Disponibilidad == true)
                {
                    Console.WriteLine("Código: "+ tecnico.Codigo + "| Nombre: "+ tecnico.Nombre + "| Especialidad: "+ tecnico.Especialidad);
                    disponibles++;
                }
            }

            if (disponibles == 0)
            {
                SirvePaTodo.MensajeError(" No existen tecnicos disponibles");
                SirvePaTodo.Pausa();
                return;
            }
            Console.WriteLine();
            Tecnico tecnicoSeleccionado = null;

            do
            {
                Console.Write("Ingrese el código del tecnico: ");
                string codigo = Console.ReadLine();
                tecnicoSeleccionado = BuscarTecnicoPorCodigo(codigo);

                if (tecnicoSeleccionado == null)
                {
                    SirvePaTodo.MensajeError("El tecnico no existe");
                }
                else if (tecnicoSeleccionado.Disponibilidad == false)
                {
                    SirvePaTodo.MensajeError("El tecnico no está disponible");
                    tecnicoSeleccionado = null;
                }
            } while (tecnicoSeleccionado == null);

            seleccionada.TecnicoAsignado = tecnicoSeleccionado;
            if (seleccionada.CambiarEstado(EstadoSolicitud.Asignada))
            {
                tecnicoSeleccionado.TrabajosActivos++;

                if (seleccionada.Prioridad == PrioridadSolicitud.Urgente)
                {
                    Program.colaUrgente.Dequeue();
                }

                else
                {
                    Queue<Solicitud> nuevaCola = new Queue<Solicitud>();
                    foreach (Solicitud solicitud in Program.colaNormal)
                    {
                        if (solicitud.Codigo != seleccionada.Codigo)
                        {
                            nuevaCola.Enqueue(solicitud);
                        }
                    }
                    Program.colaNormal = nuevaCola;
                }
                SirvePaTodo.MensajeExito("CORRECTO: tecnico asignado correctamente.");
                Console.WriteLine();
                Console.WriteLine("Solicitud: "+ seleccionada.Codigo);
                Console.WriteLine("tecnico: "+ tecnicoSeleccionado.Nombre);
                Console.WriteLine("Estado: "+ seleccionada.Estado);
            }

            else
            {
                seleccionada.TecnicoAsignado = null;
                SirvePaTodo.MensajeError(" No se pudo asignar el tecnico.");
            }
            SirvePaTodo.Pausa();
        }
        public static void CambiarEstadoSolicitud()
        {
            SirvePaTodo.Titulo("CAMBIAR ESTADO DE SOLICITUD", ConsoleColor.Cyan);
            if (Program.solicitudes.Count == 0)
            {
                SirvePaTodo.MensajeError(" No existen solicitudes registradas.");
                SirvePaTodo.Pausa();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("SOLICITUDES REGISTRADAS");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            foreach (Solicitud solicitud in Program.solicitudes)
            {
                Console.WriteLine("Código: "+ solicitud.Codigo + "| Estado: "+ solicitud.Estado + "| Prioridad: "+ solicitud.Prioridad);
            }

            Console.WriteLine();
            Console.Write("Ingrese el código de la solicitud: ");
            string codigo = Console.ReadLine();
            Solicitud encontrada = BuscarSolicitudPorCodigo(codigo);
            if (encontrada == null)
            {
                SirvePaTodo.MensajeError(" Solicitud no encontrada.");
                SirvePaTodo.Pausa();
                return;
            }

            int opcion = 0;
            do
            {
                SirvePaTodo.Titulo("CAMBIAR ESTADO DE SOLICITUD", ConsoleColor.Cyan);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Solicitud: "+ encontrada.Codigo);
                Console.WriteLine("Estado actual: "+ encontrada.Estado);
                Console.WriteLine();
                SirvePaTodo.OpcionMenu("1", "Avanzar al siguiente estado", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("2", "Cancelar solicitud", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("3", "Deshacer último cambio", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("4", "Mostrar historial de estados", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("5", "Regresar", ConsoleColor.DarkRed);
                SirvePaTodo.PieMenu(ConsoleColor.DarkGray);

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    SirvePaTodo.MensajeError(" Ingrese un número entero.");
                    SirvePaTodo.Pausa();
                }
                else
                {
                    switch (opcion)
                    {
                        case 1:
                            EstadoSolicitud siguiente = encontrada.Estado;
                            if (encontrada.Estado == EstadoSolicitud.Recibida)
                            {
                                siguiente = EstadoSolicitud.EnEspera;
                            }

                            else if (encontrada.Estado == EstadoSolicitud.EnEspera)
                            {
                                siguiente = EstadoSolicitud.Asignada;
                            }

                            else if (encontrada.Estado == EstadoSolicitud.Asignada)
                            {
                                siguiente = EstadoSolicitud.EnDiagnostico;
                            }

                            else if (encontrada.Estado == EstadoSolicitud.EnDiagnostico)
                            {
                                siguiente = EstadoSolicitud.EnReparacion;
                            }

                            else if (encontrada.Estado == EstadoSolicitud.EnReparacion)
                            {
                                siguiente = EstadoSolicitud.ListaParaEntregar;
                            }

                            else if (encontrada.Estado == EstadoSolicitud.ListaParaEntregar)
                            {
                                siguiente = EstadoSolicitud.Entregada;
                            }

                            if (encontrada.Estado == EstadoSolicitud.EnReparacion && siguiente == EstadoSolicitud.ListaParaEntregar)
                            {
                                Console.WriteLine();
                                Console.WriteLine("========================================");
                                Console.WriteLine("      FINALIZAR REPARACIÓN");
                                Console.WriteLine("========================================");
                                Console.WriteLine("Solicitud: "+ encontrada.Codigo);
                                Console.WriteLine("Cliente: "+ encontrada.Cliente.Nombre);
                                Console.WriteLine("Equipo: "+ encontrada.Equipo.TipoEquipo);
                                Console.WriteLine("----------------------------------------");
                                Console.WriteLine("Mano de obra: Q"+ encontrada.CostoManoObra.ToString("F2"));
                                Console.WriteLine("Repuestos: Q"+ encontrada.CostoRepuestos.ToString("F2"));
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("TOTAL: Q"+ encontrada.Total.ToString("F2"));
                                Console.ResetColor();
                                Console.WriteLine("----------------------------------------");

                                if (encontrada.CostoManoObra == 0 && encontrada.CostoRepuestos == 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine();
                                    Console.WriteLine("ADVERTENCIA: No hay costos registrados.");
                                    Console.WriteLine("La reparación tiene un total de Q0.00.");
                                    Console.WriteLine();
                                    Console.ResetColor();
                                    Console.WriteLine("¿Es una reparación gratuita?");
                                    Console.WriteLine("1. Sí, continuar");
                                    Console.WriteLine("2. No, regresar a registrar costos");
                                    Console.Write("Seleccione una opcion: ");
                                    int respuesta = 0;

                                    if (!int.TryParse(Console.ReadLine(), out respuesta))
                                    {
                                        SirvePaTodo.MensajeError(" Ingrese un número válido.");
                                        SirvePaTodo.Pausa();
                                        break;
                                    }

                                    if (respuesta != 1)
                                    {
                                        SirvePaTodo.MensajeError("Registre los costos antes de finalizar.");
                                        SirvePaTodo.Pausa();
                                        break;
                                    }
                                }
                                Console.WriteLine("¿La reparación está terminada?");
                                Console.WriteLine("1. Confirmar y finalizar reparación");
                                Console.WriteLine("2. Regresar");
                                Console.Write("Seleccione una opcion: ");

                                int confirmacion = 0;
                                if (!int.TryParse(Console.ReadLine(), out confirmacion))
                                {
                                    SirvePaTodo.MensajeError(" Ingrese una opcion válida.");
                                    SirvePaTodo.Pausa();
                                    break;
                                }

                                if (confirmacion != 1)
                                {
                                    Console.WriteLine("La reparación continuará en proceso.");
                                    SirvePaTodo.Pausa();
                                    break;
                                }
                            }

                            if (encontrada.CambiarEstado(siguiente))
                            {
                                if (siguiente == EstadoSolicitud.Entregada && encontrada.TecnicoAsignado != null)
                                {
                                    if (encontrada.TecnicoAsignado.TrabajosActivos > 0)
                                    {
                                        encontrada.TecnicoAsignado.TrabajosActivos--;
                                    }
                                    encontrada.TecnicoAsignado.ServiciosFinalizados++;
                                }
                                SirvePaTodo.MensajeExito("Estado actualizado correctamente.");
                                Console.WriteLine("Nuevo estado: "+ encontrada.Estado);
                            }

                            else
                            {
                                SirvePaTodo.MensajeError(" No se permite avanzar al siguiente estado.");
                                if (encontrada.Estado == EstadoSolicitud.EnDiagnostico && string.IsNullOrWhiteSpace(encontrada.Diagnostico))
                                {
                                    Console.WriteLine("Debe registrar un diagnóstico antes de reparar.");
                                }
                            }

                            SirvePaTodo.Pausa();
                            break;
                        case 2:
                            if (encontrada.CambiarEstado(EstadoSolicitud.Cancelada))
                            {
                                if (encontrada.TecnicoAsignado != null)
                                {
                                    if (encontrada.TecnicoAsignado.TrabajosActivos > 0)
                                    {
                                        encontrada.TecnicoAsignado.TrabajosActivos--;
                                    }
                                }

                                Queue<Solicitud> urgentes = new Queue<Solicitud>();
                                foreach (Solicitud solicitud in Program.colaUrgente)
                                {
                                    if (solicitud.Codigo != encontrada.Codigo)
                                    {
                                        urgentes.Enqueue(solicitud);
                                    }
                                }

                                Program.colaUrgente = urgentes;
                                Queue<Solicitud> normales = new Queue<Solicitud>();
                                foreach (Solicitud solicitud in Program.colaNormal)
                                {
                                    if (solicitud.Codigo != encontrada.Codigo)
                                    {
                                        normales.Enqueue(solicitud);
                                    }
                                }
                                Program.colaNormal = normales;
                                SirvePaTodo.MensajeExito("Solicitud cancelada correctamente.");
                            }

                            else
                            {
                                SirvePaTodo.MensajeError(" No se puede cancelar esta solicitud.");
                            }
                            SirvePaTodo.Pausa();
                            break;

                        case 3:
                            if (encontrada.Estado == EstadoSolicitud.Asignada || encontrada.Estado == EstadoSolicitud.EnEspera)
                            {
                                SirvePaTodo.MensajeError(" No se puede deshacer una asignación o regresar a recibida.");
                            }

                            else if (encontrada.DeshacerEstado())
                            {
                                SirvePaTodo.MensajeExito("Se restauró el estado anterior.");
                                Console.WriteLine("Estado actual: "+ encontrada.Estado);
                            }

                            else
                            {
                                SirvePaTodo.MensajeError(" No se puede deshacer el estado.");
                            }
                            SirvePaTodo.Pausa();
                            break;

                        case 4:
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("HISTORIAL DE ESTADOS");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Estado actual: "+ encontrada.Estado);

                            if (encontrada.HistorialEstados.Count == 0)
                            {
                                Console.WriteLine("No existen estados anteriores.");
                            }

                            else
                            {
                                foreach (EstadoSolicitud estado in encontrada.HistorialEstados)
                                {
                                    Console.WriteLine("Anterior: "+ estado);
                                }
                            }
                            SirvePaTodo.Pausa();
                            break;

                        case 5:
                            break;

                        default:
                            SirvePaTodo.MensajeError(" La opcion seleccionada no existe.");
                            SirvePaTodo.Pausa();
                            break;
                    }
                }
            } while (opcion != 5);
        }
        public static void MostrarSolicitudes()
        {
            SirvePaTodo.Titulo("SOLICITUDES REGISTRADAS", ConsoleColor.Cyan);
            if (Program.solicitudes.Count == 0)
            {
                SirvePaTodo.MensajeError(" No existen solicitudes registradas.");
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Total de solicitudes: "+ Program.solicitudes.Count);
                Console.WriteLine();
                int normales = 0;
                int urgentes = 0;
                foreach (Solicitud solicitud in Program.solicitudes)
                {
                    if (solicitud.Prioridad == PrioridadSolicitud.Normal)
                    {
                        normales++;
                    }
                    else
                    {
                        urgentes++;
                    }
                }

                Console.WriteLine("Solicitudes normales: "+ normales);
                Console.WriteLine("Solicitudes urgentes: "+ urgentes);
                Console.WriteLine();
                Console.WriteLine("========================================");

                foreach (Solicitud solicitud in Program.solicitudes)
                {
                    Console.WriteLine();
                    solicitud.MostrarInformacion();
                    Console.WriteLine();
                    Console.WriteLine("========================================");
                }
            }
            SirvePaTodo.Pausa();
        }
        public static void MenuRepuestos()
        {
            int opcion = 0;
            do
            {
                SirvePaTodo.Titulo("GESTIÓN DE REPUESTOS", ConsoleColor.Cyan);
                SirvePaTodo.OpcionMenu("1", "Registrar repuesto", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("2", "Buscar repuesto", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("3", "Modificar repuesto", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("4", "Agregar existencias", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("5", "Mostrar inventario", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("6", "Regresar", ConsoleColor.DarkRed);
                SirvePaTodo.PieMenu(ConsoleColor.DarkGray);

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    SirvePaTodo.MensajeError(" Ingrese un número entero.");
                    SirvePaTodo.Pausa();
                }

                else
                {
                    switch (opcion)
                    {
                        case 1:
                            RegistrarRepuesto();
                            break;
                        case 2:
                            BuscarRepuesto();
                            break;
                        case 3:
                            ModificarRepuesto();
                            break;
                        case 4:
                            AgregarExistencias();
                            break;
                        case 5:
                            MostrarInventario();
                            break;
                        case 6:
                            break;
                        default:
                            SirvePaTodo.MensajeError(" La opcion seleccionada no existe.");
                            SirvePaTodo.Pausa();
                            break;
                    }
                }
            } while (opcion != 6);
        }
        public static void RegistrarRepuesto()
        {
            SirvePaTodo.Titulo("REGISTRAR REPUESTO", ConsoleColor.Cyan);
            string nombre = "";
            string categoria = "";
            string codigo = "";
            int existencia = 0;
            int existenciaMinima = 0;
            double costo = 0;
            double precio = 0;
            bool repetido = false;
            Console.ForegroundColor = ConsoleColor.White;
            
            do
            {
                Console.Write("Nombre del repuesto: ");
                nombre = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    SirvePaTodo.MensajeError("El nombre no puede estar vacío.");
                }
            } while (string.IsNullOrWhiteSpace(nombre));
           
            do
            {
                Console.Write("Categoría del repuesto: ");
                categoria = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(categoria))
                {
                    SirvePaTodo.MensajeError(" La categoría no puede estar vacía.");
                }
            } while (string.IsNullOrWhiteSpace(categoria));
           
            bool valido = false;
            do
            {
                Console.Write("Cantidad inicial: ");
                valido = int.TryParse(Console.ReadLine(), out existencia);
                if (valido == false || existencia < 0)
                {
                    SirvePaTodo.MensajeError(" Ingrese una cantidad válida.");
                }
            } while (valido == false || existencia < 0);
            
            do
            {
                Console.Write("Existencia mínima: ");
                valido = int.TryParse(Console.ReadLine(), out existenciaMinima);
                if (valido == false || existenciaMinima < 0)
                {
                    SirvePaTodo.MensajeError(" Ingrese una cantidad válida.");
                }
            } while (valido == false || existenciaMinima < 0);
          
            do
            {
                Console.Write("Costo unitario: Q");
                valido = double.TryParse( Console.ReadLine(), out costo);
                if (valido == false || costo < 0)
                {
                    SirvePaTodo.MensajeError(" Ingrese un costo válido.");
                }
            } while (valido == false || costo < 0);
         
            do
            {
                Console.Write("Precio de venta: Q");
                valido = double.TryParse( Console.ReadLine(), out precio);
                if (valido == false || precio < 0)
                {
                    SirvePaTodo.MensajeError(" Ingrese un precio válido.");
                }
            } while (valido == false || precio < 0);
           
            do
            {
                codigo = SirvePaTodo.GenerarCodigo("REP");
                repetido = false;
                foreach (Repuesto repuesto in Program.repuestos)
                {
                    if (repuesto.Codigo == codigo)
                    {
                        repetido = true;
                    }
                }
            } while (repetido == true);
          
            Repuesto nuevoRepuesto = new Repuesto( codigo, nombre.Trim(), categoria.Trim(), existencia, existenciaMinima, costo, precio);
            Program.repuestos.Add(nuevoRepuesto);
            Console.WriteLine();
            SirvePaTodo.MensajeExito("CORRECTO: Repuesto registrado correctamente.");
            Console.WriteLine("Código generado: "+ codigo);
            nuevoRepuesto.VerificarExistencia();
            SirvePaTodo.Pausa();
        }
        public static Repuesto BuscarRepuestoPorCodigo(string codigo)
        {
            foreach (Repuesto repuesto in Program.repuestos)
            {
                if (repuesto.Codigo.Equals( codigo, StringComparison.OrdinalIgnoreCase))
                {
                    return repuesto;
                }
            }
            return null;
        }

        public static void BuscarRepuesto()
        {
            SirvePaTodo.Titulo("BUSCAR REPUESTO", ConsoleColor.Cyan);
            if (Program.repuestos.Count == 0)
            {
                SirvePaTodo.MensajeError(" No existen repuestos registrados.");
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("REPUESTOS REGISTRADOS");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                foreach (Repuesto repuesto in Program.repuestos)
                {
                    Console.WriteLine("Código: "+ repuesto.Codigo + "| Nombre: "+ repuesto.Nombre);
                }

                Console.WriteLine();
                Console.Write("Ingrese el código del repuesto: ");
                string codigo = Console.ReadLine();
                Repuesto encontrado = BuscarRepuestoPorCodigo(codigo);
                if (encontrado == null)
                {
                    SirvePaTodo.MensajeError(" Repuesto no encontrado.");
                }

                else
                {
                    Console.WriteLine();
                    SirvePaTodo.MensajeExito("Repuesto encontrado correctamente.");
                    encontrado.MostrarInformacion();
                }
            }
            SirvePaTodo.Pausa();
        }
        public static void ModificarRepuesto()
        {
            SirvePaTodo.Titulo("MODIFICAR REPUESTO", ConsoleColor.Cyan);
            if (Program.repuestos.Count == 0)
            {
                SirvePaTodo.MensajeError(" No existen repuestos registrados.");
                SirvePaTodo.Pausa();
                return;
            }

            Console.WriteLine("REPUESTOS REGISTRADOS");
            Console.WriteLine();
            foreach (Repuesto repuesto in Program.repuestos)
            {
                Console.WriteLine("Código: "+ repuesto.Codigo + "| Nombre: "+ repuesto.Nombre);
            }

            Console.WriteLine();
            Console.Write("Ingrese el código del repuesto: ");
            string codigo = Console.ReadLine();
            Repuesto encontrado = BuscarRepuestoPorCodigo(codigo);

            if (encontrado == null)
            {
                SirvePaTodo.MensajeError(" Repuesto no encontrado.");
                SirvePaTodo.Pausa();
                return;
            }

            int opcion = 0;

            do
            {
                SirvePaTodo.Titulo("MODIFICAR REPUESTO", ConsoleColor.Cyan);
                Console.WriteLine("Repuesto: "+ encontrado.Nombre);
                Console.WriteLine("Código: "+ encontrado.Codigo);
                Console.WriteLine();

                SirvePaTodo.OpcionMenu("1", "Modificar nombre", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("2", "Modificar categoría", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("3", "Modificar existencia mínima", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("4", "Modificar costo unitario", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("5", "Modificar precio de venta", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("6", "Regresar", ConsoleColor.DarkRed);
                SirvePaTodo.PieMenu(ConsoleColor.DarkGray);

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    SirvePaTodo.MensajeError(" Ingrese un número entero.");
                    SirvePaTodo.Pausa();
                }

                else
                {
                    switch (opcion)
                    {
                        case 1:
                            string nombre = "";
                            do
                            {
                                Console.Write("Nuevo nombre: ");
                                nombre = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(nombre))
                                {
                                    SirvePaTodo.MensajeError("El nombre no puede estar vacío.");
                                }
                            } while (string.IsNullOrWhiteSpace(nombre));

                            encontrado.Nombre = nombre.Trim();
                            SirvePaTodo.MensajeExito("Nombre actualizado correctamente.");
                            SirvePaTodo.Pausa();
                            break;

                        case 2:
                            string categoria = "";
                            do
                            {
                                Console.Write("Nueva categoría: ");
                                categoria = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(categoria))
                                {
                                    SirvePaTodo.MensajeError(" La categoría no puede estar vacía.");
                                }
                            } while (string.IsNullOrWhiteSpace(categoria));

                            encontrado.Categoria = categoria.Trim();
                            SirvePaTodo.MensajeExito("Categoría actualizada correctamente.");
                            SirvePaTodo.Pausa();
                            break;

                        case 3:
                            int minima = 0;
                            bool valido;

                            do
                            {
                                Console.Write("Nueva existencia mínima: ");
                                valido = int.TryParse(Console.ReadLine(), out minima);
                                if (valido == false || minima < 0)
                                {
                                    SirvePaTodo.MensajeError(" Ingrese una cantidad válida.");
                                }
                            } while (valido == false || minima < 0);

                            encontrado.ExistenciaMinima = minima;
                            SirvePaTodo.MensajeExito("Existencia mínima actualizada.");
                            encontrado.VerificarExistencia();
                            SirvePaTodo.Pausa();
                            break;

                        case 4:
                            double costo = 0;
                            do
                            {
                                Console.Write("Nuevo costo unitario: Q");
                                valido = double.TryParse( Console.ReadLine(), out costo);
                                if (valido == false || costo < 0)
                                {
                                    SirvePaTodo.MensajeError(" Ingrese un costo válido.");
                                }
                            } while (valido == false || costo < 0);

                            encontrado.CostoUnitario = costo;
                            SirvePaTodo.MensajeExito("Costo actualizado correctamente.");
                            SirvePaTodo.Pausa();
                            break;

                        case 5:
                            double precio = 0;
                            do
                            {
                                Console.Write("Nuevo precio de venta: Q");
                                valido = double.TryParse( Console.ReadLine(), out precio);
                                if (valido == false || precio < 0)
                                {
                                    SirvePaTodo.MensajeError(" Ingrese un precio válido.");
                                }
                            } while (valido == false || precio < 0);

                            encontrado.PrecioVenta = precio;
                            SirvePaTodo.MensajeExito("Precio actualizado correctamente.");
                            SirvePaTodo.Pausa();
                            break;

                        case 6:
                            break;

                        default:
                            SirvePaTodo.MensajeError(" La opcion seleccionada no existe.");
                            SirvePaTodo.Pausa();
                            break;
                    }
                }
            } while (opcion != 6);
        }
        public static void AgregarExistencias()
        {
            SirvePaTodo.Titulo("AGREGAR EXISTENCIAS", ConsoleColor.Cyan);
            if (Program.repuestos.Count == 0)
            {
                SirvePaTodo.MensajeError(" No existen repuestos registrados.");
                SirvePaTodo.Pausa();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("INVENTARIO DE REPUESTOS");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            foreach (Repuesto repuesto in Program.repuestos)
            {
                Console.WriteLine("Código: "+ repuesto.Codigo + "| Nombre: "+ repuesto.Nombre + "| Existencia: "+ repuesto.Existencia);
            }

            Console.WriteLine();
            Console.Write("Ingrese el código del repuesto: ");
            string codigo = Console.ReadLine();
            Repuesto encontrado = BuscarRepuestoPorCodigo(codigo);
            if (encontrado == null)
            {
                SirvePaTodo.MensajeError(" Repuesto no encontrado.");
                SirvePaTodo.Pausa();
                return;
            }

            int cantidad = 0;
            bool valido;
            do
            {
                Console.Write("Cantidad que desea agregar: ");
                valido = int.TryParse(Console.ReadLine(), out cantidad);
                if (valido == false || cantidad <= 0)
                {
                    SirvePaTodo.MensajeError(" La cantidad debe ser mayor a cero.");
                }
                else if (cantidad > int.MaxValue - encontrado.Existencia)
                {
                    valido = false;
                    SirvePaTodo.MensajeError(" La cantidad supera el límite permitido.");
                }
            } while (valido == false || cantidad <= 0);

            if (encontrado.AgregarExistencia(cantidad))
            {
                SirvePaTodo.MensajeExito("CORRECTO: Existencias agregadas correctamente.");
                Console.WriteLine();
                Console.WriteLine("Repuesto: "+ encontrado.Nombre);
                Console.WriteLine("Cantidad agregada: "+ cantidad);
                Console.WriteLine("Existencia actual: "+ encontrado.Existencia);
                encontrado.VerificarExistencia();
            }
            SirvePaTodo.Pausa();
        }
        public static void MostrarInventario()
        {
            SirvePaTodo.Titulo("INVENTARIO DE REPUESTOS", ConsoleColor.Cyan);
            if (Program.repuestos.Count == 0)
            {
                SirvePaTodo.MensajeError(" No existen repuestos registrados.");
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Total de repuestos registrados: "+ Program.repuestos.Count);
                Console.WriteLine();
                int agotados = 0;
                int bajoMinimo = 0;
                double valorInventario = 0;
                foreach (Repuesto repuesto in Program.repuestos)
                {
                    valorInventario = valorInventario + repuesto.Existencia * repuesto.CostoUnitario;
                    if (repuesto.Existencia == 0)
                    {
                        agotados++;
                    }
                    else if (repuesto.Existencia <= repuesto.ExistenciaMinima)
                    {
                        bajoMinimo++;
                    }
                }

                Console.WriteLine("Repuestos agotados: "+ agotados);
                Console.WriteLine("Repuestos con existencia baja: "+ bajoMinimo);
                Console.WriteLine("Valor del inventario: Q"+ valorInventario.ToString("F2"));
                Console.WriteLine();
                Console.WriteLine("========================================");

                foreach (Repuesto repuesto in Program.repuestos)
                {
                    Console.WriteLine();
                    repuesto.MostrarInformacion();
                    Console.WriteLine();
                    Console.WriteLine("========================================");
                }
            }
            SirvePaTodo.Pausa();
        }
        public static void MenuAtencionDiagnosticos()
        {
            int opcion = 0;
            do
            {
                SirvePaTodo.Titulo("ATENCIÓN Y DIAGNÓSTICOS", ConsoleColor.Cyan);
                SirvePaTodo.OpcionMenu("1", "Registrar diagnóstico", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("2", "Registrar mano de obra", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("3", "Utilizar repuestos", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("4", "Consultar costos de reparación", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("5", "Mostrar trabajos en proceso", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("6", "Regresar", ConsoleColor.DarkRed);
                SirvePaTodo.PieMenu(ConsoleColor.DarkGray);

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    SirvePaTodo.MensajeError(" Ingrese un número entero.");
                    SirvePaTodo.Pausa();
                }

                else
                {
                    switch (opcion)
                    {
                        case 1:
                            RegistrarDiagnostico();
                            break;
                        case 2:
                            RegistrarManoDeObra();
                            break;
                        case 3:
                            UtilizarRepuestos();
                            break;
                        case 4:
                            ConsultarCostosReparacion();
                            break;
                        case 5:
                            MostrarTrabajosEnProceso();
                            break;
                        case 6:
                            break;
                        default:
                            SirvePaTodo.MensajeError(" La opcion seleccionada no existe.");
                            SirvePaTodo.Pausa();
                            break;
                    }
                }
            } while (opcion != 6);
        }
        public static void RegistrarDiagnostico()
        {
            SirvePaTodo.Titulo("REGISTRAR DIAGNÓSTICO", ConsoleColor.Cyan);
            if (Program.solicitudes.Count == 0)
            {
                SirvePaTodo.MensajeError(" No existen solicitudes registradas.");
                SirvePaTodo.Pausa();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("SOLICITUDES EN DIAGNÓSTICO");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            int cantidad = 0;
            foreach (Solicitud solicitud in Program.solicitudes)
            {
                if (solicitud.Estado == EstadoSolicitud.EnDiagnostico && solicitud.TecnicoAsignado != null)
                {
                    Console.WriteLine("Código: "+ solicitud.Codigo + "| Equipo: "+ solicitud.Equipo.TipoEquipo + "| tecnico: "+ solicitud.TecnicoAsignado.Nombre);
                    cantidad++;
                }
            }

            if (cantidad == 0)
            {
                SirvePaTodo.MensajeError(" No existen solicitudes en diagnóstico.");
                SirvePaTodo.Pausa();
                return;
            }

            Console.WriteLine();
            Console.Write("Ingrese el código de la solicitud: ");
            string codigo = Console.ReadLine();
            Solicitud encontrada = BuscarSolicitudPorCodigo(codigo);
            if (encontrada == null)
            {
                SirvePaTodo.MensajeError(" Solicitud no encontrada.");
            }

            else if (encontrada.Estado != EstadoSolicitud.EnDiagnostico)
            {
                SirvePaTodo.MensajeError(" La solicitud no está en diagnóstico.");
            }

            else if (encontrada.TecnicoAsignado == null)
            {
                SirvePaTodo.MensajeError(" La solicitud no tiene tecnico asignado.");
            }

            else
            {
                Console.WriteLine();
                Console.WriteLine("Solicitud: "+ encontrada.Codigo);
                Console.WriteLine("Cliente: "+ encontrada.Cliente.Nombre);
                Console.WriteLine("Equipo: "+ encontrada.Equipo.TipoEquipo);
                Console.WriteLine("Problema reportado: "+ encontrada.DescripcionProblema);
                Console.WriteLine();
                string diagnostico = "";

                do
                {
                    Console.WriteLine("Ingrese el diagnóstico del tecnico:");
                    diagnostico = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(diagnostico))
                    {
                        SirvePaTodo.MensajeError("El diagnóstico no puede estar vacío.");
                    }
                } while (string.IsNullOrWhiteSpace(diagnostico));

                encontrada.Diagnostico = diagnostico.Trim();
                SirvePaTodo.MensajeExito("CORRECTO: Diagnóstico registrado correctamente.");
                Console.WriteLine();
                Console.WriteLine("tecnico: "+ encontrada.TecnicoAsignado.Nombre);
                Console.WriteLine("Diagnóstico: "+ encontrada.Diagnostico);
            }
            SirvePaTodo.Pausa();
        }
        public static void RegistrarManoDeObra()
        {
            SirvePaTodo.Titulo("REGISTRAR MANO DE OBRA", ConsoleColor.Cyan);
            int cantidad = 0;
            foreach (Solicitud solicitud in Program.solicitudes)
            {
                if (solicitud.Estado == EstadoSolicitud.EnDiagnostico || solicitud.Estado == EstadoSolicitud.EnReparacion)
                {
                    Console.WriteLine("Código: "+ solicitud.Codigo + "| Equipo: "+ solicitud.Equipo.TipoEquipo + "| Estado: "+ solicitud.Estado);
                    cantidad++;
                }
            }

            if (cantidad == 0)
            {
                SirvePaTodo.MensajeError(" No existen solicitudes para registrar costos.");
                SirvePaTodo.Pausa();
                return;
            }

            Console.WriteLine();
            Console.Write("Ingrese el código de la solicitud: ");
            string codigo = Console.ReadLine();
            Solicitud encontrada = BuscarSolicitudPorCodigo(codigo);
            if (encontrada == null)
            {
                SirvePaTodo.MensajeError(" Solicitud no encontrada.");
            }

            else if (encontrada.Estado != EstadoSolicitud.EnDiagnostico && encontrada.Estado != EstadoSolicitud.EnReparacion)
            {
                SirvePaTodo.MensajeError(" La solicitud no está en diagnóstico o reparación.");
            }

            else
            {
                double costo = 0;
                bool valido = false;
                do
                {
                    Console.Write("Ingrese el costo de mano de obra: Q");
                    valido = double.TryParse( Console.ReadLine(), out costo);
                    if (valido == false || costo < 0 || double.IsNaN(costo) || double.IsInfinity(costo))
                    {
                        SirvePaTodo.MensajeError(" Ingrese un costo válido.");
                        valido = false;
                    }
                } while (valido == false);

                encontrada.CostoManoObra = costo;
                SirvePaTodo.MensajeExito("Costo de mano de obra registrado correctamente.");
                Console.WriteLine("Mano de obra: Q"+ encontrada.CostoManoObra.ToString("F2"));
                Console.WriteLine("Total actual: Q"+ encontrada.Total.ToString("F2"));
            }
            SirvePaTodo.Pausa();
        }
        public static void UtilizarRepuestos()
        {
            SirvePaTodo.Titulo("UTILIZAR REPUESTOS", ConsoleColor.Cyan);
            if (Program.repuestos.Count == 0)
            {
                SirvePaTodo.MensajeError(" No existen repuestos registrados.");
                SirvePaTodo.Pausa();
                return;
            }

            int cantidadSolicitudes = 0;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("SOLICITUDES EN REPARACIÓN");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Solicitud solicitud in Program.solicitudes)
            {
                if (solicitud.Estado == EstadoSolicitud.EnReparacion)
                {
                    Console.WriteLine("Código: "+ solicitud.Codigo + "| Equipo: "+ solicitud.Equipo.TipoEquipo);
                    cantidadSolicitudes++;
                }
            }

            if (cantidadSolicitudes == 0)
            {
                SirvePaTodo.MensajeError(" No existen solicitudes en reparación.");
                SirvePaTodo.Pausa();
                return;
            }

            Console.WriteLine();
            Console.Write("Ingrese el código de la solicitud: ");
            string codigoSolicitud = Console.ReadLine();
            Solicitud encontrada = BuscarSolicitudPorCodigo(codigoSolicitud);

            if (encontrada == null)
            {
                SirvePaTodo.MensajeError(" Solicitud no encontrada.");
                SirvePaTodo.Pausa();
                return;
            }

            if (encontrada.Estado != EstadoSolicitud.EnReparacion)
            {
                SirvePaTodo.MensajeError(" La solicitud no está en reparación.");
                SirvePaTodo.Pausa();
                return;
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("REPUESTOS DISPONIBLES");
            Console.ForegroundColor = ConsoleColor.White;
            int disponibles = 0;

            foreach (Repuesto repuesto in Program.repuestos)
            {
                if (repuesto.Existencia > 0)
                {
                    Console.WriteLine("Código: "+ repuesto.Codigo + "| Nombre: "+ repuesto.Nombre + "| Existencia: "+ repuesto.Existencia + "| Precio: Q"+ repuesto.PrecioVenta);
                    disponibles++;
                }
            }

            if (disponibles == 0)
            {
                SirvePaTodo.MensajeError(" No existen repuestos con existencias.");
                SirvePaTodo.Pausa();
                return;
            }

            Console.WriteLine();
            Console.Write("Ingrese el código del repuesto: ");
            string codigoRepuesto = Console.ReadLine();
            Repuesto seleccionado =  BuscarRepuestoPorCodigo(codigoRepuesto);
            if (seleccionado == null)
            {
                SirvePaTodo.MensajeError(" Repuesto no encontrado.");
                SirvePaTodo.Pausa();
                return;
            }

            if (seleccionado.Existencia == 0)
            {
                SirvePaTodo.MensajeError("El repuesto está agotado.");
                SirvePaTodo.Pausa();
                return;
            }

            int cantidad = 0;
            bool valido = false;
            do
            {
                Console.Write("Cantidad que desea utilizar: ");
                valido = int.TryParse(Console.ReadLine(), out cantidad);
                if (valido == false || cantidad <= 0)
                {
                    SirvePaTodo.MensajeError(" Ingrese una cantidad mayor a cero.");
                }
                else if (cantidad > seleccionado.Existencia)
                {
                    SirvePaTodo.MensajeError(" No existen suficientes unidades.");
                    valido = false;
                }
            } while (valido == false);

            double precio = seleccionado.CalcularPrecio(cantidad);
            if (double.IsInfinity(precio) || double.IsNaN(precio) || double.IsInfinity(encontrada.CostoRepuestos + precio))
            {
                SirvePaTodo.MensajeError("El importe supera el límite permitido.");
                SirvePaTodo.Pausa();
                return;
            }

            if (seleccionado.UtilizarRepuesto(cantidad))
            {
                encontrada.CostoRepuestos = encontrada.CostoRepuestos + precio;
                SirvePaTodo.MensajeExito("Repuesto agregado a la reparación.");
                Console.WriteLine();
                Console.WriteLine("Repuesto: "+ seleccionado.Nombre);
                Console.WriteLine("Cantidad utilizada: "+ cantidad);
                Console.WriteLine("Costo agregado: Q"+ precio.ToString("F2"));
                Console.WriteLine("Total de reparación: Q"+ encontrada.Total.ToString("F2"));
            }
            SirvePaTodo.Pausa();
        }
        public static void ConsultarCostosReparacion()
        {
            SirvePaTodo.Titulo("CONSULTAR COSTOS DE REPARACIÓN", ConsoleColor.Cyan);
            if (Program.solicitudes.Count == 0)
            {
                SirvePaTodo.MensajeError(" No existen solicitudes registradas.");
                SirvePaTodo.Pausa();
                return;
            }

            foreach (Solicitud solicitud in Program.solicitudes)
            {
                Console.WriteLine("Código: "+ solicitud.Codigo + "| Cliente: "+ solicitud.Cliente.Nombre);
            }

            Console.WriteLine();
            Console.Write("Ingrese el código de la solicitud: ");

            string codigo = Console.ReadLine();
            Solicitud encontrada = BuscarSolicitudPorCodigo(codigo);
            if (encontrada == null)
            {
                SirvePaTodo.MensajeError(" Solicitud no encontrada.");
            }

            else
            {
                Console.WriteLine();
                Console.WriteLine("========================================");
                Console.WriteLine("       COSTOS DE REPARACIÓN");
                Console.WriteLine("========================================");
                Console.WriteLine("Solicitud: "+ encontrada.Codigo);
                Console.WriteLine("Cliente: "+ encontrada.Cliente.Nombre);
                Console.WriteLine("Equipo: "+ encontrada.Equipo.TipoEquipo);
                Console.WriteLine("Estado: "+ encontrada.Estado);
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Mano de obra: Q"+ encontrada.CostoManoObra.ToString("F2"));
                Console.WriteLine("Repuestos: Q"+ encontrada.CostoRepuestos.ToString("F2"));
                Console.WriteLine("----------------------------------------");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("TOTAL: Q"+ encontrada.Total.ToString("F2"));
                Console.ResetColor();
            }
            SirvePaTodo.Pausa();
        }
        public static void MostrarTrabajosEnProceso()
        {
            SirvePaTodo.Titulo("TRABAJOS EN PROCESO", ConsoleColor.Cyan);
            int cantidad = 0;
            foreach (Solicitud solicitud in Program.solicitudes)
            {
                if (solicitud.Estado == EstadoSolicitud.Asignada || solicitud.Estado == EstadoSolicitud.EnDiagnostico || solicitud.Estado == EstadoSolicitud.EnReparacion || solicitud.Estado == EstadoSolicitud.ListaParaEntregar)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("Solicitud: "+ solicitud.Codigo);
                    Console.WriteLine("Cliente: "+ solicitud.Cliente.Nombre);
                    Console.WriteLine("Equipo: "+ solicitud.Equipo.TipoEquipo);
                    Console.WriteLine("Estado: "+ solicitud.Estado);
                    Console.WriteLine("Prioridad: "+ solicitud.Prioridad);

                    if (solicitud.TecnicoAsignado != null)
                    {
                        Console.WriteLine("tecnico: "+ solicitud.TecnicoAsignado.Nombre);
                    }
                    else
                    {
                        Console.WriteLine("tecnico: Sin asignar");
                    }

                    Console.WriteLine("Total actual: Q"+ solicitud.Total.ToString("F2"));
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine();
                    cantidad++;
                }
            }

            if (cantidad == 0)
            {
                SirvePaTodo.MensajeError("No existen trabajos en proceso.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Total de trabajos en proceso: "+ cantidad);
                Console.ResetColor();
            }
            SirvePaTodo.Pausa();
        }
        public static void MenuReportes()
        {
            int opcion = 0;
            do
            {
                SirvePaTodo.Titulo("REPORTES Y ESTADÍSTICAS", ConsoleColor.Cyan);
                SirvePaTodo.OpcionMenu("1", "Resumen general de solicitudes", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("2", "Rendimiento de tecnicos", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("3", "Reporte de ingresos", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("4", "Reporte de inventario", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("5", "Reporte de clientes y equipos", ConsoleColor.Yellow);
                SirvePaTodo.OpcionMenu("6", "Regresar", ConsoleColor.DarkRed);
                SirvePaTodo.PieMenu(ConsoleColor.DarkGray);

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    SirvePaTodo.MensajeError(" Ingrese un número entero.");
                    SirvePaTodo.Pausa();
                }

                else
                {
                    switch (opcion)
                    {
                        case 1:
                            ReporteSolicitudes();
                            break;
                        case 2:
                            ReporteTecnicos();
                            break;
                        case 3:
                            ReporteIngresos();
                            break;
                        case 4:
                            ReporteInventario();
                            break;
                        case 5:
                            ReporteClientesEquipos();
                            break;
                        case 6:
                            break;
                        default:
                            SirvePaTodo.MensajeError("La opción seleccionada no existe.");
                            SirvePaTodo.Pausa();
                            break;
                    }
                }
            } while (opcion != 6);
        }

        public static void ReporteSolicitudes()
        {
            SirvePaTodo.Titulo("REPORTE GENERAL DE SOLICITUDES", ConsoleColor.Cyan);
            int recibidas = 0, enEspera = 0, asignadas = 0, enDiagnostico = 0, enReparacion = 0, listas = 0, entregadas = 0, canceladas = 0, normales = 0, urgentes = 0;
            foreach (Solicitud solicitud in Program.solicitudes)
            {
                switch (solicitud.Estado)
                {
                    case EstadoSolicitud.Recibida:
                        recibidas++;
                        break;

                    case EstadoSolicitud.EnEspera:
                        enEspera++;
                        break;

                    case EstadoSolicitud.Asignada:
                        asignadas++;
                        break; 

                    case EstadoSolicitud.EnDiagnostico:
                        enDiagnostico++;
                        break;

                    case EstadoSolicitud.EnReparacion:
                        enReparacion++;
                        break;

                    case EstadoSolicitud.ListaParaEntregar:
                        listas++;
                        break;

                    case EstadoSolicitud.Entregada:
                        entregadas++;
                        break;

                    case EstadoSolicitud.Cancelada:
                        canceladas++;
                        break;
                }

                if (solicitud.Prioridad == PrioridadSolicitud.Urgente)
                {urgentes++;}
                else
                { normales++;}
            }

            Console.WriteLine(@$"
Total de solicitudes: {Program.solicitudes.Count}

SOLICITUDES POR ESTADO
----------------------------------------
Recibidas: {recibidas}
En espera: {enEspera}
Asignadas: {asignadas}
En diagnóstico: {enDiagnostico}
En reparación: {enReparacion}
Listas para entregar: {listas}
Entregadas: {entregadas}
Canceladas: {canceladas}

SOLICITUDES POR PRIORIDAD
----------------------------------------
Normales: {normales}
Urgentes: {urgentes}");
            SirvePaTodo.Pausa();
        }

        public static void ReporteTecnicos()
        {
            SirvePaTodo.Titulo("RENDIMIENTO DE TÉCNICOS", ConsoleColor.Cyan);

            if (Program.tecnicos.Count == 0)
            {
                SirvePaTodo.MensajeError("No existen técnicos registrados.");
                SirvePaTodo.Pausa();
                return;
            }

            int totalActivos = 0;
            int totalFinalizados = 0;
            foreach (Tecnico tecnico in Program.tecnicos)
            {
                Console.WriteLine(@$"
Código: {tecnico.Codigo}
Nombre: {tecnico.Nombre}
Especialidad: {tecnico.Especialidad}
Trabajos activos: {tecnico.TrabajosActivos}
Servicios finalizados: {tecnico.ServiciosFinalizados}
Calificación promedio: {tecnico.CalificacionPromedio:F2}
----------------------------------------");

                totalActivos += tecnico.TrabajosActivos;
                totalFinalizados += tecnico.ServiciosFinalizados;
            }

            Console.WriteLine(@$"
Total de técnicos: {Program.tecnicos.Count}
Trabajos activos: {totalActivos}
Servicios finalizados: {totalFinalizados}");
            SirvePaTodo.Pausa();
        }

        public static void ReporteIngresos()
        {
            SirvePaTodo.Titulo("REPORTE DE INGRESOS", ConsoleColor.Cyan);

            double manoObra = 0, repuestos = 0, ingresos = 0;
            int entregadas = 0;

            foreach (Solicitud solicitud in Program.solicitudes)
            {
                if (solicitud.Estado == EstadoSolicitud.Entregada)
                {
                    manoObra += solicitud.CostoManoObra;
                    repuestos += solicitud.CostoRepuestos;
                    ingresos += solicitud.Total;
                    entregadas++;
                }
            }

            Console.WriteLine(@$"
Solicitudes entregadas: {entregadas}

Ingresos por mano de obra: Q{manoObra:F2}
Ingresos por repuestos: Q{repuestos:F2}
----------------------------------------
TOTAL DE INGRESOS: Q{ingresos:F2}");
            SirvePaTodo.Pausa();
        }

        public static void ReporteInventario()
        {
            SirvePaTodo.Titulo("REPORTE DE INVENTARIO", ConsoleColor.Cyan);

            if (Program.repuestos.Count == 0)
            {
                SirvePaTodo.MensajeError("No existen repuestos registrados.");
                SirvePaTodo.Pausa();
                return;
            }

            int totalUnidades = 0;
            int existenciasBajas = 0;
            double valorInventario = 0;

            foreach (Repuesto repuesto in Program.repuestos)
            {
                Console.WriteLine(@$"
Código: {repuesto.Codigo}
Nombre: {repuesto.Nombre}
Categoría: {repuesto.Categoria}
Existencia: {repuesto.Existencia}
Existencia mínima: {repuesto.ExistenciaMinima}
Precio de venta: Q{repuesto.PrecioVenta:F2}
----------------------------------------");
                totalUnidades += repuesto.Existencia;
                valorInventario += repuesto.Existencia * repuesto.CostoUnitario;
                if (repuesto.Existencia <= repuesto.ExistenciaMinima)
                {
                    existenciasBajas++;
                    SirvePaTodo.MensajeError("Advertencia: existencia baja.");
                }
            }

            Console.WriteLine(@$"
Repuestos diferentes: {Program.repuestos.Count}
Total de unidades: {totalUnidades}
Repuestos con existencia baja: {existenciasBajas}
Valor del inventario al costo: Q{valorInventario:F2}");
            SirvePaTodo.Pausa();
        }
        public static void ReporteClientesEquipos()
        {
            SirvePaTodo.Titulo("REPORTE DE CLIENTES Y EQUIPOS", ConsoleColor.Cyan);
            if (Program.clientes.Count == 0)
            {
                SirvePaTodo.MensajeError("No existen clientes registrados.");
                SirvePaTodo.Pausa();
                return;
            }
            foreach (Cliente cliente in Program.clientes)
            {
                int cantidadEquipos = 0;

                foreach (Equipo equipo in Program.equipos)
                {
                    if (equipo.Propietario.Codigo == cliente.Codigo)
                    {
                        cantidadEquipos++;
                    }
                }

                Console.WriteLine(@$"
Código: {cliente.Codigo}
Cliente: {cliente.Nombre}
Tipo: {cliente.TipoCliente}
Equipos registrados: {cantidadEquipos}
Solicitudes registradas: {cliente.CantidadSolicitudes}
----------------------------------------");
            }
            Console.WriteLine(@$"
Total de clientes: {Program.clientes.Count}
Total de equipos: {Program.equipos.Count}");
            SirvePaTodo.Pausa();
        }

        public static void GenerarDatosPrueba()
        {
            SirvePaTodo.Titulo("GENERAR DATOS DE PRUEBA", ConsoleColor.Cyan);
            Random aleatorio = new Random();

            string[] nombres = { "Sakata Gintoki", "Shimura Shinpachi", "Kagura", "Okita Sougo" };
            string[] marcas = { "Asus", "Dell", "Lenovo", "Apple", "Toshiba" };
            string[] problemas = { "Pantalla congelada", "Equipo lento", "Sistema operativo lento", "Error de sistema" };

            string codigoCliente = "";
            do
            {
              codigoCliente = SirvePaTodo.GenerarCodigo("CLI");
            } while (BuscarClientePorCodigo(codigoCliente) != null);

            Cliente cliente = new Cliente(codigoCliente, nombres[aleatorio.Next(nombres.Length)], "23658947", "seegintama@gmail.com", "Estudiante", 0);
            Program.clientes.Add(cliente);

            string codigoTecnico = "";
            do
            {
              codigoTecnico = SirvePaTodo.GenerarCodigo("TEC");
            } while (BuscarTecnicoPorCodigo(codigoTecnico) != null);

            Tecnico tecnico = new Tecnico(codigoTecnico, "Kondou Isaou", Especialidad.Computadoras, true, 0, 0, 0);
            Program.tecnicos.Add(tecnico);

            string codigoEquipo = "";
            do
            {
              codigoEquipo = SirvePaTodo.GenerarCodigo("POR");
            } while (BuscarEquipoPorCodigo(codigoEquipo) != null);

            string serie = "01234" + codigoEquipo;
            Equipo equipo = new ComputadoraPortatil(codigoEquipo, serie, marcas[aleatorio.Next(marcas.Length)], "2019", cliente, "Buen estado", "Cargador", true);

            Program.equipos.Add(equipo);
            string codigoSolicitud = "";
            do
            {
              codigoSolicitud = SirvePaTodo.GenerarCodigo("SOL");
            } while (BuscarSolicitudPorCodigo(codigoSolicitud) != null);

            PrioridadSolicitud prioridad = PrioridadSolicitud.Normal;
            if (aleatorio.Next(2) == 1)
            {
                prioridad = PrioridadSolicitud.Urgente;
            }

            Solicitud solicitud = new Solicitud(codigoSolicitud, cliente, equipo, problemas[aleatorio.Next(problemas.Length)], prioridad);
            Program.solicitudes.Add(solicitud);
            solicitud.CambiarEstado(EstadoSolicitud.EnEspera);

            if (prioridad == PrioridadSolicitud.Urgente)
            {
                Program.colaUrgente.Enqueue(solicitud);
            }
            else
            {
                Program.colaNormal.Enqueue(solicitud);
            }

            cliente.CantidadSolicitudes++;
            string codigoRepuesto = "";
            bool repetido;
            do
            {
                codigoRepuesto = SirvePaTodo.GenerarCodigo("REP");
                repetido = false;
                foreach (Repuesto repuesto in Program.repuestos)
                {
                    if (repuesto.Codigo == codigoRepuesto)
                    {
                        repetido = true;
                    }
                }
            } while (repetido);

            Repuesto nuevoRepuesto = new Repuesto(codigoRepuesto, "Memoria SD", "Computadoras", aleatorio.Next(5, 21), 3, 100, 150);
            Program.repuestos.Add(nuevoRepuesto);
            SirvePaTodo.MensajeExito("Datos agregados");
            Console.WriteLine(@$"
Cliente: {cliente.Codigo}
Técnico: {tecnico.Codigo}
Equipo: {equipo.Codigo}
Solicitud: {solicitud.Codigo}
Prioridad: {solicitud.Prioridad}
Repuesto: {nuevoRepuesto.Codigo}");
            SirvePaTodo.Pausa();
        }
    }
}
