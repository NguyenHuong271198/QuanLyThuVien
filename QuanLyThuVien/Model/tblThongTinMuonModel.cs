using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyThuVien.Model
{
    class tblThongTinMuonModel
    {
        public string MaDocGia { get; set; }

        public string MaSach { get; set; }

        public int SoLuongMuon { get; set; }

        public string NgayMuon { get; set; }

        public string NgayTra { get; set; }

        public string TaiKhoan { get; set; }

        public string XacNhanTra { get; set; }

        public string GhiChu { get; set; }

        public tblThongTinMuonModel() { }

        public tblThongTinMuonModel(string madg, string mas, int soluongmuon, string ngaymuon, string ngaytra, string xacnhan, string ghichu)
        {
            this.MaDocGia = madg;
            this.MaSach = mas;
            this.SoLuongMuon = soluongmuon;
            this.NgayMuon = ngaymuon;
            this.NgayTra = ngaytra;
            this.XacNhanTra = xacnhan;
            this.GhiChu = ghichu;
        }
    }
}
