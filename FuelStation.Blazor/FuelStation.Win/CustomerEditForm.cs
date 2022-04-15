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
    public partial class CustomerEditForm : Form
    {
        public Guid _id;
        public HttpClient _client;
        CustomerEditViewModel CustomerItem = new();
        public CustomerEditForm(HttpClient client)
        {
            InitializeComponent();
            _client = client;
        }
        public CustomerEditForm(HttpClient client, Guid id)
        {
            InitializeComponent();
            _client = client;
            _id = id;
        }

        private async void CustomerEditForm_Load(object sender, EventArgs e)
        {
            CustomerItem = await _client.GetFromJsonAsync<CustomerEditViewModel>($"customer/{(_id == null ? Guid.Empty : _id)}");
            bsCustomer.DataSource = CustomerItem;
            await PopulateControls();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private async Task PopulateControls()
        {
            ctrlName.DataBindings.Add(new Binding("Text", bsCustomer, "Name", true));
            ctrlSurname.DataBindings.Add(new Binding("Text", bsCustomer, "Surname", true));
            ctrlCardNumber.DataBindings.Add(new Binding("Text", bsCustomer, "CardNumber", true));
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            HttpResponseMessage response;
            if (_id == null || _id == Guid.Empty)
            {
                response = await _client.PostAsJsonAsync("customer", CustomerItem);
            }
            else
            {
                response = await _client.PutAsJsonAsync("customer", CustomerItem);
            }
            response.EnsureSuccessStatusCode();
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
