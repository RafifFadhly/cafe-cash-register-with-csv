using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace kasir
{
    public class User
    {
        private int id_karyawan;
        private string nama_karyawan;
        private string password;
        private string admin;

        public int Id_karyawan { get => id_karyawan; set => id_karyawan = value; }
        public string Username { get => nama_karyawan; set => nama_karyawan = value; }
        public string Password { get => password; set => password = value; }
        public string Status { get => admin; set => admin = value; }

        public void tambah(int id, string username, string password, string status)
        {
            id_karyawan = id;
            Username = username;
            Password = password;
            Status = status;
        }

        public void Edit(string username, string password, string status)
        {
            Username = username;
            Password = password;
            Status = status;
        }
    }
}