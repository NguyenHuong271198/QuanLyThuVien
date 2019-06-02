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
using System.Globalization;

namespace QuanLyThuVien
{
    public partial class frmCapnhatDocGia : Form
    {
        public frmCapnhatDocGia()
        {
            InitializeComponent();
        }

        private ConnectService connectSer = new ConnectService();
        private DocGiaService docGiaSer = new DocGiaService();
        private tblDocGiaModel docGiaMod = new tblDocGiaModel();
        private string action = "";

        private void capNhatDocGia_Load(object sender, EventArgs e)
        {
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.CustomFormat = "dd-MM-yyyy";

            connectSer.Connect();
            docGiaSer.getAll(dgvDocGia);
        }

        private void clearText()
        {
            txtMaDocGia.Text = "";
            txtHoTen.Text = "";
            cbGioiTinh.Text = "";
            txtLop.Text = "";
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            rtbGhiChu.Text = "";
            cbGioiTinh.SelectedItem = null;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            clearText();
            txtMaDocGia.Enabled = true;
            txtHoTen.Enabled = true;
            dtpNgaySinh.Enabled = true;
            cbGioiTinh.Enabled = true;
            txtLop.Enabled = true;
            txtDiaChi.Enabled = true;
            txtEmail.Enabled = true;
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
                    docGiaSer.deleteModel(txtMaDocGia.Text);
                    MessageBox.Show("Xóa thành công");
                    clearText();
                    btnSua.Enabled = false;
                    btnLuu.Enabled = false;
                    docGiaSer.getAll(dgvDocGia);
                }
                catch
                {
                    MessageBox.Show("Phải xóa những thông tin liên quan đến độc giả này trước");
                };
            }
        }

        private void dgvDocGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaDocGia.Text = dgvDocGia.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtHoTen.Text = dgvDocGia.Rows[e.RowIndex].Cells[1].Value.ToString();
            string date = dgvDocGia.Rows[e.RowIndex].Cells[2].Value.ToString();
            dtpNgaySinh.Value = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            cbGioiTinh.Text = dgvDocGia.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtLop.Text = dgvDocGia.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtDiaChi.Text = dgvDocGia.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtEmail.Text = dgvDocGia.Rows[e.RowIndex].Cells[6].Value.ToString();
            rtbGhiChu.Text = dgvDocGia.Rows[e.RowIndex].Cells[7].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            action = "update";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMaDocGia.Enabled = true;
            txtHoTen.Enabled = true;
            dtpNgaySinh.Enabled = true;
            cbGioiTinh.Enabled = true;
            txtLop.Enabled = true;
            txtDiaChi.Enabled = true;
            txtEmail.Enabled = true;
            rtbGhiChu.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            action = "update";
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaDocGia.Text == "" || txtHoTen.Text == "" || cbGioiTinh.Text == "" || txtLop.Text == "" || txtDiaChi.Text == "" || txtEmail.Text == "")
            {
                MessageBox.Show("Mời nhập đầy đủ thông tin");
            }
            else
            {
                docGiaMod.MaDocGia = txtMaDocGia.Text;
                docGiaMod.HoTen = CommonService.ValidateString(txtHoTen.Text);
                docGiaMod.NgaySinh = dtpNgaySinh.Text;
                docGiaMod.GioiTinh = cbGioiTinh.Text;
                docGiaMod.Lop = txtLop.Text;
                docGiaMod.DiaChi = CommonService.ValidateString(txtDiaChi.Text);
                if (IsValidEmail(txtEmail.Text))
                {
                    docGiaMod.Email = txtEmail.Text;
                    docGiaMod.GhiChu = rtbGhiChu.Text;
                    if (action == "add")
                    {
                        Object obj = docGiaSer.getModel(txtMaDocGia.Text);
                        if (obj != null)
                        {
                            MessageBox.Show("Mã bị trùng");
                            return;
                        }
                        else
                        {
                            docGiaSer.createModel(docGiaMod);
                        }
                    }
                    else
                    {
                        docGiaSer.updateModel(docGiaMod);
                    }
                    MessageBox.Show("Lưu thành công");
                    clearText();
                    docGiaSer.getAll(dgvDocGia);
                    txtMaDocGia.Enabled = false;
                    txtHoTen.Enabled = false;
                    dtpNgaySinh.Enabled = false;
                    cbGioiTinh.Enabled = false;
                    txtLop.Enabled = false;
                    txtDiaChi.Enabled = false;
                    txtEmail.Enabled = false;
                    rtbGhiChu.Enabled = false;
                    btnThem.Enabled = true;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnLuu.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Email không đúng định dạng");
                }
            }
        }

        private void txtTuKhoa_TextChanged(object sender, EventArgs e)
        {
            docGiaSer.searchModelBasic(cbLuaChon.Text, txtTuKhoa.Text, dgvDocGia);
        }

        private void btn_trove_Click(object sender, EventArgs e)
        {
            clearText();
            docGiaSer.getAll(dgvDocGia);
            txtMaDocGia.Enabled = false;
            txtHoTen.Enabled = false;
            txtLop.Enabled = false;
            txtDiaChi.Enabled = false;
            txtEmail.Enabled = false;
          //  txtTacGia.Enabled = false;
           // txtNhaXuatBan.Enabled = false;
            /*dtpNgayMuon.Enabled = false;
            dtpNgayTra.Enabled = false;
            cbXacNhan.Enabled = false;
            rtbGhiChu.Enabled = false;*/
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
        }
    }
}
