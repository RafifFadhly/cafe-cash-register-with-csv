using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.LinkLabel;
using System.Runtime.InteropServices.WindowsRuntime;

namespace kasir
{
    public partial class kasir : Form
    {
        public User_Parent User;
        List<Menu> listMenu = new List<Menu>();
        List<beli> listbeli = new List<beli>();
        public int barangID;
        public string username;
        public string status;
        int barang;
        int total = 0;
        public kasir()
        {
            InitializeComponent();
        }

        void savedata()
        {
            if (File.Exists("data.csv"))File.Delete("data.csv");

            StreamWriter sw = new StreamWriter("data.csv");
            sw.WriteLine("#ID,Jenis, Menu, Harga, Stok");
            foreach (Menu getMenu in listMenu)
                sw.WriteLine(getMenu.ID.ToString() + "," +
                getMenu.Jenis.ToString() + "," +
                getMenu.Menus.ToString() + "," +
                getMenu.Harga.ToString() + "," +
                getMenu.Stok.ToString());
            sw.Close();
        }

        void LoadData()
        {
            if (File.Exists("data.csv"))
            {
                StreamReader sr = new StreamReader("data.csv");
                string line = sr.ReadLine();
                while (line != null)
                {
                    if (!line.Contains("#"))
                    {
                        string[] strSplit = line.Split(',');
                        int id = int.Parse(strSplit[0]);
                        string jenis = strSplit[1];
                        string menu = strSplit[2];
                        int harga = int.Parse(strSplit[3]);
                        int stok = int.Parse(strSplit[4]);
                        Menu newMenu = new Menu();
                        newMenu.IsiBarang(id, jenis,menu, harga, stok);
                        listMenu.Add(newMenu);
                    }
                    line = sr.ReadLine();
                }
                sr.Close();
            }
        }
        
        private void tambah_Click(object sender, EventArgs e)
        {
            Menu Menu = new Menu();
            barangID = GetFreeID();
            Menu.IsiBarang(
                barangID,
                jenis_txt.Text,
                Menu_txt.Text,
                (int)harga_txt.Value,
                (int)Stok.Value
                );
            listMenu.Add(Menu);
            RefreshDataGrid();
            savedata();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            Menu getMenu = SelectBarang();
            getMenu.EditBarang(
                jenis_edit.Text,
                menu_edit.Text, 
                (int)harga_edit.Value,
                (int)Stok_edit.Value
                );
            RefreshDataGrid();
            savedata();
            groupBox2.Enabled = false;
        }

        private void Hapus_Click(object sender, EventArgs e)
        {
            Menu getMenu = SelectBarang();
            if (listMenu.Contains(getMenu))
                listMenu.Remove(getMenu);
            RefreshDataGrid();
            savedata() ;
        }

        private void RefreshDataGrid()
        {
            dataGridView1.Rows.Clear();
            foreach (Menu getMenu in listMenu)
            {
                string[] newRow = { "", "", "", "", "",""};
                newRow[0] = getMenu.ID.ToString();
                newRow[1] = getMenu.Jenis;
                newRow[2] = getMenu.Menus;
                newRow[3] = getMenu.Harga.ToString();
                newRow[4] = getMenu.Stok.ToString();
                dataGridView1.Rows.Add(newRow);
            }
        }

        private void RefreshDataGrid_stok_ada(bool tes)
        {
            dataGridView1.Rows.Clear();
            foreach (Menu getMenu in listMenu)
            {
                if (tes)
                {
                    if (getMenu.Stok != 0)
                    {
                        string[] newRow = { "", "", "", "", "", "" };
                        newRow[0] = getMenu.ID.ToString();
                        newRow[1] = getMenu.Jenis;
                        newRow[2] = getMenu.Menus;
                        newRow[3] = getMenu.Harga.ToString();
                        newRow[4] = getMenu.Stok.ToString();
                        dataGridView1.Rows.Add(newRow);
                    }
                }
                else
                {
                    if (getMenu.Stok == 0)
                    {
                        string[] newRow = { "", "", "", "", "", "" };
                        newRow[0] = getMenu.ID.ToString();
                        newRow[1] = getMenu.Jenis;
                        newRow[2] = getMenu.Menus;
                        newRow[3] = getMenu.Harga.ToString();
                        newRow[4] = getMenu.Stok.ToString();
                        dataGridView1.Rows.Add(newRow);
                    }
                }
            }
        }

