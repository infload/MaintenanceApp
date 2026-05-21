namespace MaintenanceApp.Forms
{
    partial class EmployeeForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblPhone;

        private void InitializeComponent()
        {
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.SuspendLayout();

            this.lblFullName.Text = "ФИО:";
            this.lblFullName.Location = new System.Drawing.Point(12, 15);
            this.lblFullName.Size = new System.Drawing.Size(100, 20);

            this.txtFullName.Location = new System.Drawing.Point(120, 12);
            this.txtFullName.Size = new System.Drawing.Size(280, 23);

            this.lblPosition.Text = "Должность:";
            this.lblPosition.Location = new System.Drawing.Point(12, 50);
            this.lblPosition.Size = new System.Drawing.Size(100, 20);

            this.txtPosition.Location = new System.Drawing.Point(120, 47);
            this.txtPosition.Size = new System.Drawing.Size(280, 23);

            this.lblPhone.Text = "Телефон:";
            this.lblPhone.Location = new System.Drawing.Point(12, 85);
            this.lblPhone.Size = new System.Drawing.Size(100, 20);

            this.txtPhone.Location = new System.Drawing.Point(120, 82);
            this.txtPhone.Size = new System.Drawing.Size(280, 23);

            this.btnSave.Text = "Сохранить";
            this.btnSave.Location = new System.Drawing.Point(120, 130);
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.Text = "Отмена";
            this.btnCancel.Location = new System.Drawing.Point(235, 130);
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.ClientSize = new System.Drawing.Size(430, 190);
            this.Text = "Сотрудник";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.EmployeeForm_Load);

            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.txtPosition);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);

            this.ResumeLayout(false);
        }
    }
}