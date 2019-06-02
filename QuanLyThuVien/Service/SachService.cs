using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using QuanLyThuVien.Model;
using System.Windows.Forms;

namespace QuanLyThuVien.Service
{
    class SachService
    {
        private ConnectService connectSer = new ConnectService();
        private SqlCommand sqlCom = null;

        public SachService()
        {
            connectSer.Connect();
        }

        public Object getModel(string maSach)
        {
            string sql = "select ID from tblSach where MASACH='" + maSach + "'";
            return connectSer.getValueModel(sql);
            //sqlCom = new SqlCommand();
            //sqlCom.CommandType = CommandType.StoredProcedure;
            //sqlCom.CommandText = "USP_GetIdSach";
            //sqlCom.Parameters.Add("@MASACH", SqlDbType.VarChar).Value = maSach;
            //sqlCom.Connection = connectSer.Connect();
            //Object obj = sqlCom.ExecuteScalar();
            //return obj;
        }

        public Object getSoLuongSach(string maSach)
        {
            string sql = "select SOLUONG from tblSach where MASACH='" + maSach + "'";
            return connectSer.getValueModel(sql);
            //sqlCom = new SqlCommand();
            //sqlCom.CommandType = CommandType.StoredProcedure;
            //sqlCom.CommandText = "USP_GetSoLuongSach";
            //sqlCom.Parameters.Add("@MASACH", SqlDbType.VarChar).Value = maSach;
            //sqlCom.Connection = connectSer.Connect();
            //Object obj = sqlCom.ExecuteScalar();
            //return obj;
        }

        public void getAll(DataGridView dgv)
        {
            string sql = "select MASACH,TENSACH,TACGIA,NHAXUATBAN,MALV,NAMXB,SOTRANG,SOLUONG,SOSACHHONG,NGAYNHAP,GHICHU from tblSach";
            connectSer.LoadDataDataGridView(dgv, sql);
        }

        public void createModel(tblSachModel sach)
        {
            string sql = "Insert Into tblSach(MASACH,TENSACH,TACGIA,NHAXUATBAN,MALV,NAMXB,SOTRANG,SOLUONG,SOSACHHONG,NGAYNHAP,GHICHU) values ('" + sach.MaSach + "',N'" + sach.TenSach + "',N'" + sach.TacGia + "',N'" + sach.NhaXuatBan + "','" + sach.MaLinhVuc + "','" + sach.NamXuatBan + "','" + sach.SoTrang + "','" + sach.SoLuong + "','" + sach.SoSachHong + "','" + sach.NgayNhap + "',N'" + sach.GhiChu + "')";
            connectSer.ThucThiSQLTheoPhiKetNoi(sql);
            //sqlCom = new SqlCommand();
            //sqlCom.CommandType = CommandType.StoredProcedure;
            //sqlCom.CommandText = "USP_InsertSach";
            //sqlCom.Parameters.Add("@MASACH", SqlDbType.VarChar).Value = sach.MaSach;
            //sqlCom.Parameters.Add("@TENSACH", SqlDbType.NVarChar).Value = sach.TenSach;
            //sqlCom.Parameters.Add("@TACGIA", SqlDbType.NVarChar).Value = sach.TacGia;
            //sqlCom.Parameters.Add("@NHAXUATBAN", SqlDbType.NVarChar).Value = sach.NhaXuatBan;
            //sqlCom.Parameters.Add("@MALV", SqlDbType.VarChar).Value = sach.MaLinhVuc;
            //sqlCom.Parameters.Add("@NAMXB", SqlDbType.VarChar).Value = sach.NamXuatBan;
            //sqlCom.Parameters.Add("@SOTRANG", SqlDbType.Int).Value = sach.SoTrang;
            //sqlCom.Parameters.Add("@SOLUONG", SqlDbType.Int).Value = sach.SoLuong;
            //sqlCom.Parameters.Add("@SOSACHHONG", SqlDbType.Int).Value = sach.SoSachHong;
            //sqlCom.Parameters.Add("@NGAYNHAP", SqlDbType.VarChar).Value = sach.NgayNhap;
            //sqlCom.Parameters.Add("@GHICHU", SqlDbType.NVarChar).Value = sach.GhiChu;
            //sqlCom.Connection = connectSer.Connect();
            //sqlCom.ExecuteNonQuery();
        }

