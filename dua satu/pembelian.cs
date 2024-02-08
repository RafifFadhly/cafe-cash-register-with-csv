using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kasir
{
    public class beli
    {
        private string menu;
        private int harga;
        private int jumlah;

        public string Menu { get => menu;}
        public int Harga { get => harga;}
        public int Jumlah { get => jumlah;}

        public void Beli(string menu, int harga,int jml)
        {
            this.menu = menu;
            this.harga = harga;
            this.jumlah = jml;
        }
    }
}