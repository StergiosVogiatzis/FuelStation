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
    public partial class TransactionForm : Form
    {
        public HttpClient _client;
        public List<TransactionViewModel> transactionItem = new();
        public TransactionForm(HttpClient client)
        {
            InitializeComponent();
            _client = client;
        }

        private async void TransactionForm_Load(object sender, EventArgs e)
        {
            await GetTransactions();
        }
        private async Task GetTransactions()
        {
            transactionItem = await _client.GetFromJsonAsync<List<TransactionViewModel>>("transaction");
            bsTransactions.DataSource = transactionItem;
            grvTransactions.DataSource = bsTransactions;
            grvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grvTransactions.Columns[0].Visible = false;
            grvTransactions.Columns[2].Visible = false; 
            grvTransactions.Columns[4].Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private async void btnAddTransaction_Click(object sender, EventArgs e)
        {
            var transactionAdd = new TransactionAddForm(_client);
            transactionAdd.ShowDialog();
            await GetTransactions();
        }
    }
}
