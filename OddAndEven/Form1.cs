using System.Globalization;
using System.Windows.Forms;

namespace OddAndEven
{
    public partial class Form1 : Form
    {
        private ListBox selectedListBox;
        private const string NoItemsToSortMessage = "No items in the list to sort.";
        private const string UnselectedListBoxMessage = "Please select a ListBox first.";


        public Form1()
        {
            InitializeComponent();

            listEven.Click += ListBox_Click;
            listOdd.Click += ListBox_Click;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            AcceptButton = btnAdd;
        }

        private void ListBox_Click(object sender, EventArgs e)
        {
            selectedListBox = (ListBox)sender;

            selectedListBox.BorderStyle = BorderStyle.FixedSingle;

            if (selectedListBox == listEven)
            {
                listOdd.BorderStyle = BorderStyle.None;
            }
            else if (selectedListBox == listOdd)
            {
                listEven.BorderStyle = BorderStyle.None;
            }
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

        private void btnOddToEven_Click(object sender, EventArgs e)
        {
            if(listOdd.SelectedItems.Count == 0)
            {
                listOdd.transferOne(listEven);
            }
            else
            {
                listOdd.transferSelectedItems(listEven);
            }
        }
        private void btnOddToEvenAll_Click(object sender, EventArgs e)
        {
            listOdd.transferAll(listEven);
        }
        private void btnEvenToOdd_Click(object sender, EventArgs e)
        {
            if (listEven.SelectedItems.Count == 0)
            {
                listEven.transferOne(listOdd);
            }
            else
            {
                listEven.transferSelectedItems(listOdd);
            }
        }
        private void btnEvenToOddAll_Click(object sender, EventArgs e)
        {
            listEven.transferAll(listOdd);
        }
        private void btnAscending_Click(object sender, EventArgs e)
        {
            if (selectedListBox == null)
            {
                MessageBox.Show(UnselectedListBoxMessage);
                return;
            }
            else
            {
                if (selectedListBox.Items.Count == 0)
                {
                    MessageBox.Show(NoItemsToSortMessage);
                    return;
                }
                else
                {
                    selectedListBox.SortAndRefreshListBox(true);
                }
            }
        }

        private void btnDescending_Click(object sender, EventArgs e)
        {
            if (selectedListBox == null)
            {
                MessageBox.Show(UnselectedListBoxMessage);
                return;
            }
            else
            {
                if (selectedListBox.Items.Count == 0)
                {
                    MessageBox.Show(NoItemsToSortMessage);
                    return;
                }
                else
                {
                    selectedListBox.SortAndRefreshListBox(false);
                }
            }
        }


        //private void CreateButtom()
        //{
        //    Button button = new Button();
        //    button.Text = "aaa";
        //    button.Width = 50;
        //    button.Height = 20;
        //    button.Top = 150;
        //    button.Left = 15;
        //    this.Controls.Add(button);
        //}
    }
}
