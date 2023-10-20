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
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter a number.");
                textBox1.Clear();
                return;
            }

            if (!int.TryParse(textBox1.Text, out int number))
            {
                MessageBox.Show("Type only numbers");
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

        private void transferOne(ListBox listBox1, ListBox listBox2)
        {
            if (listBox1.Items.Count > 0)
            {
                object itemToTransfer = listBox1.Items[0];
                listBox1.Items.RemoveAt(0);
                listBox2.Items.Add(itemToTransfer);
            }
            else
            {
                MessageBox.Show("No items in the list to transfer.");
            }
        }

        private void transferAll(ListBox listBox1, ListBox listBox2)
        {
            if (listBox1.Items.Count > 0)
            {
                foreach (var item in listBox1.Items)
                {
                    listBox2.Items.Add(item);
                }
                listBox1.Items.Clear();
            }
            else
            {
                MessageBox.Show("No items in the list to transfer.");
            }
        }

        private void SortAndRefreshList(ListBox listBox, bool ascending) {

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
            transferOne(listOdd, listEven);
        }
        private void btnOddToEvenAll_Click(object sender, EventArgs e)
        {
            transferAll(listOdd, listEven);
        }
        private void btnEvenToOdd_Click(object sender, EventArgs e)
        {
            transferOne(listEven, listOdd);
        }
        private void btnEvenToOddAll_Click(object sender, EventArgs e)
        {
            transferAll(listEven, listOdd);
        }
        private void btnEvenAscending_Click(object sender, EventArgs e)
        {
            SortAndRefreshList(listEven, true);
        }
        private void btnEvenDescending_Click(object sender, EventArgs e)
        {
            SortAndRefreshList(listEven, false);
        }
        private void btnOddAscending_Click(object sender, EventArgs e)
        {
            SortAndRefreshList(listOdd, true);
        }
        private void btnOddDescending_Click(object sender, EventArgs e)
        {
            SortAndRefreshList(listOdd, false);
        }
    }
}