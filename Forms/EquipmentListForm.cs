using System;
using System.Windows.Forms;
using MaintenanceApp.Data;
using MaintenanceApp.Models;

namespace MaintenanceApp.Forms
{
    public partial class EquipmentListForm : Form
    {
        private readonly EquipmentRepository _repo = new EquipmentRepository();

        public EquipmentListForm()
        {
            InitializeComponent();
        }

        private void EquipmentListForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvEquipment.DataSource = null;
            dgvEquipment.DataSource = _repo.GetAll();
            if (dgvEquipment.Columns.Count > 0)
            {
                dgvEquipment.Columns["Id"].HeaderText = "№";
                dgvEquipment.Columns["Name"].HeaderText = "Название";
                dgvEquipment.Columns["Location"].HeaderText = "Расположение";
                dgvEquipment.Columns["Type"].HeaderText = "Тип";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new EquipmentForm())
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
            if (dgvEquipment.CurrentRow == null) return;
            var selected = (Equipment)dgvEquipment.CurrentRow.DataBoundItem;
            using (var form = new EquipmentForm(selected))
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
            if (dgvEquipment.CurrentRow == null) return;
            var selected = (Equipment)dgvEquipment.CurrentRow.DataBoundItem;
            if (MessageBox.Show($"Удалить оборудование «{selected.Name}»?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _repo.Delete(selected.Id);
                LoadData();
            }
        }
    }
}