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
using FuelStation.Model;

namespace FuelStation.Win
{
    public partial class ItemEditForm : Form
    {
        private Guid _id;
        private HttpClient _client;
        ItemEditViewModel ItemView = new();
        public ItemEditForm(HttpClient client)
        {
            InitializeComponent();
            _client = client;
        }
        public ItemEditForm(HttpClient client, Guid id)
        {
            InitializeComponent();
            _client = client;
            _id = id;
        }

        private async void ItemEditForm_Load(object sender, EventArgs e)
        {
            ItemView = await _client.GetFromJsonAsync<ItemEditViewModel>($"item/{(_id == null ? Guid.Empty : _id)}");
            bsItem.DataSource = ItemView;
            await PopulateControls();
        }
        private async Task PopulateControls()
        {
            ctrlType.DataSource = Enum.GetValues(typeof(ItemType));

            ctrlCode.DataBindings.Add(new Binding("Text", bsItem, "Code", true));
            ctrlDescription.DataBindings.Add(new Binding("Text", bsItem, "Description", true));
            ctrlType.DataBindings.Add(new Binding("SelectedItem", bsItem, "ItemType", true));
            ctrlPrice.DataBindings.Add(new Binding("Value", bsItem, "Price", true));
            ctrlCost.DataBindings.Add(new Binding("Value", bsItem, "Cost", true));
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            HttpResponseMessage response;
            if (_id == null || _id == Guid.Empty)
            {
                response = await _client.PostAsJsonAsync("item", ItemView);
            }
            else
            {
                response = await _client.PutAsJsonAsync("item", ItemView);
            }
            response.EnsureSuccessStatusCode();
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
