using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyThuVien.Model
{
    class tblSachModel
    {
        public string MaSach { get; set; }

        public string TacGia { get; set; }

        public string NhaXuatBan { get; set; }

        public string MaLinhVuc { get; set; }

        public string TenSach { get; set; }

        public string NamXuatBan { get; set; }

        public int SoTrang { get; set; }

        public int SoLuong { get; set; }

        public int SoSachHong { get; set; }

        public string NgayNhap { get; set; }

        public string GhiChu { get; set; }

        public tblSachModel() { }

        public tblSachModel(string masach, string tensach, string tacgia, string nxb, string malinhvuc, string namxuatban, string ngaynhap, string ghichu, int sotrang, int soluong, int sosachhong)
        {
            this.MaSach = masach;
            this.TenSach = tensach;
            this.TacGia = tacgia;
            this.NhaXuatBan = nxb;
            this.MaLinhVuc = malinhvuc;
            this.NamXuatBan = namxuatban;
            this.NgayNhap = ngaynhap;
            this.GhiChu = ghichu;
            this.SoTrang = sotrang;
            this.SoLuong = soluong;
            this.SoSachHong = sosachhong;
        }
    }
}
