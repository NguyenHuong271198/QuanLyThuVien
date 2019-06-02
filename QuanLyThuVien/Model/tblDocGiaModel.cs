using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyThuVien.Model
{
    class tblDocGiaModel
    {
        public string MaDocGia { get; set; }

        public string HoTen { get; set; }

        public string NgaySinh { get; set; }

        public string GioiTinh { get; set; }

        public string Lop { get; set; }

        public string DiaChi { get; set; }

        public string Email { get; set; }

        public string GhiChu { get; set; }

        public tblDocGiaModel() { }

        public tblDocGiaModel(string ma, string ten, string ngaysinh, string gioitinh, string lop, string diachi, string email, string ghichu)
        {
            this.MaDocGia = ma;
            this.HoTen = ten;
            this.NgaySinh = ngaysinh;
            this.GioiTinh = gioitinh;
            this.Lop = lop;
            this.DiaChi = diachi;
            this.Email = email;
            this.GhiChu = ghichu;
        }
    }
}