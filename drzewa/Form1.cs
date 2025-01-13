using System;
using System.Windows.Forms;
using drzewa;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace drzewa
{
    public partial class Form1 : Form
    {
        private BST tree;
        public Form1()
        {
            InitializeComponent();
            tree = new BST();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int liczba))
            {
                tree.Add(liczba);
                tree.DodajDoTreeView(treeView1.Nodes);
                textBox1.Clear();
            }
            else
            {
                MessageBox.Show("WprowadŸ poprawn¹ liczbê.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out int value))
            {
                RemoveNodeFromTreeView(treeView1, value);
                textBox2.Clear(); // Opcjonalnie wyczyœæ pole tekstowe po usuniêciu
            }
            else
            {
                MessageBox.Show("WprowadŸ poprawn¹ liczbê.");
            }
       
        }
    }
}
