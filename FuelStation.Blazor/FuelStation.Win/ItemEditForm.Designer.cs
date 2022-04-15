namespace FuelStation.Win
{
    partial class ItemEditForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ctrlCode = new System.Windows.Forms.TextBox();
            this.ctrlDescription = new System.Windows.Forms.TextBox();
            this.ctrlType = new System.Windows.Forms.ComboBox();
            this.ctrlCost = new System.Windows.Forms.NumericUpDown();
            this.ctrlPrice = new System.Windows.Forms.NumericUpDown();
            this.bsItem = new System.Windows.Forms.BindingSource(this.components);
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsItem)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Cost";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Price";
            // 
            // ctrlCode
            // 
            this.ctrlCode.Location = new System.Drawing.Point(99, 9);
            this.ctrlCode.Name = "ctrlCode";
            this.ctrlCode.Size = new System.Drawing.Size(100, 23);
            this.ctrlCode.TabIndex = 5;
            // 
            // ctrlDescription
            // 
            this.ctrlDescription.Location = new System.Drawing.Point(99, 38);
            this.ctrlDescription.Name = "ctrlDescription";
            this.ctrlDescription.Size = new System.Drawing.Size(258, 23);
            this.ctrlDescription.TabIndex = 6;
            // 
            // ctrlType
            // 
            this.ctrlType.FormattingEnabled = true;
            this.ctrlType.Location = new System.Drawing.Point(99, 67);
            this.ctrlType.Name = "ctrlType";
            this.ctrlType.Size = new System.Drawing.Size(139, 23);
            this.ctrlType.TabIndex = 7;
            // 
            // ctrlCost
            // 
            this.ctrlCost.Location = new System.Drawing.Point(99, 125);
            this.ctrlCost.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.ctrlCost.Name = "ctrlCost";
            this.ctrlCost.Size = new System.Drawing.Size(85, 23);
            this.ctrlCost.TabIndex = 8;
            // 
            // ctrlPrice
            // 
            this.ctrlPrice.Location = new System.Drawing.Point(99, 96);
            this.ctrlPrice.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.ctrlPrice.Name = "ctrlPrice";
            this.ctrlPrice.Size = new System.Drawing.Size(85, 23);
            this.ctrlPrice.TabIndex = 9;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(678, 399);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 39);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(562, 399);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 39);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ItemEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.ctrlPrice);
            this.Controls.Add(this.ctrlCost);
            this.Controls.Add(this.ctrlType);
            this.Controls.Add(this.ctrlDescription);
            this.Controls.Add(this.ctrlCode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ItemEditForm";
            this.Text = "Edit Item";
            this.Load += new System.EventHandler(this.ItemEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ctrlCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox ctrlCode;
        private TextBox ctrlDescription;
        private ComboBox ctrlType;
        private NumericUpDown ctrlCost;
        private NumericUpDown ctrlPrice;
        private BindingSource bsItem;
        private Button btnCancel;
        private Button btnSave;
    }
}