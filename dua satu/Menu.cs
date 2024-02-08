using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kasir
{
    public class Menu
    {
        private string jenis;
        private string menu;
        private int harga;
        private int stok;
        private int id;

        public string Jenis { get => jenis;}
        public string Menus { get => menu;}
        public int Harga { get => harga;}
        public int ID { get => id; }
        public int Stok { get => stok; set => stok = value; }

        public void EditBarang(string jenis, string menu, int harga,int stok)
        {
            this.jenis = jenis;
            this.menu = menu;
            this.harga = harga;
            this.Stok = stok;
        }

        public void IsiBarang(int getId, string jenis, string menu, int harga, int stok)
        {
            this.id = getId;
            this.jenis = jenis;
            this.menu = menu;
            this.harga = harga;
            this.Stok = stok;
        }
    }
}