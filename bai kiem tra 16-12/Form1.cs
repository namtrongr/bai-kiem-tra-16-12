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

namespace bai_kiem_tra_16_12
{

    public partial class Form1 : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=DESKTOP-F166USU;Initial Catalog=QLDIEM_NGUYENTRONGNAM;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from tblDiemSV ";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgv.DataSource = table;
            connection.Close();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnGhi.Enabled = true;
            btnHuy.Enabled = true;
            tbID.Enabled = true;
            tbMaSv.Enabled = true;
            tbTenSv.Enabled = true;
            dtpkNgaySInh.Enabled = true;
            cbGioiTInh.Enabled = true;
            tbDiemCC.Enabled = true;
            tbDiemCK.Enabled = true;
            tbDiemGK.Enabled = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnGhi.Enabled = false;
            btnHuy.Enabled = false;
            tbID.Enabled = false;
            tbMaSv.Enabled = false;
            tbTenSv.Enabled = false;
            dtpkNgaySInh.Enabled = false;
            cbGioiTInh.Enabled = false;
            tbDiemGK.Enabled = false;
            tbDiemCC.Enabled = false;
            tbDiemCK.Enabled = false;
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgv.CurrentRow.Index;
            tbID.Text = dgv.Rows[i].Cells[0].Value.ToString();
            tbMaSv.Text = dgv.Rows[i].Cells[1].Value.ToString();
            tbTenSv.Text = dgv.Rows[i].Cells[2].Value.ToString();
            dtpkNgaySInh.Text = dgv.Rows[i].Cells[3].Value.ToString();
            cbGioiTInh.Text = dgv.Rows[i].Cells[4].Value.ToString();
            tbDiemGK.Text = dgv.Rows[i].Cells[5].Value.ToString();
            tbDiemCC.Text = dgv.Rows[i].Cells[6].Value.ToString();
            tbDiemCK.Text = dgv.Rows[i].Cells[7].Value.ToString();
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "Insert into tblDiemSV values( @TenSV,@MaSV, @NgaySinh, @GioiTinh,@DiemGiuaKy,@DiemChuyenCan,@DiemCuoiKy)";
            command.Parameters.AddWithValue("@MaSV", tbMaSv.Text);
            command.Parameters.AddWithValue("@TenSV", tbTenSv.Text);
            command.Parameters.AddWithValue("@GioiTinh", cbGioiTInh.Text);
            command.Parameters.AddWithValue("@NgaySinh", dtpkNgaySInh.Value);
            command.Parameters.AddWithValue("@DiemGiuaKy", tbDiemGK.Text);
            command.Parameters.AddWithValue("@DiemChuyenCan", tbDiemCC.Text);
            command.Parameters.AddWithValue("@DiemCuoiKy", tbDiemCK.Text);
            command.ExecuteNonQuery();
            loaddata();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "delete from tblDiemSV where ID = @ID";
            command.Parameters.AddWithValue("@ID", tbID.Text);
            command.ExecuteNonQuery();
            loaddata();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }
    }
}
