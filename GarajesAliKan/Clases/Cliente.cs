using System;
using System.Collections.Generic;

namespace GarajesAliKan.Clases
{
    class Cliente
    {
        protected int id;
        protected string nombre;
        protected string apellidos;
        protected string nif;
        protected string direccion;
        protected string telefono;

        // Se crean las propiedades por separado para añadir y obtenerlos desde otras clases.
        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Nif { get => nif; set => nif = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }       

        public Cliente(int id)
        {
            Id = id;
        }

        public Cliente(int id, string apellidos)
        {
            Id = id;
            Apellidos = apellidos;
        }

        public Cliente()
        {
        }
    }
}
