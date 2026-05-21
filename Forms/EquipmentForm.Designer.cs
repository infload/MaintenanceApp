namespace MaintenanceApp.Forms
{
    partial class EquipmentForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblType;

        private void InitializeComponent()
        {
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.SuspendLayout();

            this.lblName.Text = "Название:";
            this.lblName.Location = new System.Drawing.Point(12, 15);
            this.lblName.Size = new System.Drawing.Size(100, 20);

            this.txtName.Location = new System.Drawing.Point(120, 12);
            this.txtName.Size = new System.Drawing.Size(280, 23);

            this.lblLocation.Text = "Расположение:";
            this.lblLocation.Location = new System.Drawing.Point(12, 50);
            this.lblLocation.Size = new System.Drawing.Size(100, 20);

            this.txtLocation.Location = new System.Drawing.Point(120, 47);
            this.txtLocation.Size = new System.Drawing.Size(280, 23);

            this.lblType.Text = "Тип:";
            this.lblType.Location = new System.Drawing.Point(12, 85);
            this.lblType.Size = new System.Drawing.Size(100, 20);

            this.txtType.Location = new System.Drawing.Point(120, 82);
            this.txtType.Size = new System.Drawing.Size(280, 23);

            this.btnSave.Text = "Сохранить";
            this.btnSave.Location = new System.Drawing.Point(120, 130);
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.Text = "Отмена";
            this.btnCancel.Location = new System.Drawing.Point(235, 130);
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.ClientSize = new System.Drawing.Size(430, 190);
            this.Text = "Оборудование";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.EquipmentForm_Load);

            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);

            this.ResumeLayout(false);
        }
    }
}