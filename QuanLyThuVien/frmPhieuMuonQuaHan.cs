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
    public partial class frmPhieuMuonQuaHan : Form
    {
        private ConnectService connectSer = new ConnectService();
        public frmPhieuMuonQuaHan()
        {
            InitializeComponent();
            connectSer.Connect();
        }

        private ThongTinMuonService thongTinMuonSer = new ThongTinMuonService();

        private void frmTimKiemThongTinMuon_Load(object sender, EventArgs e)
        {
            thongTinMuonSer.getListDeadline(dgvPhieuMuonQuaHan);
        }
    }
}
