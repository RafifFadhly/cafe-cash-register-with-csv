using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace kasir
{
    public class User_Parent
    {
        public List<User> listuser = new List<User>();
        int ID = 0;

        void savedata()
        {
            if (File.Exists("data user.csv")) File.Delete("data user.csv");

            StreamWriter sw = new StreamWriter("data user.csv");
            sw.WriteLine("#ID,username, password, admin");
            foreach (User getUser in listuser)
                sw.WriteLine(getUser.Id_karyawan.ToString() + "," +
                getUser.Username.ToString() + "," +
                getUser.Password.ToString() + "," +
                getUser.Status.ToString());
            sw.Close();
        }

        public void LoadData()
        {
            if (File.Exists("data user.csv"))
            {
                StreamReader sr = new StreamReader("data user.csv");
                string line = sr.ReadLine();
                while (line != null)
                {
                    if (!line.Contains("#"))
                    {
                        string[] strSplit = line.Split(',');
                        int id = int.Parse(strSplit[0]);
                        string username = strSplit[1];
                        string password = strSplit[2];
                        string Status = strSplit[3].ToLower();
                        User newUser = new User();
                        newUser.tambah(id,username,password,Status);
                        listuser.Add(newUser);
                    }
                    line = sr.ReadLine();
                }
                sr.Close();
            }
        }

        private int GetFreeID()
        {
            int nowID = 1;
            while (true)
            {
                bool adaYgSama = false;
                foreach (User checkMenu in listuser)
                {
                    if (checkMenu.Id_karyawan == nowID)
                        adaYgSama = true;
                }
                if (adaYgSama) nowID += 1;
                else
                    break;
            }
            return nowID;
        }

        public void Tambah(DataGridView dataGridView, TextBox username, TextBox password, ComboBox Status)
        {
            User user= new User();
            ID = GetFreeID();
            user.tambah(
                ID,
                username.Text,
                password.Text,
                Status.Text
                );
            listuser.Add(user);
            savedata();
            RefreshDataGrid( dataGridView );
        }

        public void Edit(DataGridView dataGridView, TextBox username, TextBox password, ComboBox Status)
        {
            User getuser = SelectBarang(dataGridView);
            getuser.Edit(
                username.Text,
                password.Text,
                Status.Text
                );
            savedata();
            RefreshDataGrid(dataGridView);
        }
        public void Hapus(DataGridView dataGridView)
        {
            User getuser = SelectBarang(dataGridView);
            if (listuser.Contains(getuser))
                listuser.Remove(getuser);
            RefreshDataGrid(dataGridView);
            savedata();
        }
        private User SelectBarang(DataGridView dataGridView)
        {
            int getID = 0;
            for (int i = 0; i < dataGridView.Rows.Count; i += 1)
            {
                if (dataGridView.Rows[i].Selected)
                {
                    getID = int.Parse(dataGridView.Rows[i].Cells[0].Value.ToString());
                    User getuser = new User();
                    foreach (User checkuser in listuser)
                    {
                        if (checkuser.Id_karyawan == getID)
                            getuser = checkuser;
                    }
                    return getuser;
                }
            }
            return null;
        }
        public void RefreshDataGrid(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            foreach (User getuser in listuser)
            {
                string[] newRow = { "", "", "", "" };
                newRow[0] = getuser.Id_karyawan.ToString();
                newRow[1] = getuser.Username;
                newRow[2] = getuser.Password;
                newRow[3] = getuser.Status;
                dataGridView.Rows.Add(newRow);
            }
        }
        public void cellclik(DataGridView dataGridView, TextBox username, TextBox password, ComboBox Status)
        {
            User getuser = SelectBarang(dataGridView);
            username.Text = getuser.Username;
            password.Text = getuser.Password;
            Status.Text = getuser.Status;
        }
    }
}