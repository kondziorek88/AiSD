using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace drzewa
{
    public  class NodeT
    {
        public NodeT rodzic;
        public NodeT lewe;
        public NodeT prawe;
        public int data;
        public NodeT(int liczba)
        {
            this.data = liczba;
            this.lewe = null;
            this.prawe = null;
            this.rodzic = null;
        }
        //rodzic == this
        void Polacz(NodeT dziecko)
        {
            dziecko.rodzic = this;
            if (dziecko.data < this.data)
            {
                this.lewe = dziecko;
            }
            else
            {
                this.prawe = dziecko;
            }
        }
    }
}
