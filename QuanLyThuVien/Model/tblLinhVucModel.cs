using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyThuVien.Model
{
    class tblLinhVucModel
    {
        public string MaLinhVuc { get; set; }

        public string TenLinhVuc { get; set; }

        public string GhiChu { get; set; }

        public tblLinhVucModel() { }

        public tblLinhVucModel(string malv, string tenlv, string ghichu)
        {
            this.MaLinhVuc = malv;
            this.TenLinhVuc = tenlv;
            this.GhiChu = ghichu;
        }
    }
}