        private int GetFreeID()
        {
            int nowID = 1;
            while (true)
            {
                bool adaYgSama = false;
                foreach (Menu checkMenu in listMenu)
                {
                    if (checkMenu.ID == nowID)
                        adaYgSama = true;
                }
                if (adaYgSama) nowID += 1;
                else
                    break;
            }
            return nowID;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Menu getBarang = SelectBarang();
            groupBox2.Enabled = true;
            jenis_edit.Text = getBarang.Jenis;
            menu_edit.Text = getBarang.Menus;
            harga_edit.Value = getBarang.Harga;
            Stok_edit.Value = getBarang.Stok;
        }

        private Menu SelectBarang()
        {
            int getID = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i += 1)
            {
                if (dataGridView1.Rows[i].Selected)
                {
                    getID = int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                    Menu getMenu = new Menu();
                    foreach (Menu checkMenu in listMenu)
                    {
                        if (checkMenu.ID == getID)
                            getMenu = checkMenu;
                    }
                    return getMenu;
                }
            }
            return null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tambahUserToolStripMenuItem.Enabled = false;
            Koki.Enabled = false;


            LoadData();
            RefreshDataGrid();
            groupBox2.Enabled = false;
            barang = 0;
            if (status == "koki")
            {
                Koki.Enabled = true;
            }
            if (status == "admin")
            {
                tambahUserToolStripMenuItem.Enabled = true;
                Koki.Enabled = false;
            }
        }

