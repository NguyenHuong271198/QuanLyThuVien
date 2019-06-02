using QuanLyThuVien.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyThuVien.Service
{
    class ThongTinMuonService
    {
        private ConnectService connectSer = new ConnectService();
        private SachService sachSer = new SachService();
        private SqlCommand sqlCom = null;

        public ThongTinMuonService()
        {
            connectSer.Connect();
        }

        public Object getModel(string maDG, string maSach)
        {
            string sql = "select * from tblThongTinMuon where MADG='" + maDG + "' and MASACH='" + maSach + "'";
            return connectSer.getValueModel(sql);
            //sqlCom = new SqlCommand();
            //sqlCom.CommandType = CommandType.StoredProcedure;
            //sqlCom.CommandText = "USP_GetIdThongTinMuonTra";
            //sqlCom.Parameters.Add("@MADG", SqlDbType.VarChar).Value = maDG;
            //sqlCom.Parameters.Add("@MASACH", SqlDbType.VarChar).Value = maSach;
            //sqlCom.Connection = connectSer.Connect();
            //Object obj = sqlCom.ExecuteScalar();
            //return obj;
        }


        public void getAll(DataGridView dgv)
        {
            string sql = "select MADG,MASACH,SOLUONGMUON,NGAYMUON,NGAYTRA,XACNHANTRA,GHICHU from tblThongTinMuon";
            connectSer.LoadDataDataGridView(dgv, sql);
        }

        public void getListDeadline(DataGridView dgv)
        {
            string sql = "select MADG,MASACH,SOLUONGMUON,NGAYMUON,NGAYTRA,XACNHANTRA,GHICHU from tblThongTinMuon where DEADLINE = 1 AND XACNHANTRA = N'Chưa trả'";
            connectSer.LoadDataDataGridView(dgv, sql);
        }

        public void createModel(tblThongTinMuonModel muon)
        {
            string sql = "Insert Into tblThongTinMuon(MADG,MASACH,SOLUONGMUON,NGAYMUON,NGAYTRA,XACNHANTRA,GHICHU) values ('" + muon.MaDocGia + "','" + muon.MaSach + "','" + muon.SoLuongMuon + "','" + muon.NgayMuon + "','" + muon.NgayTra + "', N'Chưa trả'" + ", N'" + muon.GhiChu + "')";
            connectSer.ThucThiSQLTheoPhiKetNoi(sql);
            //sqlCom = new SqlCommand();
            //sqlCom.CommandType = CommandType.StoredProcedure;
            //sqlCom.CommandText = "USP_InsertThongTinMuonTra";
            //sqlCom.Parameters.Add("@MADG", SqlDbType.VarChar).Value = muon.MaDocGia;
            //sqlCom.Parameters.Add("@MASACH", SqlDbType.VarChar).Value = muon.MaSach;
            //sqlCom.Parameters.Add("@SOLUONGMUON", SqlDbType.Int).Value = muon.SoLuongMuon;
            //sqlCom.Parameters.Add("@NGAYMUON", SqlDbType.VarChar).Value = muon.NgayMuon;
            //sqlCom.Parameters.Add("@NGAYTRA", SqlDbType.VarChar).Value = muon.NgayTra;
            //sqlCom.Parameters.Add("@XACNHANTRA", SqlDbType.NVarChar).Value = muon.XacNhanTra;
            //sqlCom.Parameters.Add("@GHICHU", SqlDbType.NVarChar).Value = muon.GhiChu;
            //sqlCom.Connection = connectSer.Connect();
            //sqlCom.ExecuteNonQuery();
            //sachSer.updateModelByCondition(muon.MaSach, false);
        }

        public void updateModel(tblThongTinMuonModel muon)
        {
            string sql = "Update tblThongTinMuon set XACNHANTRA=N'" + muon.XacNhanTra + "',GHICHU=N'" + muon.GhiChu + "' where MADG='" + muon.MaDocGia + "' AND MASACH='" + muon.MaSach + "'";
            connectSer.ThucThiSQLTheoPhiKetNoi(sql);
            //sqlCom = new SqlCommand();
            //sqlCom.CommandType = CommandType.StoredProcedure;
            //sqlCom.CommandText = "USP_UpdateThongTinMuonTra";
            //sqlCom.Parameters.Add("@MADG", SqlDbType.VarChar).Value = muon.MaDocGia;
            //sqlCom.Parameters.Add("@XACNHANTRA", SqlDbType.NVarChar).Value = muon.XacNhanTra;
            //sqlCom.Parameters.Add("@GHICHU", SqlDbType.NVarChar).Value = muon.GhiChu;
            //sqlCom.Connection = connectSer.Connect();
            //sqlCom.ExecuteNonQuery();
            //if (muon.XacNhanTra.Equals("Đã trả"))
            //{
            //    sachSer.updateModelByCondition(muon.MaSach, true);
            //}
        }

        public void updateDeadline(string maDG)
        {
            string sql = "Update tblThongTinMuon set DEADLINE=1 where MADG='" + maDG + "'";
            connectSer.ThucThiSQLTheoPhiKetNoi(sql);
        }

        public void deleteModel(string maDG, string maSach, int soluongmuon)
        {
            string sqlDe = "Delete from tblThongTinMuon where MASACH='" + maSach + "' and MADG='" + maDG + "'";
            connectSer.ThucThiSQLTheoKetNoi(sqlDe);
            string sqlUp = "Update tblThongTinMuon set SOLUONGMUON='" + (Convert.ToInt32(soluongmuon)-1) + "' where MADG='" + maDG + "'";
            connectSer.ThucThiSQLTheoPhiKetNoi(sqlUp);
            //sqlCom = new SqlCommand();
            //sqlCom.CommandType = CommandType.StoredProcedure;
            //sqlCom.CommandText = "USP_DeleteThongTinMuonTra";
            //sqlCom.Parameters.Add("@MADG", SqlDbType.VarChar).Value = maDG;
            //sqlCom.Parameters.Add("@MASACH", SqlDbType.VarChar).Value = maSach;
            //sqlCom.Parameters.Add("@SOLUONGMUON", SqlDbType.Int).Value = soluongmuon;
            //sqlCom.Connection = connectSer.Connect();
            //sqlCom.ExecuteNonQuery();
            //sachSer.updateModelByCondition(maSach, true);
        }

        public void searchModelBasic(string luaChon, string tuKhoa, DataGridView data)
        {
            string sql = null;

            if (luaChon.Equals("Mã Độc Giả"))
            {
                sql = "select MADG,MASACH,SOLUONGMUON,NGAYMUON,NGAYTRA,GHICHU from tblThongTinMuon where MADG like N'%" + tuKhoa + "%'";
            }
            else if (luaChon.Equals("Ngày Mượn"))
            {
                sql = "select MADG,MASACH,SOLUONGMUON,NGAYMUON,NGAYTRA,GHICHU from tblThongTinMuon where NGAYMUON like N'%" + tuKhoa + "%'";
            }
            else if (luaChon.Equals("Ngày Trả"))
            {
                sql = "select MADG,MASACH,SOLUONGMUON,NGAYMUON,NGAYTRA,GHICHU from tblThongTinMuon where NGAYTRA like N'%" + tuKhoa + "%'";
            }
            connectSer.LoadDataDataGridView(data, sql);
        }
    }
}
