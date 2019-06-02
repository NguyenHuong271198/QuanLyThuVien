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
    public partial class frmCapNhatThongTinMuon : Form
    {
        public frmCapNhatThongTinMuon()
        {
            InitializeComponent();
        }
        private ConnectService connectSer = new ConnectService();
        private ThongTinMuonService thongTinMuonSer = new ThongTinMuonService();
        private tblThongTinMuonModel muonMod = new tblThongTinMuonModel();
        private string action = "";

        private void capNhatThongTinMuon_Load(object sender, EventArgs e)
        {
            dtpNgayMuon.Format = DateTimePickerFormat.Custom;
            dtpNgayMuon.CustomFormat = "dd-MM-yyyy";
            dtpNgayTra.Format = DateTimePickerFormat.Custom;
            dtpNgayTra.CustomFormat = "dd-MM-yyyy";

            connectSer.Connect();
            connectSer.LoadDataCombobox(cbMaDocGia, "select MADG from tblDocGia");
            connectSer.LoadDataCombobox(cbTenDocGia, "select HOTEN from tblDocGia");
            connectSer.LoadDataListBox(lbMaSach, "select MASACH from tblSach");
            thongTinMuonSer.getAll(dgvThongTinMuon);

            for (int i = 0; i < (dgvThongTinMuon.Rows.Count - 1); i++)
            {
                if (this.dgvThongTinMuon.Rows[i].Cells[0].Value.ToString() != string.Empty)
                {
                    try
                    {
                        string status = this.dgvThongTinMuon.Rows[i].Cells[5].Value.ToString();
                        string deadline = this.dgvThongTinMuon.Rows[i].Cells[4].Value.ToString();
                        DateTime result = DateTime.ParseExact(deadline, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                        DateTime localDate = DateTime.Now;
                        if (result.Date < localDate.Date && status.Equals("Chưa trả"))
                        {
                            thongTinMuonSer.updateDeadline(this.dgvThongTinMuon.Rows[i].Cells[0].Value.ToString());
                        }
                    }
                    catch (Exception Ee)
                    {
                        MessageBox.Show(Ee.ToString());
                    }
                }
            }
        }

        private void clearText()
        {
            cbMaDocGia.SelectedItem = null;
            cbTenDocGia.SelectedItem = null;
            txtSoLuongMuon.Text = "";
            lbMaSach.SelectedItem = null;
            cbXacNhan.SelectedItem = null;
            rtbGhiChu.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            clearText();
            cbMaDocGia.Enabled = true;
            lbMaSach.Enabled = true;
            dtpNgayMuon.Enabled = true;
            dtpNgayTra.Enabled = true;
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
                thongTinMuonSer.deleteModel(cbMaDocGia.Text, lbMaSach.SelectedItem.ToString(), Convert.ToInt32(txtSoLuongMuon.Text));
                MessageBox.Show("Xóa thành công");
                clearText();
                btnSua.Enabled = false;
                btnLuu.Enabled = false;
                thongTinMuonSer.getAll(dgvThongTinMuon);
            }
        }

        private void dgvThongTinMuon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lbMaSach.SelectedItem = null;
            cbMaDocGia.Text = dgvThongTinMuon.Rows[e.RowIndex].Cells[0].Value.ToString();
            lbMaSach.SelectedItem = dgvThongTinMuon.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSoLuongMuon.Text = dgvThongTinMuon.Rows[e.RowIndex].Cells[2].Value.ToString();

            string dateMuon = dgvThongTinMuon.Rows[e.RowIndex].Cells[3].Value.ToString();
            dtpNgayMuon.Value = DateTime.ParseExact(dateMuon, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            string dateTra = dgvThongTinMuon.Rows[e.RowIndex].Cells[4].Value.ToString();
            dtpNgayTra.Value = DateTime.ParseExact(dateTra, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            cbXacNhan.Text = dgvThongTinMuon.Rows[e.RowIndex].Cells[5].Value.ToString();
            rtbGhiChu.Text = dgvThongTinMuon.Rows[e.RowIndex].Cells[6].Value.ToString();
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            action = "update";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            cbXacNhan.Enabled = true;
            rtbGhiChu.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            action = "update";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cbMaDocGia.Text == "")
            {
                MessageBox.Show("Mời nhập đấy đủ thông tin");
            }
            else
            {
                if (lbMaSach.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Mời chọn sách mượn");
                }
                else
                {
                    DateTime ngayMuon = Convert.ToDateTime(this.dtpNgayMuon.Text.Trim(), new CultureInfo("en-GB"));
                    DateTime ngayTra = Convert.ToDateTime(this.dtpNgayTra.Text.Trim(), new CultureInfo("en-GB"));
                    if (ngayMuon >= ngayTra)
                    {
                        MessageBox.Show("Ngày trả sách phải lớn hơn ngày mượn sách");
                        return;
                    }
                    muonMod.MaDocGia = cbMaDocGia.Text;
                    muonMod.GhiChu = rtbGhiChu.Text;
                    muonMod.NgayMuon = dtpNgayMuon.Text;
                    muonMod.NgayTra = dtpNgayTra.Text;
                    if (action == "add")
                    {
                        foreach (object result in lbMaSach.SelectedItems)
                        {
                            Object obj = thongTinMuonSer.getModel(muonMod.MaDocGia, result.ToString());
                            if (obj != null)
                            {
                                MessageBox.Show("Độc giả đã mượn sách này");
                                return;
                            }
                            else
                            {
                                muonMod.MaSach = result.ToString();
                                muonMod.SoLuongMuon = lbMaSach.SelectedItems.Count;
                                muonMod.XacNhanTra = "Chưa trả";
                                thongTinMuonSer.createModel(muonMod);
                            }
                        }
                    }
                    else
                    {
                        muonMod.XacNhanTra = cbXacNhan.Text;
                        muonMod.MaSach = lbMaSach.SelectedItem.ToString();
                        thongTinMuonSer.updateModel(muonMod);
                    }
                    MessageBox.Show("Lưu thành công");
                    clearText();
                    thongTinMuonSer.getAll(dgvThongTinMuon);
                    cbMaDocGia.Enabled = false;
                    lbMaSach.Enabled = false;
                    txtSoLuongMuon.Enabled = false;
                    dtpNgayMuon.Enabled = false;
                    dtpNgayTra.Enabled = false;
                    cbXacNhan.Enabled = false;
                    rtbGhiChu.Enabled = false;
                    btnThem.Enabled = true;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnLuu.Enabled = false;
                }
            }
        }

        private void txtSoPhieuMuon_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbMaDocGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbTenDocGia.SelectedIndex = cbMaDocGia.SelectedIndex;
        }

        private void cbTenDocGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbMaDocGia.SelectedIndex = cbTenDocGia.SelectedIndex;
        }


        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    cls.LoadData2Label(label9, "select count(*)from tblMuon where MASACH='" + comboBox1.Text + "'");
        //}
    }
}
