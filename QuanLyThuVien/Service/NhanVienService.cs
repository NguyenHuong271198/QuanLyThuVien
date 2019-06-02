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
    class NhanVienService
    {
        private ConnectService connectSer = new ConnectService();
        private SqlCommand sqlCom = null;
        public NhanVienService()
        {
            connectSer.Connect();
        }
        public Object logIn(string tenTaiKhoan, string matkhau)
        {
            string sql = "select ID from tblNhanVien where TENTAIKHOAN='" + tenTaiKhoan + "' and MATKHAU='" + matkhau + "'";
            return connectSer.getValueModel(sql);
            
        }

        public Object getModel(string tenTaiKhoan)
        {
            string sql = "select ID from tblNhanVien where TENTAIKHOAN='" + tenTaiKhoan + "'";
            return connectSer.getValueModel(sql);
            //sqlCom = new SqlCommand();
            //sqlCom.CommandType = CommandType.StoredProcedure;
            //sqlCom.CommandText = "USP_GetIdNhanVien";
            //sqlCom.Parameters.Add("@TENTAIKHOAN", SqlDbType.VarChar).Value = tenTaiKhoan;
            //sqlCom.Connection = connectSer.Connect();
            //Object obj = sqlCom.ExecuteScalar();
            //return obj;
        }

        public void createModel(tblNhanVienModel nhanvien)
        {
            string sql = "insert into tblNhanVien(TENTAIKHOAN,MATKHAU)values('" + nhanvien.TaiKhoan + "','" + nhanvien.MatKhau + "')";
            connectSer.ThucThiSQLTheoKetNoi(sql);
            //sqlCom = new SqlCommand();
            //sqlCom.CommandType = CommandType.StoredProcedure;
            //sqlCom.CommandText = "USP_InsertNhanVien";
            //sqlCom.Parameters.Add("@TENTAIKHOAN", SqlDbType.VarChar).Value = nhanvien.TaiKhoan;
            //sqlCom.Parameters.Add("@MATKHAU", SqlDbType.NVarChar).Value = nhanvien.MatKhau;
            //sqlCom.Connection = connectSer.Connect();
            //sqlCom.ExecuteNonQuery();
        }

        public void updateModel(tblNhanVienModel nhanvien, string taiKhoan)
        {
            string sql = "Update tblNhanVien set MATKHAU='" + nhanvien.MatKhau + "'where TENTAIKHOAN='" + taiKhoan + "'";
            connectSer.ThucThiSQLTheoKetNoi(sql);
            //sqlCom = new SqlCommand();
            //sqlCom.CommandType = CommandType.StoredProcedure;
            //sqlCom.CommandText = "USP_UpdateNhanVien";
            //sqlCom.Parameters.Add("@TENTAIKHOAN", SqlDbType.VarChar).Value = taiKhoan;
            //sqlCom.Parameters.Add("@MATKHAU", SqlDbType.VarChar).Value = nhanvien.MatKhau;
            //sqlCom.Connection = connectSer.Connect();
            //sqlCom.ExecuteNonQuery();
        }
    }
}
