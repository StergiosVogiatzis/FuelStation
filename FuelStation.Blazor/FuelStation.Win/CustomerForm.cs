using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FuelStation.Blazor.Shared;

namespace FuelStation.Win
{
    public partial class CustomerForm : Form
    {
        
        public HttpClient _client;
        public List<CustomerViewModel> customerList = new();
        public CustomerForm(HttpClient client)
        {
            InitializeComponent();
            _client = client;
        }
        public async Task GetCustomers()
        {
            customerList = await _client.GetFromJsonAsync<List<CustomerViewModel>>("customer");
            bsCustomers.DataSource = customerList;
            grvCustomers.DataSource = bsCustomers;
            grvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grvCustomers.Columns[0].Visible = false;
            
        }

        private async void CustomerForm_Load(object sender, EventArgs e)
        {
            await GetCustomers();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private async void btnAddCustomer_Click(object sender, EventArgs e)
        {
            var customerAdd = new CustomerEditForm(_client);
            customerAdd.ShowDialog();
            await GetCustomers();
        }

        private async void btnEditCustomer_Click(object sender, EventArgs e)
        {
            var customer = bsCustomers.Current as CustomerViewModel;
            if(customer != null)
            {
                var customerEdit = new CustomerEditForm(_client, customer.ID);
                customerEdit.ShowDialog();
                await GetCustomers();
            }
            
        }

        private async void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            var customer = bsCustomers.Current as CustomerViewModel;
            if (customer != null)
            {
                var response = await _client.DeleteAsync($"customer/{customer.ID}");
                response.EnsureSuccessStatusCode();
                await GetCustomers();
            }
        }
    }
}
