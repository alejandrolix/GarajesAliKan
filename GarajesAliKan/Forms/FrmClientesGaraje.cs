using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using GarajesAliKan.POCOs;

namespace GarajesAliKan.Forms
{
    public partial class FrmClientesGaraje : Form
    {        
        public FrmClientesGaraje()
        {
            InitializeComponent();
        }
        
        private void FrmClientesGaraje_Load(object sender, EventArgs e)
        {            
            MongoClient conexion = new MongoClient("mongodb://192.168.99.100:27017");
            IMongoCollection<Cliente> clientes = conexion.GetDatabase("garajesalikan").GetCollection<Cliente>("clientes");
            List<Cliente> listaClientes = clientes.Find<Cliente>(new BsonDocument()).ToList();

            DtClientes dtClientes = new DtClientes();
            for (int i = 0; i < listaClientes.Count; i++)
            {
                dtClientes.Tables["Clientes"].Rows.Add(listaClientes[i].Id, listaClientes[i].Nombre, listaClientes[i].Apellidos, listaClientes[i].Nif,
                    listaClientes[i].Direccion, listaClientes[i].Telefono, listaClientes[i].Observaciones, listaClientes[i].LlaveMando, listaClientes[i].Garaje.Nombre);
            }
            clientesBindingSource.DataSource = dtClientes.Tables["Clientes"];                  
        }        
    }
}
