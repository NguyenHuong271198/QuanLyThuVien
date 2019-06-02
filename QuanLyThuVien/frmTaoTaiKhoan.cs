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
    public partial class frmTaoTaiKhoan : Form
    {
        public frmTaoTaiKhoan()
        {
            InitializeComponent();
        }

        NhanVienService nhanvienSer = new NhanVienService();
        tblNhanVienModel nhanvienMod = new tblNhanVienModel();

        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text == "" || txtMatKhau.Text == "" || txtXacNhan.Text == "")
            {
                MessageBox.Show("Xin hãy nhập đầy đủ thông tin");
            }
            else
            {
                if (txtTaiKhoan.Text.Length < 3)
                {
                    MessageBox.Show("Tên tài khoản quá ngắn");
                }
                else
                {
                    if (txtTaiKhoan.Text.Length > 20)
                    {
                        MessageBox.Show("Tên tài khoản quá dài");
                    }
                    else
                    {
                        object obj = nhanvienSer.getModel(txtTaiKhoan.Text);
                        if (obj != null)
                        {
                            MessageBox.Show("Tên tài khoản đã tồn tại");
                        }
                        else
                        {
                            if (txtMatKhau.Text.Length < 5)
                            {
                                MessageBox.Show("Mật khẩu quá ngắn");
                            }
                            else
                            {
                                if (txtMatKhau.Text != txtXacNhan.Text)
                                {
                                    MessageBox.Show("Mật khẩu không trùng nhau");
                                }
                                else
                                {
                                    try
                                    {
                                        nhanvienMod.TaiKhoan = txtTaiKhoan.Text;
                                        nhanvienMod.MatKhau = txtMatKhau.Text;
                                        nhanvienSer.createModel(nhanvienMod);
                                        MessageBox.Show("Tạo tài khoản thành công");
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
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPassword.Checked)
            {
                txtMatKhau.PasswordChar = '\0';
                txtXacNhan.PasswordChar = '\0';
            }
            else
            {
                txtMatKhau.PasswordChar = '*';
                txtXacNhan.PasswordChar = '*';
            }
        }
    }
}
