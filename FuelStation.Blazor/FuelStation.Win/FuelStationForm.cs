using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuelStation.Win
{
    public partial class FuelStationForm : Form
    {
        
        public HttpClient _client = new HttpClient();
        public FuelStationForm()
        {
            InitializeComponent();
            //localhost:7236
            _client.BaseAddress = new Uri("https://localhost:7236");
        }

        private void FuelStationForm_Load(object sender, EventArgs e)
        {

        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var customerF = new CustomerForm(_client);
            customerF.ShowDialog();
        }

        private void itemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var itemF = new ItemForm(_client);
            itemF.ShowDialog();
        }

        private void transactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var transactionF = new TransactionForm(_client);
            transactionF.ShowDialog();
        }
    }
}
