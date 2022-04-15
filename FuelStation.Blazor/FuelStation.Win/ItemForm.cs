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
    public partial class ItemForm : Form
    {
        public HttpClient _client;
        public List<ItemViewModel> itemList = new();
        public ItemForm(HttpClient client)
        {
            InitializeComponent();
            _client = client;
        }

        private async void ItemForm_Load(object sender, EventArgs e)
        {
            await GetItems();
        }
        public async Task GetItems()
        {
            itemList = await _client.GetFromJsonAsync<List<ItemViewModel>>("item");
            bsItems.DataSource = itemList;
            grvItems.DataSource = bsItems;
            grvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grvItems.Columns[0].Visible = false;

        }

        private async void btnAddItem_Click(object sender, EventArgs e)
        {
            var itemAdd = new ItemEditForm(_client);
            itemAdd.ShowDialog();
            await GetItems();
        }

        private async void btnEditItem_Click(object sender, EventArgs e)
        {
            var item = bsItems.Current as ItemViewModel;
            if (item != null)
            {
                var itemEdit = new ItemEditForm(_client, item.ID);
                itemEdit.ShowDialog();
                await GetItems();
            }
        }

        private async void btnDeleteItem_Click(object sender, EventArgs e)
        {
            var item = bsItems.Current as ItemViewModel;
            if (item != null)
            {
                var response = await _client.DeleteAsync($"item/{item.ID}");
                response.EnsureSuccessStatusCode();
                await GetItems();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
