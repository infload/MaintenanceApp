using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MaintenanceApp.Data;
using MaintenanceApp.Models;
using MaintenanceApp.Reports;

namespace MaintenanceApp.Forms
{
    public partial class MainForm : Form
    {
        private readonly RequestRepository _reqRepo = new RequestRepository();
        private readonly EquipmentRepository _eqRepo = new EquipmentRepository();
        private readonly EmployeeRepository _empRepo = new EmployeeRepository();
        private readonly ExcelExporter _exporter = new ExcelExporter();
        private List<Request> _requests = new List<Request>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            cmbFilterStatus.Items.Add("Все");
            cmbFilterStatus.Items.Add("Новая");
            cmbFilterStatus.Items.Add("В работе");
            cmbFilterStatus.Items.Add("Завершена");
            cmbFilterStatus.Items.Add("Отменена");
            cmbFilterStatus.SelectedIndex = 0;
            LoadRequests();
        }

        private void LoadRequests()
        {
            _requests = _reqRepo.GetAll();
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            var filter = cmbFilterStatus.SelectedItem.ToString();
            var filtered = filter == "Все" ? _requests : _requests.Where(r => r.Status == filter).ToList();

            dgvRequests.DataSource = null;
            dgvRequests.DataSource = filtered;

            if (dgvRequests.Columns.Count > 0)
            {
                dgvRequests.Columns["Id"].HeaderText = "№";
                dgvRequests.Columns["Title"].HeaderText = "Название";
                dgvRequests.Columns["Description"].HeaderText = "Описание";
                dgvRequests.Columns["Status"].HeaderText = "Статус";
                dgvRequests.Columns["Priority"].HeaderText = "Приоритет";
                dgvRequests.Columns["CreatedAt"].HeaderText = "Создана";
                dgvRequests.Columns["CompletedAt"].HeaderText = "Завершена";
                dgvRequests.Columns["EquipmentName"].HeaderText = "Оборудование";
                dgvRequests.Columns["EmployeeName"].HeaderText = "Исполнитель";
                dgvRequests.Columns["EquipmentId"].Visible = false;
                dgvRequests.Columns["EmployeeId"].Visible = false;
            }
        }

        private void cmbFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_eqRepo.GetAll().Count == 0 || _empRepo.GetAll().Count == 0)
            {
                MessageBox.Show("Сначала добавьте оборудование и сотрудников.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var form = new AddRequestForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _reqRepo.Add(form.Result);
                    LoadRequests();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvRequests.CurrentRow == null) return;
            var selected = (Request)dgvRequests.CurrentRow.DataBoundItem;

            using (var form = new AddRequestForm(selected))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _reqRepo.Update(form.Result);
                    LoadRequests();
                }
            }
        }

        private void dgvRequests_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvRequests.CurrentRow == null) return;
            var selected = (Request)dgvRequests.CurrentRow.DataBoundItem;

            if (MessageBox.Show($"Удалить заявку «{selected.Title}»?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _reqRepo.Delete(selected.Id);
                LoadRequests();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (var dlg = new SaveFileDialog())
            {
                dlg.Filter = "Excel файлы (*.xlsx)|*.xlsx";
                dlg.FileName = "Заявки_" + DateTime.Now.ToString("yyyyMMdd");
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _exporter.ExportRequests(_requests, dlg.FileName);
                    MessageBox.Show("Экспорт завершён.", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            using (var form = new EmployeesListForm())
            {
                form.ShowDialog();
            }
        }

        private void btnEquipment_Click(object sender, EventArgs e)
        {
            using (var form = new EquipmentListForm())
            {
                form.ShowDialog();
            }
        }
    }
}