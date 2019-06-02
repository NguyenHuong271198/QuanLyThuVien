using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLyThuVien.Model;
using System.Data.SqlClient;
using System.Data;

namespace QuanLyThuVien.Service
{
    class DocGiaService
    {
        private ConnectService connectSer = new ConnectService();
        private SqlCommand sqlCom = null;
        public DocGiaService()
        {
            connectSer.Connect();
        }

        public Object getModel(string maDG)
        {
            string sql = "select ID from tblDocGia where MADG='" + maDG + "'";
            return connectSer.getValueModel(maDG);
            //sqlCom = new SqlCommand();
            //sqlCom.CommandType = CommandType.StoredProcedure;
            //sqlCom.CommandText = "USP_GetIdDocGia";
            //sqlCom.Parameters.Add("@MADG", SqlDbType.VarChar).Value = maDG;
            //sqlCom.Connection = connectSer.Connect();
            //Object obj = sqlCom.ExecuteScalar();
            //return obj;
        }

        public void getAll(DataGridView dgv)
        {
            string sql = "Select MADG,HOTEN,NGAYSINH,GIOITINH,LOP,DIACHI,EMAIL,GHICHU from tblDocGia";
            connectSer.LoadDataDataGridView(dgv, sql);
        }

        public void createModel(tblDocGiaModel docGia)
        {
            string sql = "Insert Into tblDocGia(MADG,HOTEN,NGAYSINH,GIOITINH,LOP,DIACHI,EMAIL,GHICHU) values ('" + docGia.MaDocGia + "',N'" + docGia.HoTen + "','" + docGia.NgaySinh + "',N'" + docGia.GioiTinh + "','" + docGia.Lop + "',N'" + docGia.DiaChi + "','" + docGia.Email + "',N'" + docGia.GhiChu + "')";
            connectSer.ThucThiSQLTheoPhiKetNoi(sql);
            //sqlCom = new SqlCommand();
            //sqlCom.CommandType = CommandType.StoredProcedure;
            //sqlCom.CommandText = "USP_InsertDocGia";
            //sqlCom.Parameters.Add("@MADG", SqlDbType.VarChar).Value = docGia.MaDocGia;
            //sqlCom.Parameters.Add("@HOTEN", SqlDbType.NVarChar).Value = docGia.HoTen;
            //sqlCom.Parameters.Add("@NGAYSINH", SqlDbType.VarChar).Value = docGia.NgaySinh;
            //sqlCom.Parameters.Add("@GIOITINH", SqlDbType.NVarChar).Value = docGia.GioiTinh;
            //sqlCom.Parameters.Add("@LOP", SqlDbType.VarChar).Value = docGia.Lop;
            //sqlCom.Parameters.Add("@DIACHI", SqlDbType.NVarChar).Value = docGia.DiaChi;
            //sqlCom.Parameters.Add("@EMAIL", SqlDbType.VarChar).Value = docGia.Email;
            //sqlCom.Parameters.Add("@GHICHU", SqlDbType.NVarChar).Value = docGia.GhiChu;
            //sqlCom.Connection = connectSer.Connect();
            //sqlCom.ExecuteNonQuery();
        }

        public void updateModel(tblDocGiaModel docGia)
        {
            string sql = "Update tblDocGia set HOTEN=N'" + docGia.HoTen + "',NGAYSINH='" + docGia.NgaySinh + "',GIOITINH=N'" + docGia.GioiTinh + "',LOP='" + docGia.Lop + "',DIACHI=N'" + docGia.DiaChi + "',EMAIL='" + docGia.Email + "',GHICHU=N'" + docGia.GhiChu + "' where MADG='" + docGia.MaDocGia + "'";
            connectSer.ThucThiSQLTheoPhiKetNoi(sql);
            //sqlCom = new SqlCommand();
            //sqlCom.CommandType = CommandType.StoredProcedure;
            //sqlCom.CommandText = "USP_UpdateDocGia";
            //sqlCom.Parameters.Add("@MADG", SqlDbType.VarChar).Value = docGia.MaDocGia;
            //sqlCom.Parameters.Add("@HOTEN", SqlDbType.NVarChar).Value = docGia.HoTen;
            //sqlCom.Parameters.Add("@NGAYSINH", SqlDbType.VarChar).Value = docGia.NgaySinh;
            //sqlCom.Parameters.Add("@GIOITINH", SqlDbType.NVarChar).Value = docGia.GioiTinh;
            //sqlCom.Parameters.Add("@LOP", SqlDbType.VarChar).Value = docGia.Lop;
            //sqlCom.Parameters.Add("@DIACHI", SqlDbType.NVarChar).Value = docGia.DiaChi;
            //sqlCom.Parameters.Add("@EMAIL", SqlDbType.VarChar).Value = docGia.Email;
            //sqlCom.Parameters.Add("@GHICHU", SqlDbType.NVarChar).Value = docGia.GhiChu;
            //sqlCom.Connection = connectSer.Connect();
            //sqlCom.ExecuteNonQuery();
        }

        public void deleteModel(string maDocGia)
        {
            string sql = "Delete from tblDocGia where MADG='" + maDocGia + "'";
            connectSer.ThucThiSQLTheoKetNoi(sql);
            //sqlCom = new SqlCommand();
            //sqlCom.CommandType = CommandType.StoredProcedure;
            //sqlCom.CommandText = "USP_DeleteDocGia";
            //sqlCom.Parameters.Add("@MADG", SqlDbType.VarChar).Value = maDocGia;
            //sqlCom.Connection = connectSer.Connect();
            //sqlCom.ExecuteNonQuery();
        }

        public void searchModelBasic(string luaChon, string tuKhoa, DataGridView data)
        {
            string sql = null;

            if (luaChon.Equals("Mã Độc Giả"))
            {
                sql = "select MADG,HOTEN,NGAYSINH,GIOITINH,LOP,DIACHI,EMAIL,GHICHU from tblDocGia where MADG like N'%" + tuKhoa + "%'";
            }
            else if (luaChon.Equals("Họ Tên"))
            {
                sql = "select MADG,HOTEN,NGAYSINH,GIOITINH,LOP,DIACHI,EMAIL,GHICHU from tblDocGia where HOTEN like N'%" + tuKhoa + "%'";
            }
            else if (luaChon.Equals("Giới Tính"))
            {
                sql = "select MADG,HOTEN,NGAYSINH,GIOITINH,LOP,DIACHI,EMAIL,GHICHU from tblDocGia where GIOITINH like N'%" + tuKhoa + "%'";
            }
            else if (luaChon.Equals("Lớp"))
            {
                sql = "select MADG,HOTEN,NGAYSINH,GIOITINH,LOP,DIACHI,EMAIL,GHICHU from tblDocGia where LOP like N'%" + tuKhoa + "%'";
            }
            else if (luaChon.Equals("Địa Chỉ"))
            {
                sql = "select MADG,HOTEN,NGAYSINH,GIOITINH,LOP,DIACHI,EMAIL,GHICHU from tblDocGia where DIACHI like N'%" + tuKhoa + "%'";
            }
            connectSer.LoadDataDataGridView(data, sql);
        }
    }
}
