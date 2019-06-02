namespace QuanLyThuVien
{
    partial class frmPhieuMuonQuaHan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPhieuMuonQuaHan = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuMuonQuaHan)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Info;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.ForestGreen;
            this.label1.Location = new System.Drawing.Point(440, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(444, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Danh sách phiếu mượn quá hạn";
            // 
            // dgvPhieuMuonQuaHan
            // 
            this.dgvPhieuMuonQuaHan.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvPhieuMuonQuaHan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieuMuonQuaHan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dgvPhieuMuonQuaHan.Location = new System.Drawing.Point(2, 99);
            this.dgvPhieuMuonQuaHan.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvPhieuMuonQuaHan.Name = "dgvPhieuMuonQuaHan";
            this.dgvPhieuMuonQuaHan.Size = new System.Drawing.Size(1382, 622);
            this.dgvPhieuMuonQuaHan.TabIndex = 3;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "MADG";
            this.Column1.HeaderText = "Mã độc giả";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "MASACH";
            this.Column2.HeaderText = "Mã sách";
            this.Column2.Name = "Column2";
            // 
            // column3
            // 
            this.column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.column3.DataPropertyName = "SOLUONGMUON";
            this.column3.HeaderText = "Tổng số sách mượn";
            this.column3.Name = "column3";
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.DataPropertyName = "NGAYMUON";
            this.Column4.HeaderText = "Ngày mượn";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.DataPropertyName = "NGAYTRA";
            this.Column5.HeaderText = "Ngày trả";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column6.DataPropertyName = "XACNHANTRA";
            this.Column6.HeaderText = "Xác nhận trả";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column7.DataPropertyName = "GHICHU";
            this.Column7.HeaderText = "Ghi chú";
            this.Column7.Name = "Column7";
            // 
            // frmPhieuMuonQuaHan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1385, 722);
            this.Controls.Add(this.dgvPhieuMuonQuaHan);
            this.Controls.Add(this.label1);
            this.Name = "frmPhieuMuonQuaHan";
            this.Text = "Phiếu mượn quá hạn";
            this.Load += new System.EventHandler(this.frmTimKiemThongTinMuon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuMuonQuaHan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPhieuMuonQuaHan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}