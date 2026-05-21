using System;
using System.Windows.Forms;
using MaintenanceApp.Data;
using MaintenanceApp.Models;

namespace MaintenanceApp.Forms
{
    public partial class EmployeesListForm : Form
    {
        private readonly EmployeeRepository _repo = new EmployeeRepository();

        public EmployeesListForm()
        {
            InitializeComponent();
        }

        private void EmployeesListForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvEmployees.DataSource = null;
            dgvEmployees.DataSource = _repo.GetAll();
            if (dgvEmployees.Columns.Count > 0)
            {
                dgvEmployees.Columns["Id"].HeaderText = "№";
                dgvEmployees.Columns["FullName"].HeaderText = "ФИО";
                dgvEmployees.Columns["Position"].HeaderText = "Должность";
                dgvEmployees.Columns["Phone"].HeaderText = "Телефон";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new EmployeeForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _repo.Add(form.Result);
                    LoadData();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.CurrentRow == null) return;
            var selected = (Employee)dgvEmployees.CurrentRow.DataBoundItem;
            using (var form = new EmployeeForm(selected))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _repo.Update(form.Result);
                    LoadData();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.CurrentRow == null) return;
            var selected = (Employee)dgvEmployees.CurrentRow.DataBoundItem;
            if (MessageBox.Show($"Удалить сотрудника «{selected.FullName}»?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _repo.Delete(selected.Id);
                LoadData();
            }
        }
    }
}