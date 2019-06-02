using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyThuVien.Model
{
    class tblNhanVienModel
    {
        public string TaiKhoan { get; set; }

        public string MatKhau { get; set; }

        public tblNhanVienModel() { }

        public tblNhanVienModel(string taikhoan, string matkhau)
        {
            this.TaiKhoan = taikhoan;
            this.MatKhau = matkhau;
        }
    }
}
