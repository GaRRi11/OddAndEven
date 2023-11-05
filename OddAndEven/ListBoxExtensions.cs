using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OddAndEven
{
    public static class ListBoxExtensions
    {

        private const string emptyListWarningMessage = "No items in the list to transfer.";
        private static UndoManager undoManager = new UndoManager();


        private static List<int> checkAndCast(ListBox listBox)
        {

            List<int> list = new List<int>();

            foreach (var item in listBox.Items)
            {
                if (item is int numericItem)
                {
                    list.Add(numericItem);
                }
                else if (item is string numericString && int.TryParse(numericString, out int parsedValue))
                {
                    list.Add(parsedValue);
                }
                else
                {
                    // Add some debugging information to identify items that couldn't be parsed.
                    Console.WriteLine($"Could not parse item: {item}");
                }
            }

            return list;
        }


        public static void SortAndRefreshListBox(this ListBox listBox, bool ascending)
        {

            List<int> numbers = new List<int>();
            List<int> originalOrder = new List<int>();
            //originalOrder = checkAndCast(listBox);
            //numbers = checkAndCast(listBox);

            foreach (object item in listBox.Items)
            {
                if (item != null && int.TryParse(item.ToString(), out int number))
                {
                    numbers.Add(number);
                    originalOrder.Add(number);
                }
            }


            if (numbers.Count != 0)
            {
                if (ascending)
                {
                    numbers.Sort();
                }
                else
                {
            
                    numbers.Sort((x, y) => y.CompareTo(x));
                }
            }
            else
            {
                return;
            }

            listBox.Items.Clear();

            foreach (int number in numbers)
            {
                listBox.Items.Add(number);
            }

            ActionDescription action = new ActionDescription(
                ActionDescription.ActionType.Sort,
                listBox, //romeli listboxia eg 
                originalOrder
                );

            undoManager.PushAction(action);

        }


        public static void addItem(this ListBox listBox,int item)
        {
            listBox.Items.Add(item);
            List<int> itemAdded = new List<int>();
            itemAdded.Add(item);


            ActionDescription action = ActionDescription(
                ActionDescription.ActionType.Add,
                itemAdded, //cifri
                listBox
                );

            undoManager.PushAction(action);

        }

        public static void deleteSelectedItems(this ListBox listBox)
        {
            List<int> itemsToRemove = new List<int>();

            if (listBox != null && listBox.SelectedItems.Count > 0)
            {
                foreach (var item in listBox.SelectedItems)
                {
                    if (item != null && int.TryParse(item.ToString(), out int number))
                    {
                        itemsToRemove.Add(number);
                    }
                }
            }


            foreach (var item in itemsToRemove)
            {
                listBox.Items.Remove(item);
            }

            ActionDescription action = new ActionDescription(
                ActionDescription.ActionType.Remove,
                itemsToRemove, //wasashleli cifrebis listi
                listBox
                );

            undoManager.PushAction(action);

        }

        public static void transferSelectedItems(this ListBox sourceList, ListBox targetList)
        {
            List<int> itemsToTransfer = new List<int>();

            foreach (var item in sourceList.SelectedItems) {

                if (item is int numericItem)
                {
                    itemsToTransfer.Add(numericItem);
                    targetList.Items.Add(numericItem);
                }
                else if (item is string numericString && int.TryParse(numericString, out int parsedValue))
                {
                    itemsToTransfer.Add(parsedValue);
                    targetList.Items.Add(parsedValue);
                }
            }


            while (sourceList.SelectedItems.Count > 0)
            {
                sourceList.Items.Remove(sourceList.SelectedItems[0]);
            }

            ActionDescription action = new ActionDescription(
                ActionDescription.ActionType.Transfer,
                itemsToTransfer, //gadasatani itemebis listi
                sourceList,
                targetList
                );

            undoManager.PushAction(action);


        }

        public static void transferOne(this ListBox sourceList, ListBox targetList)
        {
            if (sourceList.Items.Count == 0)
            {
                MessageBox.Show(emptyListWarningMessage);
                return;
            }

            List<int> itemsToTransfer = new List<int>();

            int itemToTransfer = (int) sourceList.Items[0];
            itemsToTransfer.Add(itemToTransfer);
            sourceList.Items.RemoveAt(0);
            targetList.Items.Add(itemToTransfer);

            ActionDescription action = new ActionDescription(
                ActionDescription.ActionType.Transfer,
                itemsToTransfer, //gadasatani itemebis listi
                sourceList,
                targetList
                );

            undoManager.PushAction(action);

        }

        public static void transferAll(this ListBox sourceList, ListBox targetList)
        {
            List<int> itemsToTransfer = new List<int>();

            itemsToTransfer = checkAndCast(sourceList);

            while (sourceList.Items.Count > 0)
            {
                targetList.Items.Add(sourceList.Items[0]);
                sourceList.Items.RemoveAt(0);
            }

            ActionDescription action = new ActionDescription(
                ActionDescription.ActionType.Transfer,
                itemsToTransfer,
                sourceList,
                targetList
            ));

            undoManager.PushAction(action);


        }

        public static void undo(this Form form) {

            undoManager.Undo();

        }

    }
}