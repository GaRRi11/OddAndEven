using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OddAndEven
{
    public static class ListBoxExtensions
    {

        private const string emptyListWarningMessage = "No items in the list to transfer.";
        private const string unknownDataTypeMessage = "Unknown data type detected.";
        private const string noOperationsToUndoMessage = "No operations found to undo";


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
                else {
                    MessageBox.Show(unknownDataTypeMessage);
                }
            }

            return list;
        }

        private static List<int> checkAndCastSelected(ListBox listBox)
        {

            List<int> list = new List<int>();

            foreach (var item in listBox.SelectedItems)
            {
                if (item is int numericItem)
                {
                    list.Add(numericItem);
                }
                else
                {
                    MessageBox.Show(unknownDataTypeMessage);
                }
            }

            return list;
        }

        private static void RefreshListBox(ListBox listBox, List<int> numbers)
        {
            listBox.Items.Clear();
            foreach (int number in numbers)
            {
                listBox.Items.Add(number);
            }
        }
        private static void SortNumbers(List<int> numbers, bool ascending)
        {
            numbers.Sort();
            if (!ascending)
            {
                numbers.Reverse();
            }
        }

        public static void removeItem(this ListBox listBox, int item)
        {
            listBox.Items.Remove(item);
        }

        public static void addItemUndoer(this ListBox listBox, List<int> items)
        {
            foreach (int item in items)
            {
                listBox.Items.Add(item);
            }
        }

        public static void sortOriginal(ListBox listbox, List<int> originalOrder)
        {
            listbox.Items.Clear();
            foreach (int number in originalOrder)
            {
                listbox.Items.Add(number);
            }
        }

        public static void transferItem(ListBox sourceList, ListBox targetList, List<int> items)
        {
            foreach (int item in items)
            {
                targetList.Items.Add(item);
                sourceList.removeItem(item);
            }
        }


        public static void SortAndRefreshListBox(this ListBox listBox, bool ascending)
        {
            List<int> numbers = checkAndCast(listBox);
            List<int> originalOrder = checkAndCast(listBox);


            if (numbers.Count != 0)
            {
                SortNumbers(numbers, ascending);
                RefreshListBox(listBox, numbers);
                ActionDescription action = new ActionDescription(
                    ActionDescription.ActionType.Sort,
                    listBox, //romeli listboxia eg 
                    originalOrder
                    );

                undoManager.PushAction(action);
            }
            else
            {
                return;
            }

        }


        public static void addItem(this ListBox listBox, int item)
        {
            listBox.Items.Add(item);
            List<int> itemAdded = new List<int>();
            itemAdded.Add(item);

            ActionDescription action = new ActionDescription(
                ActionDescription.ActionType.Add,
                itemAdded, //cifri
                listBox
                );

            undoManager.PushAction(action);

        }


        public static void deleteSelectedItems(this ListBox listBox)
        {
            List<int> itemsToRemove = new List<int>();

            if (listBox.SelectedItems.Count > 0)
            {
                itemsToRemove = checkAndCastSelected(listBox);
            }

            foreach (int item in itemsToRemove)
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

            itemsToTransfer = checkAndCastSelected(sourceList);
            foreach (int item in itemsToTransfer)
            {
                targetList.Items.Add(item);
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
            List<int> itemsToTransfer = checkAndCast(sourceList);
            int itemToTransfer = 0;
            if (itemsToTransfer.Count > 0)
            {
                itemToTransfer = itemsToTransfer[0];
                targetList.Items.Add(itemToTransfer);
                sourceList.Items.Remove(itemToTransfer);
            }


            ActionDescription action = new ActionDescription(
                ActionDescription.ActionType.Transfer,
                new List<int> { itemToTransfer },  // Items to transfer
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
            );

            undoManager.PushAction(action);

        }

        public static void undo(this Form form)
        {
            if (undoManager.actionStackEmpty())
            {
                MessageBox.Show(noOperationsToUndoMessage);
                return;
            }
            else
            {
                undoManager.Undo();
            }
        }

    }
}