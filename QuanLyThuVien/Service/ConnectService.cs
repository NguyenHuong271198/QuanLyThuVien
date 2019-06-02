using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyThuVien.Service
{
    public class ConnectService
    {
        string strConnect = @"Data Source=.\SQLEXPRESS;Initial Catalog=Library;Integrated Security=True";
        SqlConnection sqlCon;
        SqlCommand sqlCom;
        SqlDataReader sqlRea;
        SqlDataAdapter sqlAdap;
        DataSet dSet = new DataSet();
        DataTable dTable = new DataTable("DB");

        //Phương thức kết nối tới CSDL SQL Server
        public SqlConnection Connect()
        {
            sqlCon = new SqlConnection(strConnect);
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            return sqlCon;
        }
        //Phương thức đóng kết nối tới CSDL
        private void NgatKetNoi()
        {
            if (sqlCon.State == ConnectionState.Open)
            {
                sqlCon.Close();
            }
        }
        //Câu lệnh SQL: Insert, Update, Delete...
        public void ThucThiSQLTheoKetNoi(string strSql)
        {
            Connect();
            sqlCom = new SqlCommand(strSql, sqlCon);
            sqlCom.ExecuteNonQuery();
            NgatKetNoi();
        }
        //Câu lệnh SQL: Insert, Update, Delete...
        public void ThucThiSQLTheoPhiKetNoi(string strSql)
        {
            dSet.Clear();
            sqlAdap = new SqlDataAdapter(strSql, strConnect);
            sqlAdap.Fill(dSet, "DB");
        }
        //Phương thức Load dữ liệu lên Combobox
        //Tên của  Combobox
        //Câu lệnh Select cần lấy dữ liệu cho Combobox
        public void LoadDataCombobox(ComboBox cb, string strSelect)
        {
            cb.Items.Clear();
            Connect();
            sqlCom = new SqlCommand(strSelect, sqlCon);
            sqlRea = sqlCom.ExecuteReader();
            while (sqlRea.Read())
            {
                cb.Items.Add(sqlRea[0].ToString());
            }
            NgatKetNoi();
        }
        public void LoadDataListBox(ListBox lb, string strSelect)
        {
            lb.Items.Clear();
            Connect();
            sqlCom = new SqlCommand(strSelect, sqlCon);
            sqlRea = sqlCom.ExecuteReader();
            while (sqlRea.Read())
            {
                lb.Items.Add(sqlRea[0].ToString());
            }
            NgatKetNoi();
        }
        public void LoadDataLabel(Label lb, string strSelect)
        {
            lb.Text = "";
            Connect();
            sqlCom = new SqlCommand(strSelect, sqlCon);
            sqlRea = sqlCom.ExecuteReader();
            while (sqlRea.Read())
            {
                lb.Text = sqlRea[0].ToString();
            }
            NgatKetNoi();
        }
        //Phương thức Load dữ liệu lên DataGridView
        //Tên của DataGridView
        //Câu lệnh Select cần lấy dữ liệu cho DataGridView
        public void LoadDataDataGridView(DataGridView dg, string strSelect)
        {
            dTable.Clear();
            sqlAdap = new SqlDataAdapter(strSelect, strConnect);
            sqlAdap.Fill(dTable);
            dg.DataSource = dTable;
        }

        public Object getValueModel(string sql) //lay gia tri cua cot dau tien trong bang 
        {
            sqlCom = new SqlCommand();
            sqlCom.CommandType = CommandType.Text;
            sqlCom.CommandText = sql;
            sqlCom.Connection = sqlCon;
            //Chi can lay ve gia tri cua mot truong thoi thi dung pt nao ? -ExecuteScalar
            Object obj = sqlCom.ExecuteScalar(); //neu co loi thi phai xem lai cua lenh SQL o ben kia
            return obj;
        }
    }
}
