using System;
using System.Windows.Forms;
using MaintenanceApp.Data;
using MaintenanceApp.Models;

namespace MaintenanceApp.Forms
{
    public partial class AddRequestForm : Form
    {
        private readonly EquipmentRepository _eqRepo = new EquipmentRepository();
        private readonly EmployeeRepository _empRepo = new EmployeeRepository();
        public Request Result { get; private set; }
        private Request _editing;

        public AddRequestForm(Request editing = null)
        {
            InitializeComponent();
            _editing = editing;
        }

        private void AddRequestForm_Load(object sender, EventArgs e)
        {
            cmbStatus.Items.AddRange(new[] { "Новая", "В работе", "Завершена", "Отменена" });
            cmbPriority.Items.AddRange(new[] { "Низкий", "Средний", "Высокий", "Критический" });

            var equipment = _eqRepo.GetAll();
            cmbEquipment.DataSource = equipment;
            cmbEquipment.DisplayMember = "Name";
            cmbEquipment.ValueMember = "Id";

            var employees = _empRepo.GetAll();
            cmbEmployee.DataSource = employees;
            cmbEmployee.DisplayMember = "FullName";
            cmbEmployee.ValueMember = "Id";

            if (_editing != null)
            {
                txtTitle.Text = _editing.Title;
                txtDescription.Text = _editing.Description;
                cmbStatus.SelectedItem = _editing.Status;
                cmbPriority.SelectedItem = _editing.Priority;
                cmbEquipment.SelectedValue = _editing.EquipmentId;
                cmbEmployee.SelectedValue = _editing.EmployeeId;
            }
            else
            {
                cmbStatus.SelectedIndex = 0;
                cmbPriority.SelectedIndex = 1;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Введите название заявки.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Result = new Request
            {
                Id = _editing?.Id ?? 0,
                Title = txtTitle.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                Status = cmbStatus.SelectedItem.ToString(),
                Priority = cmbPriority.SelectedItem.ToString(),
                CreatedAt = _editing?.CreatedAt ?? DateTime.Now,
                EquipmentId = (int)cmbEquipment.SelectedValue,
                EmployeeId = (int)cmbEmployee.SelectedValue
            };

            if (Result.Status == "Завершена")
                Result.CompletedAt = _editing?.CompletedAt ?? DateTime.Now;
            else
                Result.CompletedAt = null;

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