        private void search_click_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            foreach (Menu getMenu in listMenu)
            {
                if (getMenu.Jenis == cari_jenis.Text && cari_menu.Text == "")
                {
                    string[] newRow = { "", "", "", "", "" };
                    newRow[0] = getMenu.ID.ToString();
                    newRow[1] = getMenu.Jenis;
                    newRow[2] = getMenu.Menus;
                    newRow[3] = getMenu.Harga.ToString();
                    newRow[4] = getMenu.Stok.ToString();
                    dataGridView1.Rows.Add(newRow);
                }
                else if (getMenu.Jenis == cari_jenis.Text && cari_menu.Text == getMenu.Menus.ToLower())
                {
                    string[] newRow = { "", "", "", "", "" };
                    newRow[0] = getMenu.ID.ToString();
                    newRow[1] = getMenu.Jenis;
                    newRow[2] = getMenu.Menus;
                    newRow[3] = getMenu.Harga.ToString();
                    newRow[4] = getMenu.Stok.ToString();
                    dataGridView1.Rows.Add(newRow);
                }

            }
        }
        private void refresh_Click(object sender, EventArgs e)
        {
            RefreshDataGrid();
            cari_jenis.Text = "";
            cari_menu.Clear();
        }
        private void stok_tdk_ada_CheckedChanged(object sender, EventArgs e)
        {
            if (stok_tdk_ada.Checked)
            {
                RefreshDataGrid_stok_ada(false);
            }
            else
            {
                RefreshDataGrid();
            }
        }

        private void stok_ada_CheckedChanged(object sender, EventArgs e)
        {
            if (stok_ada.Checked)
            {
                RefreshDataGrid_stok_ada(true);
            }
            else
            {
                RefreshDataGrid();
            }
        }
        beli Selected_datagridview2()
        {
            for (int i = 0; i < dataGridView2.Rows.Count; i += 1)
            {
                if (dataGridView2.Rows[i].Selected)
                {
                    string Menu = dataGridView2.Rows[i].Cells[0].Value.ToString();
                    beli getbeli = new beli();
                    foreach (beli checkbeli in listbeli)
                    {
                        if (checkbeli.Menu == Menu)
                            getbeli = checkbeli;
                    }
                    return getbeli;
                }
            }
            return null;
        }
        private void tambah_beli_Click(object sender, EventArgs e)
        {
            Menu getMenu = SelectBarang();
            if ((int)Jml_n.Value != 0 && (int)Jml_n.Value <= getMenu.Stok)
            {
                bool ada = false;
                int u = 0;
                foreach (beli getbeli in listbeli)
                {
                    if (getMenu.Menus == dataGridView2.Rows[u].Cells[0].Value.ToString())
                    {
                        getbeli.Beli(getMenu.Menus, getMenu.Harga * (int)Jml_n.Value, (int)Jml_n.Value);
                        ada = true;
                        break;
                    }
                    else u++;
                }
                if (!ada)
                {
                    beli Beli = new beli();
                    Beli.Beli(getMenu.Menus, getMenu.Harga * (int)Jml_n.Value, (int)Jml_n.Value);
                    listbeli.Add(Beli);
                    total = 0;
                    foreach (beli getBeli in listbeli)
                    {
                        total += getBeli.Harga;
                    }
                    Total.Text = total.ToString();
                }
                refresh_datagrid2();
            }
            else if((int)Jml_n.Value > getMenu.Stok) MessageBox.Show("Maaf Stok tidak memadai");
            else MessageBox.Show("isi jumlah pesanan dahulu");
        }


        private void hapus_beli_Click(object sender, EventArgs e)
        {
            beli Beli = Selected_datagridview2();
            if (listbeli.Contains(Beli))
                listbeli.Remove(Beli);
            refresh_datagrid2();
        }
        void refresh_datagrid2()
        {
            dataGridView2.Rows.Clear();
            foreach (beli getBeli in listbeli)
            {
                string[] newRow = { "", "", ""};
                newRow[0] = getBeli.Menu;
                newRow[1] = getBeli.Jumlah.ToString();
                newRow[2] = getBeli.Harga.ToString();
                dataGridView2.Rows.Add(newRow);
            }
        }
        private void clear_Click(object sender, EventArgs e)
        {
            listbeli.Clear();
            dataGridView2.Rows.Clear();
            Total.Clear();
            Bayar.Value = 0;
            Kembalian.Clear();
            pelanggan.Clear();
        }

        private void beli_Click(object sender, EventArgs e)
        {
            if(pelanggan.Text != "")
            {
                int bayar;
                if (total == 0 && ((int)Bayar.Value == null||(int)Bayar.Value==0))
                {
                    MessageBox.Show("tolong isi pesanan dan uang bayar dulu");
                }
                else
                {
                    bayar = (int)Bayar.Value-total;
                    if (bayar < 0)
                    {
                        MessageBox.Show("Maaf Uang anda tidak cukup");
                    }
                    else{
                        Print print = new Print();
                        print.list.Text = "Kasir : "+ username + Environment.NewLine + "pelanggan : " + pelanggan.Text + Environment.NewLine + DateTime.Now + Environment.NewLine + Environment.NewLine;
                        print.list.Text += "Menu     Jml     Total" + Environment.NewLine + Environment.NewLine;
                        foreach (beli getBeli in listbeli)
                        {
                            foreach (Menu menu in listMenu)
                            {
                                if (getBeli.Menu == menu.Menus)
                                {
                                    print.list.Text += getBeli.Menu + "    " + getBeli.Jumlah.ToString() + "   Rp." + getBeli.Harga.ToString()+ Environment.NewLine;
                                    menu.Stok -= getBeli.Jumlah;
                                }

                            }
                        }
                        Kembalian.Text = bayar.ToString();
                        print.list.Text += Environment.NewLine + Environment.NewLine + "Total Pembayaran : " + Total.Text;
                        print.list.Text += Environment.NewLine +"Kembalian : "+Kembalian.Text;
                        print.Show();
                    }
                }
                clear_Click(sender, e);
                RefreshDataGrid();
                savedata();
            }
            else MessageBox.Show("tolong isi nama pelanggan");
        }

        TambahUser Edit_User;
        private void tambahUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Edit_User == null)Edit_User = new TambahUser();

            User.RefreshDataGrid(Edit_User.dataUser);
            Edit_User.User = User;
            Edit_User.Show();
        }
        private void label8_Click(object sender, EventArgs e) 
        {

        }

        private void Tambah_Nama_TextChanged(object sender, EventArgs e)
        {

        }


        private void akunToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Koki_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
