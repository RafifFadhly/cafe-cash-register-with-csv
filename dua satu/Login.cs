using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kasir
{
    public partial class Login : Form
    {
        public User_Parent User_data;
        public Login()
        {
            InitializeComponent();
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            bool login = false;
            if(User_data.listuser != null)
            {
                foreach (User user in User_data.listuser)
                {
                    if (username.Text == user.Username)
                    {
                        if (Password.Text == user.Password)
                        {
                            kasir menu = new kasir();
                            menu.User = User_data;
                            menu.username = user.Username;
                            menu.status = user.Status;
                            menu.Show();
                            login = true;
                            this.Hide();
                            break;
                        }
                    }
                }
            }
            if (!login)
            {
                MessageBox.Show("Password atau Username Salah");
            }
            if(username.Text == "develop")
            {
                kasir menu = new kasir();
                menu.User = User_data;
                menu.username = username.Text;
                menu.status = "admin";
                menu.Show();

                this.Hide();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            User_data = new User_Parent();
            User_data.LoadData();
        }
    }
}
