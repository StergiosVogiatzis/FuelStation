namespace FuelStation.Win
{
    partial class TransactionAddForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.bsTransaction = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ctrlPaymentMethod = new System.Windows.Forms.ComboBox();
            this.grvTransactionLines = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.bsTransactionLine = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ctrlQuantity = new System.Windows.Forms.NumericUpDown();
            this.ctrlItem = new System.Windows.Forms.ComboBox();
            this.ctrlEmployee = new System.Windows.Forms.ComboBox();
            this.ctrlCustomer = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.bsTransaction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTransactionLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTransactionLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(678, 399);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 39);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(560, 399);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 39);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Employee";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "Customer";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 15);
            this.label3.TabIndex = 16;
            this.label3.Text = "Payment Method";
            // 
            // ctrlPaymentMethod
            // 
            this.ctrlPaymentMethod.FormattingEnabled = true;
            this.ctrlPaymentMethod.Location = new System.Drawing.Point(114, 69);
            this.ctrlPaymentMethod.Name = "ctrlPaymentMethod";
            this.ctrlPaymentMethod.Size = new System.Drawing.Size(141, 23);
            this.ctrlPaymentMethod.TabIndex = 19;
            // 
            // grvTransactionLines
            // 
            this.grvTransactionLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvTransactionLines.Location = new System.Drawing.Point(12, 109);
            this.grvTransactionLines.Name = "grvTransactionLines";
            this.grvTransactionLines.ReadOnly = true;
            this.grvTransactionLines.RowTemplate.Height = 25;
            this.grvTransactionLines.Size = new System.Drawing.Size(776, 284);
            this.grvTransactionLines.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(444, 399);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 39);
            this.button1.TabIndex = 21;
            this.button1.Text = "Add Item";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(531, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 15);
            this.label4.TabIndex = 24;
            this.label4.Text = "Item";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(531, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 15);
            this.label5.TabIndex = 25;
            this.label5.Text = "Quantity";
            // 
            // ctrlQuantity
            // 
            this.ctrlQuantity.Location = new System.Drawing.Point(590, 37);
            this.ctrlQuantity.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ctrlQuantity.Name = "ctrlQuantity";
            this.ctrlQuantity.Size = new System.Drawing.Size(80, 23);
            this.ctrlQuantity.TabIndex = 26;
            // 
            // ctrlItem
            // 
            this.ctrlItem.FormattingEnabled = true;
            this.ctrlItem.Location = new System.Drawing.Point(590, 9);
            this.ctrlItem.Name = "ctrlItem";
            this.ctrlItem.Size = new System.Drawing.Size(137, 23);
            this.ctrlItem.TabIndex = 27;
            // 
            // ctrlEmployee
            // 
            this.ctrlEmployee.FormattingEnabled = true;
            this.ctrlEmployee.Location = new System.Drawing.Point(114, 9);
            this.ctrlEmployee.Name = "ctrlEmployee";
            this.ctrlEmployee.Size = new System.Drawing.Size(160, 23);
            this.ctrlEmployee.TabIndex = 28;
            // 
            // ctrlCustomer
            // 
            this.ctrlCustomer.FormattingEnabled = true;
            this.ctrlCustomer.Location = new System.Drawing.Point(114, 39);
            this.ctrlCustomer.Name = "ctrlCustomer";
            this.ctrlCustomer.Size = new System.Drawing.Size(160, 23);
            this.ctrlCustomer.TabIndex = 29;
            // 
            // TransactionAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ctrlCustomer);
            this.Controls.Add(this.ctrlEmployee);
            this.Controls.Add(this.ctrlItem);
            this.Controls.Add(this.ctrlQuantity);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grvTransactionLines);
            this.Controls.Add(this.ctrlPaymentMethod);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Name = "TransactionAddForm";
            this.Text = "Add Transaction";
            this.Load += new System.EventHandler(this.TransactionAddForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsTransaction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTransactionLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsTransactionLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnCancel;
        private Button btnSave;
        private BindingSource bsTransaction;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox ctrlPaymentMethod;
        private DataGridView grvTransactionLines;
        private Button button1;
        private BindingSource bsTransactionLine;
        private Label label4;
        private Label label5;
        private NumericUpDown ctrlQuantity;
        private ComboBox ctrlItem;
        private ComboBox ctrlEmployee;
        private ComboBox ctrlCustomer;
    }
}