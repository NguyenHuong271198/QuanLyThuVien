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
    class LinhVucService
    {
        private ConnectService connectSer = new ConnectService();
        private SqlCommand sqlCom = null;
        public LinhVucService()
        {
            connectSer.Connect();
        }

        public Object getModel(string maLV)
        {
            string sql = "select ID from tblLinhVuc where MALV='" + maLV + "'";
            return connectSer.getValueModel(sql);
            //sqlCom = new SqlCommand();
            //sqlCom.CommandType = CommandType.StoredProcedure;
            //sqlCom.CommandText = "USP_GetIdLinhVuc";
            //sqlCom.Parameters.Add("@MALV", SqlDbType.VarChar).Value = maLV;
            //sqlCom.Connection = connectSer.Connect();
            //Object obj = sqlCom.ExecuteScalar();
            //return obj;
        }

        public void getAll(DataGridView dgv)
        {
            string sql = "select MALV,TENLV,GHICHU from tblLinhVuc";
            connectSer.LoadDataDataGridView(dgv, sql);
        }

        public void createModel(tblLinhVucModel linhVuc)
        {
            string sql = "Insert Into tblLinhVuc(MALV,TENLV,GHICHU) values ('" + linhVuc.MaLinhVuc + "',N'" + linhVuc.TenLinhVuc + "',N'" + linhVuc.GhiChu + "')";
            connectSer.ThucThiSQLTheoPhiKetNoi(sql);
            //sqlCom = new SqlCommand();
            //sqlCom.CommandType = CommandType.StoredProcedure;
            //sqlCom.CommandText = "USP_InsertLinhVuc";
            //sqlCom.Parameters.Add("@MALV", SqlDbType.VarChar).Value = linhVuc.MaLinhVuc;
            //sqlCom.Parameters.Add("@TENLV", SqlDbType.NVarChar).Value = linhVuc.TenLinhVuc;
            //sqlCom.Parameters.Add("@GHICHU", SqlDbType.NVarChar).Value = linhVuc.GhiChu;
            //sqlCom.Connection = connectSer.Connect();
            //sqlCom.ExecuteNonQuery();
        }

        public void updateModel(tblLinhVucModel linhVuc)
        {
            string sql = "Update tblLinhVuc set TENLV=N'" + linhVuc.TenLinhVuc + "',GHICHU=N'" + linhVuc.GhiChu + "' where MALV='" + linhVuc.MaLinhVuc + "'";
            connectSer.ThucThiSQLTheoPhiKetNoi(sql);
            //sqlCom = new SqlCommand();
            //sqlCom.CommandType = CommandType.StoredProcedure;
            //sqlCom.CommandText = "USP_UpdateLinhVuc";
            //sqlCom.Parameters.Add("@MALV", SqlDbType.VarChar).Value = linhVuc.MaLinhVuc;
            //sqlCom.Parameters.Add("@TENLV", SqlDbType.NVarChar).Value = linhVuc.TenLinhVuc;
            //sqlCom.Parameters.Add("@GHICHU", SqlDbType.NVarChar).Value = linhVuc.GhiChu;
            //sqlCom.Connection = connectSer.Connect();
            //sqlCom.ExecuteNonQuery();
        }

        public void deleteModel(string maLinhVuc)
        {
            string sql = "Delete from tblLinhVuc where MaLV='" + maLinhVuc + "'";
            connectSer.ThucThiSQLTheoKetNoi(sql);
            //sqlCom = new SqlCommand();
            //sqlCom.CommandType = CommandType.StoredProcedure;
            //sqlCom.CommandText = "USP_DeleteLinhVuc";
            //sqlCom.Parameters.Add("@MALV", SqlDbType.VarChar).Value = maLinhVuc;
            //sqlCom.Connection = connectSer.Connect();
            //sqlCom.ExecuteNonQuery();
        }

        public void searchModelBasic(string luaChon, string tuKhoa, DataGridView data)
        {
            string sql = null;

            if (luaChon.Equals("Mã Lĩnh Vực"))
            {
                sql = "select MALV,TENLV,GHICHU from tblLinhVuc where MALV like N'%" + tuKhoa + "%'";
            }
            else if (luaChon.Equals("Tên Lĩnh Vực"))
            {
                sql = "select MALV,TENLV,GHICHU from tblLinhVuc where TENLV like N'%" + tuKhoa + "%'";
            }
            connectSer.LoadDataDataGridView(data, sql);
        }
    }
}
