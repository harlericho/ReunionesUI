using App.Aplicacion.Servicios;
using Dominio.Modelo.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace UnitTestReunionesUI
{
    [TestClass]
    public class UnitTest1
    {
        readonly EmpleadoServicio _empleadoServicio = new EmpleadoServicio();
        readonly SalaServicio _salaServicio = new SalaServicio();
        readonly ReservaServicio _reservaServicio = new ReservaServicio();
        [TestMethod]
        public void TestMethod1()
        {
            // Insertar nuevo empleado
            //Empleado empleado1 = new Empleado();
            //empleado1.Nombre = "Violetita";
            //empleado1.Departamento = "Desarrollo";
            //empleado1.CorreoElectronico = "xyz@xyz.com";
            //_empleadoServicio.insertarEmpleado(empleado1);

            //Empleado empleado2 = new Empleado();
            //empleado2.Nombre = "Renatita";
            //empleado2.Departamento = "Desarrollo";
            //empleado2.CorreoElectronico = "abc@abc.com";
            //_empleadoServicio.insertarEmpleado(empleado2);

            //Mostar los empleados
            //foreach (var empleado in _empleadoServicio.obtenerEmpleados())
            //{
            //    Console.WriteLine(empleado.Nombre);
            //    Console.WriteLine(empleado.Departamento);
            //    Console.WriteLine(empleado.CorreoElectronico);
            //}

            // Insertar nueva sala
            //Sala sala = new Sala();
            //sala.Nombre = "Sala 1";
            //sala.Capacidad = 10;
            //sala.Ubicacion = "Piso 1";
            //_salaServicio.insertarSala(sala);

            //Sala sala2 = new Sala();
            //sala2.Nombre = "Sala 2";
            //sala2.Capacidad = 20;
            //sala2.Ubicacion = "Piso 2";
            //_salaServicio.insertarSala(sala2);

            ////Mostrar las salas
            //foreach (var salas in _salaServicio.obtenerSalas())
            //{
            //    Console.WriteLine(salas.Nombre);
            //    Console.WriteLine(salas.Capacidad);
            //    Console.WriteLine(salas.Ubicacion);
            //}

            // Insertar nueva reserva
            //Reserva reserva = new Reserva();
            //reserva.Fecha = DateTime.Now;
            //reserva.HoraInicio = DateTime.Now.TimeOfDay;
            //reserva.HoraFin = DateTime.Now.AddHours(1).TimeOfDay;
            //reserva.IDSala = 1;
            //reserva.IDEmpleado = 2;
            //_reservaServicio.insertarReserva(reserva);

            //Reserva reserva2 = new Reserva();
            //reserva2.Fecha = DateTime.Now;
            //reserva2.HoraInicio = DateTime.Now.TimeOfDay;
            //reserva2.HoraFin = DateTime.Now.AddHours(1).TimeOfDay;
            //reserva2.IDSala = 2;
            //reserva2.IDEmpleado = 6;
            //_reservaServicio.insertarReserva(reserva2);

            //Mostrar las reservas
            //foreach (var reservas in _reservaServicio.obtenerReservas())
            //{
            //    Console.WriteLine(reservas.Fecha);
            //    Console.WriteLine(reservas.HoraInicio);
            //    Console.WriteLine(reservas.HoraFin);
            //    Console.WriteLine(reservas.IDSala);
            //    Console.WriteLine(reservas.IDEmpleado);
            //}

            var salas = _salaServicio.obtenerSalas(); // Obtén las salas
            var empleados = _empleadoServicio.obtenerEmpleados(); // Obtén los empleados

            foreach (var reserva in _reservaServicio.obtenerReservas())
            {
                var nombreSala = salas.FirstOrDefault(s => s.ID == reserva.IDSala)?.Nombre ?? "Desconocido";
                var nombreEmpleado = empleados.FirstOrDefault(e => e.ID == reserva.IDEmpleado)?.Nombre ?? "Desconocido";

                Console.WriteLine($"Fecha: {reserva.Fecha}");
                Console.WriteLine($"Hora Inicio: {reserva.HoraInicio}");
                Console.WriteLine($"Hora Fin: {reserva.HoraFin}");
                Console.WriteLine($"Sala: {nombreSala}");
                Console.WriteLine($"Empleado: {nombreEmpleado}");
            }

        }
    }
}
