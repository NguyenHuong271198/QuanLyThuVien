using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuanLyThuVien.Service;

namespace QuanLyThuVien
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private ConnectService connectSer = new ConnectService();
        private NhanVienService nhanVienSer = new NhanVienService();
        private string A, B, C, D;
        public static string tenTaiKhoan, matKhauCu;

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                connectSer.Connect();
            }
            catch
            {
                MessageBox.Show("Không thể kết nối");
            }
            A = label1.Text;
            B = label2.Text;
            C = label3.Text;
            D = label4.Text;
            label4.Text = "";
            label3.Text = "";
            label2.Text = "";
            label1.Text = "";
            timer1.Start();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtTenTaiKhoan.Text == "" || txtMatKhau.Text == "")
            {
                MessageBox.Show("Xin hãy nhập đầy đủ thông tin");
            }
            else
            {
                object obj = nhanVienSer.logIn(txtTenTaiKhoan.Text, txtMatKhau.Text);
                if (obj == null)
                {
                    MessageBox.Show("Sai tài khoản");
                }
                else
                {
                    MessageBox.Show("Đăng nhập thành công");
                    tenTaiKhoan = txtTenTaiKhoan.Text;
                    matKhauCu = txtMatKhau.Text;
                    DoiMatKhauTSMI.Enabled = true;
                    CapNhatTSMI.Enabled = true;
                    TimKiemTSMI.Enabled = true;
                    txtTenTaiKhoan.Text = "";
                    txtMatKhau.Text = "";
                    gbDangNhap.Enabled = false;
                    TroGiupTSMI.Enabled = true;
                    QuanLyHeThongTSMI.Enabled = true;
                }
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát khỏi chương trình không ?", "FormClosing", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        private void ThoatTSMI_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TaoTaiKhoanTSMI_Click(object sender, EventArgs e)
        {
            frmTaoTaiKhoan frmTTK = new frmTaoTaiKhoan();
            frmTTK.Show();
        }

        private void DoiMatKhauTSMI_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frmDMK = new frmDoiMatKhau();
            frmDMK.Show();
        }

        private void DangNhapTSMI_Click(object sender, EventArgs e)
        {
            gbDangNhap.Enabled = true;
            CapNhatTSMI.Enabled = false;
            TimKiemTSMI.Enabled = false;
            TroGiupTSMI.Enabled = false;
            QuanLyHeThongTSMI.Enabled = false;
            txtTenTaiKhoan.Text = "";
            txtMatKhau.Text = "";
        }

        private void CapNhatSachTSMI_Click(object sender, EventArgs e)
        {
            frmCapNhatSach frmCNS = new frmCapNhatSach();
            frmCNS.Show();
        }

        private void CapNhatDocGiaTSMI_Click(object sender, EventArgs e)
        {
            frmCapnhatDocGia frmCNDG = new frmCapnhatDocGia();
            frmCNDG.Show();

        }

        private void CapNhatLinhVucTSMI_Click(object sender, EventArgs e)
        {
            frmCapNhatLinhVuc frmCNLV = new frmCapNhatLinhVuc();
            frmCNLV.Show();
        }

        private void CapNhatThongTinMuonTSMI_Click(object sender, EventArgs e)
        {
            frmCapNhatThongTinMuon frmCNTTM = new frmCapNhatThongTinMuon();
            frmCNTTM.Show();
        }


        private void TroGiupTSMI_Click(object sender, EventArgs e)
        {
            frmHelp frmH = new frmHelp();
            frmH.Show();
        }

        private void TimKiemTTMuonTSMI_Click(object sender, EventArgs e)
        {
            frmPhieuMuonQuaHan frmTKTTM = new frmPhieuMuonQuaHan();
            frmTKTTM.Show();
        }

        private void TimKiemTSMI_Click(object sender, EventArgs e)
        {
            frmPhieuMuonQuaHan frmPMQH = new frmPhieuMuonQuaHan();
            frmPMQH.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int d = 0, x;
            x = A.Length;
            d++;
            string a = A.Substring(0, 1);
            A = A.Substring(1, A.Length - 1);
            label1.Text = label1.Text + a;
            if (d == x)
            {
                timer1.Stop();
                timer2.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int d = 0, x;
            x = B.Length;
            d++;
            string a = B.Substring(0, 1);
            B = B.Substring(1, B.Length - 1);
            label2.Text = label2.Text + a;
            if (d == x)
            {
                timer2.Stop();
                timer3.Start();
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            int d = 0, x;
            x = C.Length;
            d++;
            string a = C.Substring(0, 1);
            C = C.Substring(1, C.Length - 1);
            label3.Text = label3.Text + a;
            if (d == x)
            {
                timer3.Stop();
                timer4.Start();
                timer5.Start();
                timer6.Start();
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            int d = 0, x;
            x = D.Length;
            d++;
            string a = D.Substring(0, 1);
            D = D.Substring(1, D.Length - 1);
            label4.Text = label4.Text + a;
            if (d == x)
            {
                timer4.Stop();
            }
        }
    }
}