        public void updateModel(tblSachModel sach)
        {
            string sql = "Update tblSach set TENSACH=N'" + sach.TenSach + "',TACGIA=N'" + sach.TacGia + "',NHAXUATBAN=N'" + sach.NhaXuatBan + "',MALV='" + sach.MaLinhVuc + "',NAMXB='" + sach.NamXuatBan + "',SOTRANG='" + sach.SoTrang + "',SOLUONG='" + sach.SoLuong + "',SOSACHHONG='" + sach.SoSachHong + "',NGAYNHAP='" + sach.NgayNhap + "',GHICHU=N'" + sach.GhiChu + "' where MASACH='" + sach.MaSach + "'";
            connectSer.ThucThiSQLTheoPhiKetNoi(sql);
            //sqlCom = new SqlCommand();
            //sqlCom.CommandType = CommandType.StoredProcedure;
            //sqlCom.CommandText = "USP_UpdateSach";
            //sqlCom.Parameters.Add("@MASACH", SqlDbType.VarChar).Value = sach.MaSach;
            //sqlCom.Parameters.Add("@TENSACH", SqlDbType.NVarChar).Value = sach.TenSach;
            //sqlCom.Parameters.Add("@TACGIA", SqlDbType.NVarChar).Value = sach.TacGia;
            //sqlCom.Parameters.Add("@NHAXUATBAN", SqlDbType.NVarChar).Value = sach.NhaXuatBan;
            //sqlCom.Parameters.Add("@MALV", SqlDbType.VarChar).Value = sach.MaLinhVuc;
            //sqlCom.Parameters.Add("@NAMXB", SqlDbType.VarChar).Value = sach.NamXuatBan;
            //sqlCom.Parameters.Add("@SOTRANG", SqlDbType.Int).Value = sach.SoTrang;
            //sqlCom.Parameters.Add("@SOLUONG", SqlDbType.Int).Value = sach.SoLuong;
            //sqlCom.Parameters.Add("@SOSACHHONG", SqlDbType.Int).Value = sach.SoSachHong;
            //sqlCom.Parameters.Add("@NGAYNHAP", SqlDbType.VarChar).Value = sach.NgayNhap;
            //sqlCom.Parameters.Add("@GHICHU", SqlDbType.NVarChar).Value = sach.GhiChu;
            //sqlCom.Connection = connectSer.Connect();
            //sqlCom.ExecuteNonQuery();
        }

        public void updateModelByCondition(string maSach, Boolean xacNhan)
        {
            int soluong = Convert.ToInt16(getSoLuongSach(maSach));
            string sql = "";
            if (xacNhan)
            {
                //sqlCom = new SqlCommand();
                //sqlCom.CommandType = CommandType.StoredProcedure;
                sql = "Update tblSach set SOLUONG='" + (soluong + 1) + "' where MASACH='" + maSach + "'";
                //sqlCom.CommandText = "USP_UpdateSoLuongSachTang";
                //sqlCom.Parameters.Add("@MASACH", SqlDbType.VarChar).Value = maSach;
                //sqlCom.Parameters.Add("@SoLuong", SqlDbType.Int).Value = soluong;
                //sqlCom.Connection = connectSer.Connect();
                //sqlCom.ExecuteNonQuery();
            }
            else
            {
                //sqlCom = new SqlCommand();
                //sqlCom.CommandType = CommandType.StoredProcedure;
                sql = "Update tblSach set SOLUONG='" + (soluong - 1) + "' where MASACH='" + maSach + "'";
                //sqlCom.CommandText = "USP_UpdateSoLuongSachGiam";
                //sqlCom.Parameters.Add("@MASACH", SqlDbType.VarChar).Value = maSach;
                //sqlCom.Parameters.Add("@SoLuong", SqlDbType.Int).Value = soluong;
                //sqlCom.Connection = connectSer.Connect();
                //sqlCom.ExecuteNonQuery();
            }
            connectSer.ThucThiSQLTheoPhiKetNoi(sql);
        }

        public void deleteModel(string maSach)
        {
            string sql = "Delete from tblSach where MASACH='" + maSach + "'";
            connectSer.ThucThiSQLTheoKetNoi(sql);
            //sqlCom = new SqlCommand();
            //sqlCom.CommandType = CommandType.StoredProcedure;
            //sqlCom.CommandText = "USP_DeleteSach";
            //sqlCom.Parameters.Add("@MASACH", SqlDbType.VarChar).Value = maSach;
            //sqlCom.Connection = connectSer.Connect();
            //sqlCom.ExecuteNonQuery();
        }

        public void searchModelBasic(string luaChon, string tuKhoa, DataGridView data)
        {
            string sql = null;

            if (luaChon.Equals("Mã Sách"))
            {
                sql = "select MASACH,TENSACH,TACGIA,NHAXUATBAN,MALV,NAMXB,SOTRANG,SOLUONG,SOSACHHONG,NGAYNHAP,GHICHU from tblSach where MASACH like N'%" + tuKhoa + "%'";
            }
            else if (luaChon.Equals("Tên Sách"))
            {
                sql = "select MASACH,TENSACH,TACGIA,NHAXUATBAN,MALV,NAMXB,SOTRANG,SOLUONG,SOSACHHONG,NGAYNHAP,GHICHU from tblSach where TENSACH like N'%" + tuKhoa + "%'";
            }
            else if (luaChon.Equals("Tác Giả"))
            {
                sql = "select MASACH,TENSACH,TACGIA,NHAXUATBAN,MALV,NAMXB,SOTRANG,SOLUONG,SOSACHHONG,NGAYNHAP,GHICHU from tblSach where TACGIA like N'%" + tuKhoa + "%'";
            }
            else if (luaChon.Equals("Mã Lĩnh Vực"))
            {
                sql = "select MASACH,TENSACH,TACGIA,NHAXUATBAN,MALV,NAMXB,SOTRANG,SOLUONG,SOSACHHONG,NGAYNHAP,GHICHU from tblSach where MALV like N'%" + tuKhoa + "%'";
            }
            else if (luaChon.Equals("Năm Xuất bản"))
            {
                sql = "select MASACH,TENSACH,TACGIA,NHAXUATBAN,MALV,NAMXB,SOTRANG,SOLUONG,SOSACHHONG,NGAYNHAP,GHICHU from tblSach where NAMXB like N'%" + tuKhoa + "%'";
            }
            connectSer.LoadDataDataGridView(data, sql);
        }
    }
}
