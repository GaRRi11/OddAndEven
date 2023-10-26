using System.Globalization;
using System.Windows.Forms;

namespace OddAndEven
{
    public partial class Form1 : Form
    {
        private const string NoItemsToSortMessage = "No items in the list to sort.";
        private const string UnselectedListBoxMessage = "Please select a ListBox first.";
        private ControlManager controlManager;
        private ListBox selectedListBox;
        private ListBox listEven;
        private ListBox listOdd;
        private Button btnAdd;
        private Button btnOddToEven;
        private Button btnEvenToOdd;
        private Button btnOddToEvenAll;
        private Button btnEvenToOddAll;
        private Button btnAscending;
        private Button btnDescending;
        private Button btnUndo;
        private Button btndelete;
        private TextBox textBox1;
        private Stack<Operation> operationHistory = new Stack<Operation>();


        public Form1()
        {
            InitializeComponent();
            Button testButton = new Button();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             controlManager = new ControlManager();


            listEven = controlManager.createListBox("listEven", new Point(44, 24),
                new Size(170, 244));
            listOdd = controlManager.createListBox("listOdd", new Point(371, 24),
                new Size(170, 244));
            this.Controls.Add(listEven);
            this.Controls.Add(listOdd);
            listEven.Click += ListBox_Click;
            listOdd.Click += ListBox_Click;

            btnOddToEven = controlManager.CreateButton("btnOddToEven", "<-",
                new Point(230, 47), new Size(94, 29));
            this.Controls.Add(btnOddToEven);
            btnOddToEven.Click += btnOddToEven_Click;

            btnEvenToOdd = controlManager.CreateButton("btnEvenToOdd", "->",
                new Point(230, 153), new Size(94, 35));
            this.Controls.Add(btnEvenToOdd);
            btnEvenToOdd.Click += btnEvenToOdd_Click;

            btnOddToEvenAll = controlManager.CreateButton("btnOddToEvenAll", "<- <-",
                new Point(230, 101), new Size(94, 29));
            this.Controls.Add(btnOddToEvenAll);
            btnOddToEvenAll.Click += btnOddToEvenAll_Click;

            btnEvenToOddAll = controlManager.CreateButton("btnEvenToOddAll", "-> ->",
                new Point(230, 232), new Size(94, 29));
            this.Controls.Add(btnEvenToOddAll);
            btnEvenToOddAll.Click += btnEvenToOddAll_Click;

            btnAdd = controlManager.CreateButton("btnAdd", "Add", new Point(418, 360),
                new Size(94, 29));
            this.Controls.Add(btnAdd);
            btnAdd.Click += btnAdd_Click;
            AcceptButton = btnAdd;

            btnAscending = controlManager.CreateButton("btnAscending", "Sort Ascending",
                new Point(552, 47), new Size(114, 48));
            this.Controls.Add(btnAscending);
            btnAscending.Click += btnAscending_Click;

            btnDescending = controlManager.CreateButton("btnDescending", "Sort Descending",
                new Point(552, 101), new Size(114, 48));
            this.Controls.Add(btnDescending);
            btnDescending.Click += btnDescending_Click;

            btnUndo = controlManager.CreateButton("btnUndo", "Undo",
                new Point(681, 400), new Size(114, 48));
            this.Controls.Add(btnUndo);
            btnUndo.Click += btnUndo_Click;

            btndelete = controlManager.CreateButton("btnDelete", "Delete",
                new Point(552, 155), new Size(114, 48));
            this.Controls.Add(btndelete);
            btndelete.Click += btnDelete_Click;


            textBox1 = controlManager.createTextBox("textBox1", new Point(44, 360),
                new Size(328, 27));
            this.Controls.Add(textBox1);

        }
        private void btnUndo_Click(object sender, EventArgs e)
        { }


            private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listEven.SelectedItems.Count > 0 || listOdd.SelectedItems.Count > 0)
            {
                listEven.deleteSelectedItems();
                listOdd.deleteSelectedItems();
                listEven.ClearSelected();
                listOdd.ClearSelected();
            }
            else
            {
                MessageBox.Show("No items selected to delete.");
            }
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
            if (listOdd.SelectedItems.Count == 0)
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
    }
}
