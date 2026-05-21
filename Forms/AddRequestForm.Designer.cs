namespace MaintenanceApp.Forms
{
    partial class AddRequestForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.ComboBox cmbPriority;
        private System.Windows.Forms.ComboBox cmbEquipment;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.Label lblEquipment;
        private System.Windows.Forms.Label lblEmployee;

        private void InitializeComponent()
        {
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.cmbPriority = new System.Windows.Forms.ComboBox();
            this.cmbEquipment = new System.Windows.Forms.ComboBox();
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblPriority = new System.Windows.Forms.Label();
            this.lblEquipment = new System.Windows.Forms.Label();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.SuspendLayout();

            this.lblTitle.Text = "Название:";
            this.lblTitle.Location = new System.Drawing.Point(12, 15);
            this.lblTitle.Size = new System.Drawing.Size(100, 20);

            this.txtTitle.Location = new System.Drawing.Point(120, 12);
            this.txtTitle.Size = new System.Drawing.Size(300, 23);

            this.lblDesc.Text = "Описание:";
            this.lblDesc.Location = new System.Drawing.Point(12, 50);
            this.lblDesc.Size = new System.Drawing.Size(100, 20);

            this.txtDescription.Location = new System.Drawing.Point(120, 47);
            this.txtDescription.Size = new System.Drawing.Size(300, 80);
            this.txtDescription.Multiline = true;

            this.lblStatus.Text = "Статус:";
            this.lblStatus.Location = new System.Drawing.Point(12, 145);
            this.lblStatus.Size = new System.Drawing.Size(100, 20);

            this.cmbStatus.Location = new System.Drawing.Point(120, 142);
            this.cmbStatus.Size = new System.Drawing.Size(300, 23);
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.lblPriority.Text = "Приоритет:";
            this.lblPriority.Location = new System.Drawing.Point(12, 182);
            this.lblPriority.Size = new System.Drawing.Size(100, 20);

            this.cmbPriority.Location = new System.Drawing.Point(120, 179);
            this.cmbPriority.Size = new System.Drawing.Size(300, 23);
            this.cmbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.lblEquipment.Text = "Оборудование:";
            this.lblEquipment.Location = new System.Drawing.Point(12, 219);
            this.lblEquipment.Size = new System.Drawing.Size(100, 20);

            this.cmbEquipment.Location = new System.Drawing.Point(120, 216);
            this.cmbEquipment.Size = new System.Drawing.Size(300, 23);
            this.cmbEquipment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.lblEmployee.Text = "Исполнитель:";
            this.lblEmployee.Location = new System.Drawing.Point(12, 256);
            this.lblEmployee.Size = new System.Drawing.Size(100, 20);

            this.cmbEmployee.Location = new System.Drawing.Point(120, 253);
            this.cmbEmployee.Size = new System.Drawing.Size(300, 23);
            this.cmbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.btnSave.Text = "Сохранить";
            this.btnSave.Location = new System.Drawing.Point(120, 300);
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.Text = "Отмена";
            this.btnCancel.Location = new System.Drawing.Point(235, 300);
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.ClientSize = new System.Drawing.Size(450, 360);
            this.Text = "Заявка";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.AddRequestForm_Load);

            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblPriority);
            this.Controls.Add(this.cmbPriority);
            this.Controls.Add(this.lblEquipment);
            this.Controls.Add(this.cmbEquipment);
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.cmbEmployee);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);

            this.ResumeLayout(false);
        }
    }
}