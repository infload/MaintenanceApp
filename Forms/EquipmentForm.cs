using System;
using System.Windows.Forms;
using MaintenanceApp.Data;
using MaintenanceApp.Models;

namespace MaintenanceApp.Forms
{
    public partial class EquipmentForm : Form
    {
        private readonly EquipmentRepository _repo = new EquipmentRepository();
        public Equipment Result { get; private set; }
        private Equipment _editing;

        public EquipmentForm(Equipment editing = null)
        {
            InitializeComponent();
            _editing = editing;
        }

        private void EquipmentForm_Load(object sender, EventArgs e)
        {
            if (_editing != null)
            {
                txtName.Text = _editing.Name;
                txtLocation.Text = _editing.Location;
                txtType.Text = _editing.Type;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите название оборудования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Result = new Equipment
            {
                Id = _editing?.Id ?? 0,
                Name = txtName.Text.Trim(),
                Location = txtLocation.Text.Trim(),
                Type = txtType.Text.Trim()
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}