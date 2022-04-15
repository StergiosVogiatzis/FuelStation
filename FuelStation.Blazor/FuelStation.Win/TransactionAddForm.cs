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
using DevExpress.XtraEditors.Controls;
using FuelStation.Blazor.Shared;
using FuelStation.Model;
using FuelStation.Services;

namespace FuelStation.Win
{
    public partial class TransactionAddForm : Form
    {
        private Guid _id = Guid.Empty;
        private HttpClient _client;
        TransactionEditViewModel transactionView = new();
        private List<CustomerEditViewModel> customerView = new();
        private CustomerEditViewModel _customer;
        private List<EmployeeEditViewModel> employeeView = new();
        private EmployeeEditViewModel _employee;
        private List<ItemEditViewModel> itemView = new();
        private ItemEditViewModel _item;
        private TransactionLineViewModel transactionLineView = new();
        private TransactionServices _transactionServices = new();
        BindingList<TransactionLineViewModel> _TransactionLines = new BindingList<TransactionLineViewModel>();
        //private List<TransactionLineViewModel> _transactionLine = new();
        private decimal discountPercent = 0.1m;

        public TransactionAddForm(HttpClient client)
        {
            InitializeComponent();
            _client = client;
        }

        private async void TransactionAddForm_Load(object sender, EventArgs e)
        {
            customerView = await _client.GetFromJsonAsync<List<CustomerEditViewModel>>($"customer");
            employeeView = await _client.GetFromJsonAsync<List<EmployeeEditViewModel>>($"employee");
            itemView = await _client.GetFromJsonAsync<List<ItemEditViewModel>>($"item");
            transactionView = await _client.GetFromJsonAsync<TransactionEditViewModel>($"transaction/{(_id == null ? Guid.Empty : _id)}");
            bsTransactionLine.DataSource = transactionLineView;
            await PopulateControls();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var selectedCustomerID = ctrlCustomer.SelectedValue;
            _customer = await _client.GetFromJsonAsync<CustomerEditViewModel>($"customer/{selectedCustomerID}");
            var selectedEmployeeID = ctrlEmployee.SelectedValue;
            _employee = await _client.GetFromJsonAsync<EmployeeEditViewModel>($"employee/{selectedEmployeeID}");
            transactionView.EmployeeID = _employee.ID;
            transactionView.EmployeeSurname = _employee.Surname;
            transactionView.CustomerID = _customer.ID;
            transactionView.CustomerSurname = _customer.Surname;
            transactionView.PaymentMethod = (PaymentMethod)ctrlPaymentMethod.SelectedValue ;
            transactionView.TotalValue = await _transactionServices.TransactionTotalValue(transactionView.TransactionLines);
            HttpResponseMessage response;
            response = await _client.PostAsJsonAsync("transaction", transactionView);
            response.EnsureSuccessStatusCode();
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private async Task PopulateControls()
        {
            ctrlCustomer.DataSource = customerView;
            ctrlCustomer.SelectedIndex = -1;
            ctrlCustomer.ValueMember = "ID";
            ctrlCustomer.DisplayMember = "CardNumber";

            ctrlEmployee.DataSource = employeeView;
            ctrlEmployee.SelectedIndex = -1;
            ctrlEmployee.ValueMember = "ID";
            ctrlEmployee.DisplayMember = "Surname";

            ctrlItem.DataSource = itemView;
            ctrlItem.SelectedIndex = -1;
            ctrlItem.ValueMember = "ID";
            ctrlItem.DisplayMember = "Description";

            ctrlPaymentMethod.DataSource = Enum.GetValues(typeof(PaymentMethod));

            ctrlItem.DataBindings.Add(new Binding("SelectedValue", bsTransactionLine, "ItemID", true));
            ctrlQuantity.DataBindings.Add(new Binding("Value", bsTransactionLine, "Quantity", true));
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {

            await AddItems();
            grvTransactionLines.DataSource = _TransactionLines;
            grvTransactionLines.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grvTransactionLines.Columns[0].Visible = false;
            grvTransactionLines.Columns[1].Visible = false;
            grvTransactionLines.Columns[2].Visible = false;
            grvTransactionLines.Columns[3].Visible = false;
            grvTransactionLines.Columns[4].Visible = false;
        }
        private async Task AddItems()
        {
            var selectedItemID = ctrlItem.SelectedValue;
            _item = await _client.GetFromJsonAsync<ItemEditViewModel>($"item/{selectedItemID}");
            transactionLineView.TransactionID = transactionView.ID;
            transactionLineView.ItemType = _item.ItemType;
            transactionLineView.ItemPrice = _item.Price;
            transactionLineView.DiscountPercent = discountPercent;
            transactionLineView.NetValue = await _transactionServices.CalculateNetValue(ctrlQuantity.Value, _item.Price);
            transactionLineView.DiscountValue = await _transactionServices.CalculateDiscountValue(transactionLineView.NetValue, discountPercent);
            transactionLineView.TotalValue = await _transactionServices.CalculateTotalValue(transactionLineView.NetValue, transactionLineView.DiscountValue);
            transactionView.TransactionLines.Add(transactionLineView);
            //check if we should apply discount
            transactionLineView.TotalValue = await _transactionServices.ApplyDiscount(transactionLineView.NetValue, transactionLineView.TotalValue, transactionView.TransactionLines);
            _TransactionLines.Add(transactionLineView);
            
        }
    }
}
