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
        private Stack<ActionDescription> actionStack = new Stack<ActionDescription>();



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
        {
            if (actionStack.Count > 0)
            {
                ActionDescription lastAction = actionStack.Pop();

                switch (lastAction.Type)
                {
                    case ActionDescription.ActionType.Add:

                        // Undo the "Add" action
                        lastAction.TargetListBox.Items.Remove(lastAction.Data);
                        break;

                    case ActionDescription.ActionType.Remove:
                        // Undo the "Remove" action
                        if (lastAction.Data is List<object> itemsToRemove)
                        {
                            foreach (var item in itemsToRemove)
                            {
                                lastAction.TargetListBox.Items.Add(item);
                            }
                        }
                        break;

                    case ActionDescription.ActionType.Transfer:

                        if (lastAction.Data is List<object> itemsToTransfer)
                        {
                            // Reverse the transfer by moving items from the target back to the source
                            foreach (var item in itemsToTransfer)
                            {
                                lastAction.SourceListBox.Items.Add(item);
                                lastAction.TargetListBox.Items.Remove(item);
                            }
                        }
                        break;

                    case ActionDescription.ActionType.Sort:

                        lastAction.TargetListBox.Items.Clear();
                        foreach (var item in lastAction.OriginalOrder)
                        {
                            lastAction.TargetListBox.Items.Add(item);
                        }
                        break;
                }
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            

            if (listEven.SelectedItems.Count > 0 || listOdd.SelectedItems.Count > 0)
            {

                //
                List<object> itemsToRemove = new List<object>();
                ListBox targetListBox = null;

                foreach (var item in listEven.SelectedItems)
                {
                    itemsToRemove.Add(item);
                    targetListBox = listEven;
                }
                foreach (var item in listOdd.SelectedItems)
                {
                    itemsToRemove.Add(item);
                    targetListBox = listOdd;
                }
                //
                listEven.deleteSelectedItems();
                listOdd.deleteSelectedItems();
                listEven.ClearSelected();
                listOdd.ClearSelected();

                // 
                actionStack.Push(new ActionDescription
                {
                    Type = ActionDescription.ActionType.Remove,
                    Data = itemsToRemove,
                    TargetListBox = targetListBox, // You can set this to null for Remove
                });
                //

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
                listOdd.ClearSelected(); // Clear selection in the other ListBox

            }
            else if (selectedListBox == listOdd)
            {
                listEven.BorderStyle = BorderStyle.None;
                listEven.ClearSelected(); // Clear selection in the other ListBox

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

            //
            actionStack.Push(new ActionDescription
            {
                Type = ActionDescription.ActionType.Add,
                Data = textBox1.Text,
                TargetListBox = number % 2 == 0 ? listEven : listOdd,
            });
            //

            textBox1.Clear();



        }

        private void btnOddToEven_Click(object sender, EventArgs e)
        {
            List<object> itemsToTransfer = new List<object>();


            if (listOdd.SelectedItems.Count == 0)
            {
                listOdd.transferOne(listEven);
                itemsToTransfer.Add(listEven.Items[listEven.Items.Count - 1]);

            }
            else
            {
                foreach (var selectedItem in listOdd.SelectedItems)
                {
                    itemsToTransfer.Add(selectedItem);
                }

                listOdd.transferSelectedItems(listEven);
            }
            //
            actionStack.Push(new ActionDescription
            {
                Type = ActionDescription.ActionType.Transfer,
                Data = itemsToTransfer, // Store the selected items
                TargetListBox = listEven, // Store the target ListBox
                SourceListBox = listOdd, // Store the source ListBox
            });
            //
        }

        private void btnOddToEvenAll_Click(object sender, EventArgs e)
        {
            List<object> itemsToTransfer = new List<object>();

            while (listOdd.Items.Count > 0)
            {
                var itemToTransfer = listOdd.Items[0];
                itemsToTransfer.Add(itemToTransfer);
                listOdd.Items.RemoveAt(0);
                listEven.Items.Add(itemToTransfer);
            }

            listOdd.transferAll(listEven);


            actionStack.Push(new ActionDescription
            {
                Type = ActionDescription.ActionType.Transfer,
                Data = itemsToTransfer,
                TargetListBox = listEven,
                SourceListBox = listOdd,
            });
        }

        private void btnEvenToOdd_Click(object sender, EventArgs e)
        {
            List<object> itemsToTransfer = new List<object>();


            if (listEven.SelectedItems.Count == 0)
            {
                listEven.transferOne(listOdd);
                itemsToTransfer.Add(listOdd.Items[listOdd.Items.Count - 1]);

            }
            else
            {
                foreach (var selectedItem in listEven.SelectedItems)
                {
                    itemsToTransfer.Add(selectedItem);
                }

                listOdd.transferSelectedItems(listOdd);
            }
            //
            actionStack.Push(new ActionDescription
            {
                Type = ActionDescription.ActionType.Transfer,
                Data = itemsToTransfer, // Store the selected items
                TargetListBox = listOdd, // Store the target ListBox
                SourceListBox = listEven, // Store the source ListBox
            });
            //
        }

        private void btnEvenToOddAll_Click(object sender, EventArgs e)
        {
            List<object> itemsToTransfer = new List<object>();

            while (listEven.Items.Count > 0)
            {
                var itemToTransfer = listEven.Items[0];
                itemsToTransfer.Add(itemToTransfer);
                listEven.Items.RemoveAt(0);
                listOdd.Items.Add(itemToTransfer);
            }

            listEven.transferAll(listOdd);


            actionStack.Push(new ActionDescription
            {
                Type = ActionDescription.ActionType.Transfer,
                Data = itemsToTransfer,
                TargetListBox = listOdd,
                SourceListBox = listEven,
            });
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
                    // Save the original order
                    List<object> originalOrder = new List<object>();
                    foreach (object item in selectedListBox.Items)
                    {
                        originalOrder.Add(item);
                    }
                    //

                    selectedListBox.SortAndRefreshListBox(true);

                    //
                    actionStack.Push(new ActionDescription
                    {
                        Type = ActionDescription.ActionType.Sort,
                        Data = null, // You can set this to null for Sort
                        TargetListBox = selectedListBox, // Store the target ListBox
                        OriginalOrder = originalOrder, // Store the original order
                    });
                    //
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

                    // Save the original order
                    List<object> originalOrder = new List<object>();
                    foreach (object item in selectedListBox.Items)
                    {
                        originalOrder.Add(item);
                    }
                    //

                    selectedListBox.SortAndRefreshListBox(false);

                    //
                    actionStack.Push(new ActionDescription
                    {
                        Type = ActionDescription.ActionType.Sort,
                        Data = null, // You can set this to null for Sort
                        TargetListBox = selectedListBox, // Store the target ListBox
                        OriginalOrder = originalOrder, // Store the original order
                    });
                    //
                }
            }
        }
    }
}
