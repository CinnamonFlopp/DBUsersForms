using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Citilink;

namespace Citilink
{
    public partial class Main : Form
    {
        DataBase DataBase = new DataBase();
        public Main()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            textBox_Password.PasswordChar = '*';
            textBox_Login.MaxLength = 50;
            textBox_Password.MaxLength = 50;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox_Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Login_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var loginUser = textBox_Login.Text;
            var password = textBox_Password.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"select id,login,password from register where login = '{loginUser}' and password = '{password}'";
            SqlCommand command = new SqlCommand(querystring, DataBase.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count==1)
            {
                MessageBox.Show("Вы успешно вошли!","Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataGrid dtg = new DataGrid();
                dtg.Show();
            }
            else
            {
                MessageBox.Show("Такого пользователя не существует!", "Попробуйте ещё раз!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
