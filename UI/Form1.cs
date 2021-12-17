using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Windows.Forms;
using APIClientes;

namespace UI
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient Client = new();
        private readonly List<Cliente> _clientes = new();

        public Form1()
        {
            InitializeComponent();
            Client.BaseAddress = new Uri("http://localhost:35005/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }



        private async void button1_Click(object sender, EventArgs e)
        {
            var response = await Client.GetAsync("Cliente");
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
            var response = await Client.GetAsync("Catalogo");
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
