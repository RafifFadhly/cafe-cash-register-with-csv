using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace kasir
{
    public partial class TambahUser : Form
    {
        public User_Parent User;
        public TambahUser()
        {
            InitializeComponent();
        }

        private void tambah_Click(object sender, EventArgs e)
        {
            User.Tambah(dataUser,Username_txt,Passeord_txt,Status_txt);
        }

        private void hapus_Click(object sender, EventArgs e)
        {

            User.Hapus(dataUser);
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            User.Edit(dataUser, Username_txt, Passeord_txt, Status_txt);
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void TambahUser_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            User.cellclik(dataUser, Username_txt, Passeord_txt, Status_txt);
        }
    }
}
