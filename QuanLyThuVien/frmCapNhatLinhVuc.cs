using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLyThuVien.Service;
using QuanLyThuVien.Model;

namespace QuanLyThuVien
{
    public partial class frmCapNhatLinhVuc : Form
    {
        public frmCapNhatLinhVuc()
        {
            InitializeComponent();
        }

        private ConnectService connectSer = new ConnectService();
        private LinhVucService linhVucSer = new LinhVucService();
        private tblLinhVucModel linhVucMod = new tblLinhVucModel();
        private string action = "";

        private void capNhatLinhVuc_Load(object sender, EventArgs e)
        {
            connectSer.Connect();
            linhVucSer.getAll(dgvLinhVuc);
        }

        private void clearText()
        {
            txtMaLinhVuc.Text = "";
            txtTenLinhVuc.Text = "";
            rtbGhiChu.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            clearText();
            txtMaLinhVuc.Enabled = true;
            txtTenLinhVuc.Enabled = true;
            rtbGhiChu.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            action = "add";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?(Y/N)", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    linhVucSer.deleteModel(txtMaLinhVuc.Text);
                    MessageBox.Show("Xóa thành công");
                    clearText();
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    linhVucSer.getAll(dgvLinhVuc);
                }
                catch
                {
                    MessageBox.Show("Phải xóa những thông tin liên quan đến lĩnh vực này trước");
                };

            }
        }

        private void dgvLinhVuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaLinhVuc.Text = dgvLinhVuc.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTenLinhVuc.Text = dgvLinhVuc.Rows[e.RowIndex].Cells[1].Value.ToString();
            rtbGhiChu.Text = dgvLinhVuc.Rows[e.RowIndex].Cells[2].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            action = "update";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMaLinhVuc.Enabled = true;
            txtTenLinhVuc.Enabled = true;
            rtbGhiChu.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            action = "update";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaLinhVuc.Text == "" || txtTenLinhVuc.Text == "")
            {
                MessageBox.Show("Mời nhập đầy đủ thông tin");
            }
            else
            {
                linhVucMod.MaLinhVuc = txtMaLinhVuc.Text;
                linhVucMod.TenLinhVuc = CommonService.ValidateString(txtTenLinhVuc.Text);
                linhVucMod.GhiChu = rtbGhiChu.Text;
                if (action == "add")
                {
                    Object obj = linhVucSer.getModel(txtMaLinhVuc.Text);
                    if (obj != null)
                    {
                        MessageBox.Show("Mã bị trùng");
                        return;
                    }
                    else
                    {
                        linhVucSer.createModel(linhVucMod);
                    }
                }
                else
                {
                    linhVucSer.updateModel(linhVucMod);
                }
                MessageBox.Show("Lưu thành công");
                linhVucSer.getAll(dgvLinhVuc);
                clearText();
                txtMaLinhVuc.Enabled = false;
                txtTenLinhVuc.Enabled = false;
                rtbGhiChu.Enabled = false;
                btnThem.Enabled = true;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnLuu.Enabled = false;
            }
        }

        private void txtTuKhoa_TextChanged(object sender, EventArgs e)
        {
            linhVucSer.searchModelBasic(cbLuaChon.Text, txtTuKhoa.Text, dgvLinhVuc);
        }
    }
}
