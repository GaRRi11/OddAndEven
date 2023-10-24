using System.Globalization;
using System.Windows.Forms;

namespace OddAndEven
{
    public partial class Form1 : Form
    {
        private ListBox selectedListBox;
        public Form1()
        {
            InitializeComponent();

            listEven.Click += ListBox_Click;
            listOdd.Click += ListBox_Click;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            AcceptButton = btnAdd;
            CreateButtom();
        }

        private void ListBox_Click(object sender, EventArgs e)
        {
            selectedListBox = (ListBox)sender; // Store the selected ListBox.
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
        private void CreateButtom()
        {
            Button button = new Button();
            button.Text = "aaa";
            button.Width = 50;
            button.Height = 20;
            button.Top = 150;
            button.Left = 15;
            this.Controls.Add(button);
        }

        private void btnOddToEven_Click(object sender, EventArgs e)
        {
            listOdd.transferOne(listEven);
        }
        private void btnOddToEvenAll_Click(object sender, EventArgs e)
        {
            listOdd.transferAll(listEven);
        }
        private void btnEvenToOdd_Click(object sender, EventArgs e)
        {
            listEven.transferOne(listOdd);
        }
        private void btnEvenToOddAll_Click(object sender, EventArgs e)
        {
            listEven.transferAll(listOdd);
        }
        private void btnAscending_Click(object sender, EventArgs e)
        {
            if (selectedListBox != null)
            {
                selectedListBox.SortAndRefreshListBox(true);
                selectedListBox = null;
            }
            else {
                MessageBox.Show("Please select a ListBox first.");
            }
        }
        private void btnDescending_Click(object sender, EventArgs e)
        {
            if (selectedListBox != null)
            {
                selectedListBox.SortAndRefreshListBox(true);
                selectedListBox = null;
            }
            else
            {
                MessageBox.Show("Please select a ListBox first.");
            }
        }
    }
}
