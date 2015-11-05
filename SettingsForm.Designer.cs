namespace WebsiteConnectivityChecker
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.settingsTblLayout = new System.Windows.Forms.TableLayoutPanel();
            this.addAddressDescLb = new System.Windows.Forms.Label();
            this.webAddressLb = new System.Windows.Forms.Label();
            this.webAddressTxtBox = new System.Windows.Forms.TextBox();
            this.isPingChkBox = new System.Windows.Forms.CheckBox();
            this.addAddressBtn = new System.Windows.Forms.Button();
            this.addressListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gatewayLb = new System.Windows.Forms.Label();
            this.gatewayTxtBox = new System.Windows.Forms.TextBox();
            this.addGatewayDescLb = new System.Windows.Forms.Label();
            this.rmvAddressLb = new System.Windows.Forms.Label();
            this.rmvAddressBtn = new System.Windows.Forms.Button();
            this.gatewaySetBtn = new System.Windows.Forms.Button();
            this.gatewaySetLb = new System.Windows.Forms.Label();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.settingsTblLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // settingsTblLayout
            // 
            this.settingsTblLayout.ColumnCount = 4;
            this.settingsTblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.27624F));
            this.settingsTblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.72376F));
            this.settingsTblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 259F));
            this.settingsTblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 169F));
            this.settingsTblLayout.Controls.Add(this.addAddressDescLb, 0, 0);
            this.settingsTblLayout.Controls.Add(this.webAddressLb, 0, 1);
            this.settingsTblLayout.Controls.Add(this.webAddressTxtBox, 1, 1);
            this.settingsTblLayout.Controls.Add(this.isPingChkBox, 2, 1);
            this.settingsTblLayout.Controls.Add(this.addAddressBtn, 3, 1);
            this.settingsTblLayout.Controls.Add(this.addressListView, 0, 2);
            this.settingsTblLayout.Controls.Add(this.gatewayLb, 0, 5);
            this.settingsTblLayout.Controls.Add(this.gatewayTxtBox, 1, 5);
            this.settingsTblLayout.Controls.Add(this.addGatewayDescLb, 0, 4);
            this.settingsTblLayout.Controls.Add(this.rmvAddressLb, 0, 3);
            this.settingsTblLayout.Controls.Add(this.rmvAddressBtn, 3, 3);
            this.settingsTblLayout.Controls.Add(this.gatewaySetBtn, 3, 5);
            this.settingsTblLayout.Controls.Add(this.gatewaySetLb, 2, 5);
            this.settingsTblLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsTblLayout.Location = new System.Drawing.Point(5, 5);
            this.settingsTblLayout.Name = "settingsTblLayout";
            this.settingsTblLayout.RowCount = 6;
            this.settingsTblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.66421F));
            this.settingsTblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.46863F));
            this.settingsTblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.86716F));
            this.settingsTblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.settingsTblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.settingsTblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.settingsTblLayout.Size = new System.Drawing.Size(1177, 792);
            this.settingsTblLayout.TabIndex = 0;
            this.settingsTblLayout.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // addAddressDescLb
            // 
            this.addAddressDescLb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addAddressDescLb.AutoSize = true;
            this.settingsTblLayout.SetColumnSpan(this.addAddressDescLb, 4);
            this.addAddressDescLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addAddressDescLb.Location = new System.Drawing.Point(9, 13);
            this.addAddressDescLb.Name = "addAddressDescLb";
            this.addAddressDescLb.Size = new System.Drawing.Size(1158, 87);
            this.addAddressDescLb.TabIndex = 4;
            this.addAddressDescLb.Text = resources.GetString("addAddressDescLb.Text");
            // 
            // webAddressLb
            // 
            this.webAddressLb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.webAddressLb.AutoSize = true;
            this.webAddressLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.webAddressLb.Location = new System.Drawing.Point(9, 135);
            this.webAddressLb.Name = "webAddressLb";
            this.webAddressLb.Size = new System.Drawing.Size(170, 29);
            this.webAddressLb.TabIndex = 0;
            this.webAddressLb.Text = "Web Address :";
            // 
            // webAddressTxtBox
            // 
            this.webAddressTxtBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.webAddressTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.webAddressTxtBox.Location = new System.Drawing.Point(218, 132);
            this.webAddressTxtBox.Name = "webAddressTxtBox";
            this.webAddressTxtBox.Size = new System.Drawing.Size(500, 35);
            this.webAddressTxtBox.TabIndex = 1;
            // 
            // isPingChkBox
            // 
            this.isPingChkBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.isPingChkBox.AutoSize = true;
            this.isPingChkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isPingChkBox.Location = new System.Drawing.Point(763, 133);
            this.isPingChkBox.Name = "isPingChkBox";
            this.isPingChkBox.Size = new System.Drawing.Size(229, 33);
            this.isPingChkBox.TabIndex = 2;
            this.isPingChkBox.Text = "Check with Ping?";
            this.isPingChkBox.UseVisualStyleBackColor = true;
            // 
            // addAddressBtn
            // 
            this.addAddressBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addAddressBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addAddressBtn.Location = new System.Drawing.Point(1021, 123);
            this.addAddressBtn.Name = "addAddressBtn";
            this.addAddressBtn.Size = new System.Drawing.Size(141, 53);
            this.addAddressBtn.TabIndex = 3;
            this.addAddressBtn.Text = "Add";
            this.addAddressBtn.UseVisualStyleBackColor = true;
            this.addAddressBtn.Click += new System.EventHandler(this.addAddressBtn_Click);
            // 
            // addressListView
            // 
            this.addressListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.settingsTblLayout.SetColumnSpan(this.addressListView, 4);
            this.addressListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addressListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addressListView.Location = new System.Drawing.Point(3, 189);
            this.addressListView.Name = "addressListView";
            this.addressListView.Size = new System.Drawing.Size(1171, 355);
            this.addressListView.TabIndex = 5;
            this.addressListView.UseCompatibleStateImageBehavior = false;
            this.addressListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Web Address";
            this.columnHeader1.Width = 180;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Check Method";
            this.columnHeader2.Width = 180;
            // 
            // gatewayLb
            // 
            this.gatewayLb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gatewayLb.AutoSize = true;
            this.gatewayLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gatewayLb.Location = new System.Drawing.Point(24, 743);
            this.gatewayLb.Name = "gatewayLb";
            this.gatewayLb.Size = new System.Drawing.Size(140, 29);
            this.gatewayLb.TabIndex = 6;
            this.gatewayLb.Text = "Gateway IP:";
            // 
            // gatewayTxtBox
            // 
            this.gatewayTxtBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gatewayTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gatewayTxtBox.Location = new System.Drawing.Point(243, 740);
            this.gatewayTxtBox.Name = "gatewayTxtBox";
            this.gatewayTxtBox.Size = new System.Drawing.Size(450, 35);
            this.gatewayTxtBox.TabIndex = 7;
            // 
            // addGatewayDescLb
            // 
            this.addGatewayDescLb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addGatewayDescLb.AutoSize = true;
            this.settingsTblLayout.SetColumnSpan(this.addGatewayDescLb, 4);
            this.addGatewayDescLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addGatewayDescLb.Location = new System.Drawing.Point(4, 623);
            this.addGatewayDescLb.Name = "addGatewayDescLb";
            this.addGatewayDescLb.Size = new System.Drawing.Size(1169, 87);
            this.addGatewayDescLb.TabIndex = 8;
            this.addGatewayDescLb.Text = resources.GetString("addGatewayDescLb.Text");
            // 
            // rmvAddressLb
            // 
            this.rmvAddressLb.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rmvAddressLb.AutoSize = true;
            this.settingsTblLayout.SetColumnSpan(this.rmvAddressLb, 3);
            this.rmvAddressLb.Location = new System.Drawing.Point(3, 565);
            this.rmvAddressLb.Name = "rmvAddressLb";
            this.rmvAddressLb.Size = new System.Drawing.Size(829, 25);
            this.rmvAddressLb.TabIndex = 10;
            this.rmvAddressLb.Text = "To remove an address, select it from the list above and then press the remove but" +
    "ton.";
            // 
            // rmvAddressBtn
            // 
            this.rmvAddressBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rmvAddressBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rmvAddressBtn.Location = new System.Drawing.Point(1021, 551);
            this.rmvAddressBtn.Name = "rmvAddressBtn";
            this.rmvAddressBtn.Size = new System.Drawing.Size(141, 53);
            this.rmvAddressBtn.TabIndex = 11;
            this.rmvAddressBtn.Text = "Remove";
            this.rmvAddressBtn.UseVisualStyleBackColor = true;
            this.rmvAddressBtn.Click += new System.EventHandler(this.rmvAddressBtn_Click);
            // 
            // gatewaySetBtn
            // 
            this.gatewaySetBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gatewaySetBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gatewaySetBtn.Location = new System.Drawing.Point(1021, 731);
            this.gatewaySetBtn.Name = "gatewaySetBtn";
            this.gatewaySetBtn.Size = new System.Drawing.Size(141, 53);
            this.gatewaySetBtn.TabIndex = 9;
            this.gatewaySetBtn.Text = "Set";
            this.gatewaySetBtn.UseVisualStyleBackColor = true;
            this.gatewaySetBtn.Click += new System.EventHandler(this.gatewaySetBtn_Click);
            // 
            // gatewaySetLb
            // 
            this.gatewaySetLb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gatewaySetLb.AutoSize = true;
            this.gatewaySetLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gatewaySetLb.Location = new System.Drawing.Point(753, 743);
            this.gatewaySetLb.Name = "gatewaySetLb";
            this.gatewaySetLb.Size = new System.Drawing.Size(248, 29);
            this.gatewaySetLb.TabIndex = 12;
            this.gatewaySetLb.Text = "Gateway IP Set: False";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Available";
            this.columnHeader3.Width = 180;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 802);
            this.Controls.Add(this.settingsTblLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.settingsTblLayout.ResumeLayout(false);
            this.settingsTblLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel settingsTblLayout;
        private System.Windows.Forms.Label webAddressLb;
        private System.Windows.Forms.TextBox webAddressTxtBox;
        private System.Windows.Forms.CheckBox isPingChkBox;
        private System.Windows.Forms.Label addAddressDescLb;
        private System.Windows.Forms.Button addAddressBtn;
        private System.Windows.Forms.ListView addressListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label gatewayLb;
        private System.Windows.Forms.TextBox gatewayTxtBox;
        private System.Windows.Forms.Label addGatewayDescLb;
        private System.Windows.Forms.Button gatewaySetBtn;
        private System.Windows.Forms.Label rmvAddressLb;
        private System.Windows.Forms.Button rmvAddressBtn;
        private System.Windows.Forms.Label gatewaySetLb;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}