using System.Collections.Generic;

namespace GarajesAliKan.Clases
{
    class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Nif { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public Garaje Garaje { get; set; }        
        public string Observaciones { get; set; }
        public int Llave { get; set; }
        public bool EsClienteGaraje { get; set; }
        public Vehiculo Vehiculo { get; set; } 
        public TipoAlquiler Alquiler { get; set; }

        /// <summary>
        /// Obtiene todos los clientes.
        /// </summary>
        /// <returns>Los clientes existentes.</returns>
        public static List<Cliente> ObtenerClientesGarajes()
        {
            List<Cliente> listaClientes = Foo.ConexionABd().Fetch<Cliente, Garaje, Vehiculo, TipoAlquiler>(@"SELECT cli.id, cli.nombre, cli.apellidos, cli.nif, cli.direccion, cli.telefono, cli.observaciones, cli.llave, gaj.nombre, veh.matricula, veh.marca, veh.modelo, veh.baseImponible, veh.iva, veh.total, tAlq.concepto
                                                                                                             FROM   clientes cli
		                                                                                                            JOIN garajes gaj ON gaj.id = cli.idGaraje
		                                                                                                            JOIN vehiculos veh ON veh.idCliente = cli.id
		                                                                                                            JOIN tiposAlquileres tAlq ON tAlq.id = cli.idTipoAlquiler
                                                                                                            WHERE cli.esClienteGaraje IS TRUE
                                                                                                            ORDER BY cli.apellidos;");
            Foo.ConexionABd().CloseSharedConnection();
            return listaClientes;
        }
    }
}
