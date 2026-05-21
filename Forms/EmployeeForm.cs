using System;
using System.Windows.Forms;
using MaintenanceApp.Data;
using MaintenanceApp.Models;

namespace MaintenanceApp.Forms
{
    public partial class EmployeeForm : Form
    {
        private readonly EmployeeRepository _repo = new EmployeeRepository();
        public Employee Result { get; private set; }
        private Employee _editing;

        public EmployeeForm(Employee editing = null)
        {
            InitializeComponent();
            _editing = editing;
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            if (_editing != null)
            {
                txtFullName.Text = _editing.FullName;
                txtPosition.Text = _editing.Position;
                txtPhone.Text = _editing.Phone;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Введите ФИО сотрудника.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Result = new Employee
            {
                Id = _editing?.Id ?? 0,
                FullName = txtFullName.Text.Trim(),
                Position = txtPosition.Text.Trim(),
                Phone = txtPhone.Text.Trim()
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