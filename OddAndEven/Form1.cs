using System.Globalization;
using System.Windows.Forms;

namespace OddAndEven
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            AcceptButton = btnAdd;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int number) ||
                string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Type number");
                textBox1.Clear();
                return;
            }

            if (number % 2 == 0)
            {
                listEven.Items.Add(textBox1.Text);
            }
            else
            {
                listOdd.Items.Add(textBox1.Text);
            }

            textBox1.Clear();

        }

        private void transfer(ListBox listBox1, ListBox listBox2, bool all) {

            if (listBox1.Items.Count > 0)
            {    
                    object itemToTransfer = listBox1.Items[0];
                    listBox1.Items.RemoveAt(0);
                    listBox2.Items.Add(itemToTransfer);   
            }
            else
            {
                MessageBox.Show("No items in the list to transfer.");
                return;
            }

            if (!all)
            {
                return;
            }
            while (listBox1.Items.Count > 0) {
                transfer(listBox1 as ListBox, listBox2, true);
            }
        }

        private void SortAndRefreshListBox(ListBox listBox, bool ascending) {

            List<int> numbers = new List<int>();

            foreach (object item in listBox.Items)
            {
                if (item != null)
                {
                    if (int.TryParse(item.ToString(), out int number))
                    {
                        numbers.Add(number);
                    }
                }

            }
            if (numbers.Count != 0) {
                if (ascending)
                {
                    numbers.Sort();
                }
                else
                {
                    numbers.Sort((x, y) => y.CompareTo(x));
                }
            }
            else {
                return;
            }
            

            listBox.Items.Clear();
            foreach (int number in numbers)
            {
                listBox.Items.Add(number);
            }
        }

        private void btnOddToEven_Click(object sender, EventArgs e)
        {
            transfer(listOdd, listEven,false);
        }
        private void btnOddToEvenAll_Click(object sender, EventArgs e)
        {
            transfer(listOdd, listEven,true);
        }
        private void btnEvenToOdd_Click(object sender, EventArgs e)
        {
            transfer(listEven, listOdd,false);
        }
        private void btnEvenToOddAll_Click(object sender, EventArgs e)
        {
            transfer(listEven, listOdd,true);
        }
        private void btnEvenAscending_Click(object sender, EventArgs e)
        {
            SortAndRefreshListBox(listEven, true);
        }
        private void btnEvenDescending_Click(object sender, EventArgs e)
        {
            SortAndRefreshListBox(listEven, false);
        }
        private void btnOddAscending_Click(object sender, EventArgs e)
        {
            SortAndRefreshListBox(listOdd, true);
        }
        private void btnOddDescending_Click(object sender, EventArgs e)
        {
            SortAndRefreshListBox(listOdd, false);
        }
    }
}