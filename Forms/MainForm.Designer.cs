namespace MaintenanceApp.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private System.Windows.Forms.DataGridView dgvRequests;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnEmployees;
        private System.Windows.Forms.Button btnEquipment;
        private System.Windows.Forms.ComboBox cmbFilterStatus;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlBottom;

        private void InitializeComponent()
        {
            this.dgvRequests = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnEmployees = new System.Windows.Forms.Button();
            this.btnEquipment = new System.Windows.Forms.Button();
            this.cmbFilterStatus = new System.Windows.Forms.ComboBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();

            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 45;
            this.pnlTop.Controls.Add(this.lblFilter);
            this.pnlTop.Controls.Add(this.cmbFilterStatus);
            this.pnlTop.Controls.Add(this.btnEmployees);
            this.pnlTop.Controls.Add(this.btnEquipment);

            this.lblFilter.Text = "Фильтр по статусу:";
            this.lblFilter.Location = new System.Drawing.Point(12, 13);
            this.lblFilter.Size = new System.Drawing.Size(120, 20);

            this.cmbFilterStatus.Location = new System.Drawing.Point(138, 10);
            this.cmbFilterStatus.Size = new System.Drawing.Size(150, 23);
            this.cmbFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterStatus.SelectedIndexChanged += new System.EventHandler(this.cmbFilterStatus_SelectedIndexChanged);

            this.btnEmployees.Text = "Сотрудники";
            this.btnEmployees.Location = new System.Drawing.Point(620, 10);
            this.btnEmployees.Size = new System.Drawing.Size(110, 28);
            this.btnEmployees.Click += new System.EventHandler(this.btnEmployees_Click);

            this.btnEquipment.Text = "Оборудование";
            this.btnEquipment.Location = new System.Drawing.Point(740, 10);
            this.btnEquipment.Size = new System.Drawing.Size(120, 28);
            this.btnEquipment.Click += new System.EventHandler(this.btnEquipment_Click);

            this.dgvRequests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRequests.ReadOnly = true;
            this.dgvRequests.AllowUserToAddRows = false;
            this.dgvRequests.AllowUserToDeleteRows = false;
            this.dgvRequests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRequests.MultiSelect = false;
            this.dgvRequests.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRequests.DoubleClick += new System.EventHandler(this.dgvRequests_DoubleClick);

            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Height = 45;
            this.pnlBottom.Controls.Add(this.btnAdd);
            this.pnlBottom.Controls.Add(this.btnEdit);
            this.pnlBottom.Controls.Add(this.btnDelete);
            this.pnlBottom.Controls.Add(this.btnExport);

            this.btnAdd.Text = "Добавить";
            this.btnAdd.Location = new System.Drawing.Point(12, 8);
            this.btnAdd.Size = new System.Drawing.Size(100, 28);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnEdit.Text = "Редактировать";
            this.btnEdit.Location = new System.Drawing.Point(122, 8);
            this.btnEdit.Size = new System.Drawing.Size(120, 28);
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            this.btnDelete.Text = "Удалить";
            this.btnDelete.Location = new System.Drawing.Point(252, 8);
            this.btnDelete.Size = new System.Drawing.Size(100, 28);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.btnExport.Text = "Экспорт в Excel";
            this.btnExport.Location = new System.Drawing.Point(362, 8);
            this.btnExport.Size = new System.Drawing.Size(130, 28);
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);

            this.ClientSize = new System.Drawing.Size(900, 550);
            this.Text = "Система заявок на техобслуживание";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MainForm_Load);

            this.Controls.Add(this.dgvRequests);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);

            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}