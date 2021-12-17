using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using APICatalogo;
using APIClientes;

namespace UI
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient _client = new();
        private readonly List<Cliente> _clientes = new();
        private readonly List<Catalogo> _catalogos = new();
        public Form1()
        {
            InitializeComponent();
            _client.BaseAddress = new Uri("http://localhost:35005/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }



        private async void button1_Click(object sender, EventArgs e)
        {
            var response = await _client.GetAsync("Cliente");
            var data = await response.Content.ReadFromJsonAsync<IEnumerable<Cliente>>();
            foreach (var cliente in data)
            {
                _clientes.Add(cliente);
            }
            this.dataGridView.DataSource = _clientes;
            dataGridView.Refresh();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var response = await _client.GetAsync("Catalogo");
            var data = await response.Content.ReadFromJsonAsync<IEnumerable<Cliente>>();
            foreach (var cliente in data)
            {
                _clientes.Add(cliente);
            }
            this.dataGridView.DataSource = _clientes;
            dataGridView.Refresh();
        }
    }
}
