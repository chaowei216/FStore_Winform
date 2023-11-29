namespace SalesWinApp
{
    partial class frmMembers
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            lbMemberId = new Label();
            lbEmail = new Label();
            lbCompanyName = new Label();
            lbCity = new Label();
            lbCountry = new Label();
            lbPassword = new Label();
            txtMemberId = new TextBox();
            txtEmail = new TextBox();
            txtCompanyName = new TextBox();
            txtPassword = new TextBox();
            dgvMemberList = new DataGridView();
            memberIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            emailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            companyNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cityDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            countryDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            memberBindingSource = new BindingSource(components);
            btnExit = new Button();
            btnLoad = new Button();
            btnNew = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnCancel = new Button();
            cbCity = new ComboBox();
            cbCountry = new ComboBox();
            lbRole = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvMemberList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)memberBindingSource).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(295, 9);
            label1.Name = "label1";
            label1.Size = new Size(311, 38);
            label1.TabIndex = 0;
            label1.Text = "Member Management";
            // 
            // lbMemberId
            // 
            lbMemberId.AutoSize = true;
            lbMemberId.Location = new Point(56, 79);
            lbMemberId.Name = "lbMemberId";
            lbMemberId.Size = new Size(84, 20);
            lbMemberId.TabIndex = 1;
            lbMemberId.Text = "Member ID";
            // 
            // lbEmail
            // 
            lbEmail.AutoSize = true;
            lbEmail.Location = new Point(56, 129);
            lbEmail.Name = "lbEmail";
            lbEmail.Size = new Size(46, 20);
            lbEmail.TabIndex = 2;
            lbEmail.Text = "Email";
            // 
            // lbCompanyName
            // 
            lbCompanyName.AutoSize = true;
            lbCompanyName.Location = new Point(56, 175);
            lbCompanyName.Name = "lbCompanyName";
            lbCompanyName.Size = new Size(116, 20);
            lbCompanyName.TabIndex = 3;
            lbCompanyName.Text = "Company Name";
            // 
            // lbCity
            // 
            lbCity.AutoSize = true;
            lbCity.Location = new Point(477, 75);
            lbCity.Name = "lbCity";
            lbCity.Size = new Size(34, 20);
            lbCity.TabIndex = 4;
            lbCity.Text = "City";
            // 
            // lbCountry
            // 
            lbCountry.AutoSize = true;
            lbCountry.Location = new Point(477, 129);
            lbCountry.Name = "lbCountry";
            lbCountry.Size = new Size(60, 20);
            lbCountry.TabIndex = 5;
            lbCountry.Text = "Country";
            // 
            // lbPassword
            // 
            lbPassword.AutoSize = true;
            lbPassword.Location = new Point(477, 175);
            lbPassword.Name = "lbPassword";
            lbPassword.Size = new Size(70, 20);
            lbPassword.TabIndex = 6;
            lbPassword.Text = "Password";
            // 
            // txtMemberId
            // 
            txtMemberId.Enabled = false;
            txtMemberId.Location = new Point(199, 72);
            txtMemberId.Name = "txtMemberId";
            txtMemberId.Size = new Size(188, 27);
            txtMemberId.TabIndex = 7;
            // 
            // txtEmail
            // 
            txtEmail.Enabled = false;
            txtEmail.Location = new Point(199, 122);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(188, 27);
            txtEmail.TabIndex = 7;
            // 
            // txtCompanyName
            // 
            txtCompanyName.Enabled = false;
            txtCompanyName.Location = new Point(199, 168);
            txtCompanyName.Name = "txtCompanyName";
            txtCompanyName.Size = new Size(188, 27);
            txtCompanyName.TabIndex = 7;
            // 
            // txtPassword
            // 
            txtPassword.Enabled = false;
            txtPassword.Location = new Point(582, 168);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(190, 27);
            txtPassword.TabIndex = 7;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // dgvMemberList
            // 
            dgvMemberList.AutoGenerateColumns = false;
            dgvMemberList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMemberList.Columns.AddRange(new DataGridViewColumn[] { memberIdDataGridViewTextBoxColumn, emailDataGridViewTextBoxColumn, companyNameDataGridViewTextBoxColumn, cityDataGridViewTextBoxColumn, countryDataGridViewTextBoxColumn });
            dgvMemberList.DataSource = memberBindingSource;
            dgvMemberList.Location = new Point(34, 278);
            dgvMemberList.Name = "dgvMemberList";
            dgvMemberList.RowHeadersWidth = 51;
            dgvMemberList.RowTemplate.Height = 29;
            dgvMemberList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMemberList.Size = new Size(804, 188);
            dgvMemberList.TabIndex = 8;
            // 
            // memberIdDataGridViewTextBoxColumn
            // 
            memberIdDataGridViewTextBoxColumn.DataPropertyName = "MemberId";
            memberIdDataGridViewTextBoxColumn.HeaderText = "MemberId";
            memberIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            memberIdDataGridViewTextBoxColumn.Name = "memberIdDataGridViewTextBoxColumn";
            memberIdDataGridViewTextBoxColumn.ReadOnly = true;
            memberIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            emailDataGridViewTextBoxColumn.HeaderText = "Email";
            emailDataGridViewTextBoxColumn.MinimumWidth = 6;
            emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            emailDataGridViewTextBoxColumn.ReadOnly = true;
            emailDataGridViewTextBoxColumn.Width = 180;
            // 
            // companyNameDataGridViewTextBoxColumn
            // 
            companyNameDataGridViewTextBoxColumn.DataPropertyName = "CompanyName";
            companyNameDataGridViewTextBoxColumn.HeaderText = "CompanyName";
            companyNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            companyNameDataGridViewTextBoxColumn.Name = "companyNameDataGridViewTextBoxColumn";
            companyNameDataGridViewTextBoxColumn.ReadOnly = true;
            companyNameDataGridViewTextBoxColumn.Width = 175;
            // 
            // cityDataGridViewTextBoxColumn
            // 
            cityDataGridViewTextBoxColumn.DataPropertyName = "City";
            cityDataGridViewTextBoxColumn.HeaderText = "City";
            cityDataGridViewTextBoxColumn.MinimumWidth = 6;
            cityDataGridViewTextBoxColumn.Name = "cityDataGridViewTextBoxColumn";
            cityDataGridViewTextBoxColumn.ReadOnly = true;
            cityDataGridViewTextBoxColumn.Width = 135;
            // 
            // countryDataGridViewTextBoxColumn
            // 
            countryDataGridViewTextBoxColumn.DataPropertyName = "Country";
            countryDataGridViewTextBoxColumn.HeaderText = "Country";
            countryDataGridViewTextBoxColumn.MinimumWidth = 6;
            countryDataGridViewTextBoxColumn.Name = "countryDataGridViewTextBoxColumn";
            countryDataGridViewTextBoxColumn.ReadOnly = true;
            countryDataGridViewTextBoxColumn.Width = 135;
            // 
            // memberBindingSource
            // 
            memberBindingSource.DataSource = typeof(BusinessObject.Models.Member);
            // 
            // btnExit
            // 
            btnExit.Location = new Point(393, 485);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(94, 29);
            btnExit.TabIndex = 9;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(201, 216);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(94, 29);
            btnLoad.TabIndex = 10;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnNew
            // 
            btnNew.Enabled = false;
            btnNew.Location = new Point(340, 216);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(94, 29);
            btnNew.TabIndex = 11;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Enabled = false;
            btnUpdate.Location = new Point(477, 216);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 12;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Enabled = false;
            btnDelete.Location = new Point(611, 216);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 13;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(744, 216);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 14;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Visible = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // cbCity
            // 
            cbCity.Enabled = false;
            cbCity.FormattingEnabled = true;
            cbCity.Location = new Point(582, 71);
            cbCity.Name = "cbCity";
            cbCity.Size = new Size(190, 28);
            cbCity.TabIndex = 15;
            // 
            // cbCountry
            // 
            cbCountry.Enabled = false;
            cbCountry.FormattingEnabled = true;
            cbCountry.Items.AddRange(new object[] { "Viet Nam", "Korea", "Japan", "Chinna", "America" });
            cbCountry.Location = new Point(582, 121);
            cbCountry.Name = "cbCountry";
            cbCountry.Size = new Size(190, 28);
            cbCountry.TabIndex = 16;
            cbCountry.SelectedIndexChanged += cbCountry_SelectedIndexChanged;
            // 
            // lbRole
            // 
            lbRole.AutoSize = true;
            lbRole.ForeColor = Color.Red;
            lbRole.Location = new Point(34, 27);
            lbRole.Name = "lbRole";
            lbRole.Size = new Size(0, 20);
            lbRole.TabIndex = 17;
            // 
            // frmMembers
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(865, 526);
            Controls.Add(lbRole);
            Controls.Add(cbCountry);
            Controls.Add(cbCity);
            Controls.Add(btnCancel);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnNew);
            Controls.Add(btnLoad);
            Controls.Add(btnExit);
            Controls.Add(dgvMemberList);
            Controls.Add(txtPassword);
            Controls.Add(txtCompanyName);
            Controls.Add(txtEmail);
            Controls.Add(txtMemberId);
            Controls.Add(lbPassword);
            Controls.Add(lbCountry);
            Controls.Add(lbCity);
            Controls.Add(lbCompanyName);
            Controls.Add(lbEmail);
            Controls.Add(lbMemberId);
            Controls.Add(label1);
            Name = "frmMembers";
            Text = "frmMembers";
            ((System.ComponentModel.ISupportInitialize)dgvMemberList).EndInit();
            ((System.ComponentModel.ISupportInitialize)memberBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lbMemberId;
        private Label lbEmail;
        private Label lbCompanyName;
        private Label lbCity;
        private Label lbCountry;
        private Label lbPassword;
        private TextBox txtMemberId;
        private TextBox txtEmail;
        private TextBox txtCompanyName;
        private TextBox txtPassword;
        private DataGridView dgvMemberList;
        private BindingSource memberBindingSource;
        private Button btnExit;
        private Button btnLoad;
        private Button btnNew;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnCancel;
        private ComboBox cbCity;
        private ComboBox cbCountry;
        private DataGridViewTextBoxColumn memberIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn companyNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cityDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn countryDataGridViewTextBoxColumn;
        private Label lbRole;
    }
}