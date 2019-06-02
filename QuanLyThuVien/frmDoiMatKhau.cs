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
    public partial class frmDoiMatKhau : Form
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        NhanVienService nhanvienSer = new NhanVienService();
        tblNhanVienModel nhanvienMod = new tblNhanVienModel();

        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (txtMatKhauCu.Text == "" || txtMatKhauMoi.Text == "" || txtXacNhan.Text == "")
            {
                MessageBox.Show("Xin hãy nhập đầy đủ thông tin");
            }
            else
            {
                if (txtMatKhauMoi.Text.Length < 5)
                {
                    MessageBox.Show("Mật khẩu mới quá ngắn");
                }
                else
                {
                    if (txtMatKhauMoi.Text.Length > 30)
                    {
                        MessageBox.Show("Mật khẩu mới quá dài");
                    }
                    else
                    {
                        if (txtMatKhauMoi.Text != txtXacNhan.Text)
                        {
                            MessageBox.Show("Mật khẩu mới không trùng khớp hãy nhập lại");
                        }
                        else
                        {
                            if (txtMatKhauCu.Text != frmMain.matKhauCu)
                            {
                                MessageBox.Show("Mật khẩu cũ sai hãy nhập lại");
                            }
                            else
                            {
                                nhanvienMod.MatKhau = txtMatKhauMoi.Text;
                                try
                                {
                                    nhanvienSer.updateModel(nhanvienMod, frmMain.tenTaiKhoan);
                                    MessageBox.Show("Đổi mật khẩu thành công");
                                }
                                catch (Exception E)
                                {
                                    MessageBox.Show("" + E.ToString());
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPassword.Checked)
            {
                txtMatKhauCu.PasswordChar = '\0';
                txtMatKhauMoi.PasswordChar = '\0';
                txtXacNhan.PasswordChar = '\0';
            }
            else
            {
                txtMatKhauCu.PasswordChar = '*';
                txtMatKhauMoi.PasswordChar = '*';
                txtXacNhan.PasswordChar = '*';
            }
        }

    }
}
