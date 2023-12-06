using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buoi12
{
    public partial class Form1 : Form
    {
        function fn = new function();
        string query;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            query = "SELECT * FROM HoiNghi";
            DataSet ds = fn.GetData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ma = txtMa.Text;
            string ten = txtTen.Text;
            string songuoi = txtSoNguoi.Text;
            string maphong = cboPhongHN.Text;
            query = "INSERT INTO HoiNghi VALUES('" + ma + "','" + ten + "','" + songuoi + "','" + maphong + "')"; 
        }

        private void btnLuuThem_Click(object sender, EventArgs e)
        {
            fn.setData(query, "Thêm thành công");
            query = "SELECT * FROM HoiNghi";
            DataSet ds = fn.GetData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            query = "delete HoiNghi where maHoiNghi = '"+ txtMa.Text + "'";
            fn.setData(query, "Xóa thành công");
            query = "SELECT * FROM HoiNghi";
            DataSet ds = fn.GetData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cboPhongHN.SelectedIndex == 0)
            {
                query = "SELECT * FROM HoiNghi WHERE maLoaiPhong = 'PHONG_HN' ";
                DataSet ds = fn.GetData(query);
                dataGridView1.DataSource = ds.Tables[0];
            }
            if (cboPhongHN.SelectedIndex == 1)
            {
                query = "SELECT * FROM HoiNghi WHERE maLoaiPhong = 'PHONG_HOP' ";
                DataSet ds = fn.GetData(query);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }
    }
}
