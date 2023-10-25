using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OddAndEven
{
    public static class ListBoxExtensions
    {

        private const string emptyListWarningMessage = "No items in the list to transfer.";

        public static void SortAndRefreshListBox(this ListBox listBox, bool ascending)
        {
            List<int> numbers = new List<int>();

            foreach (object item in listBox.Items)
            {
                if (item != null && int.TryParse(item.ToString(), out int number))
                {
                    numbers.Add(number);
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
        }

        public static void transferSelectedItems(this ListBox sourceList, ListBox targetList)
        {
            for (int i = 0; i < sourceList.SelectedItems.Count; i++)
            {
                targetList.Items.Add(sourceList.SelectedItems[i]);
            }

            while (sourceList.SelectedItems.Count > 0)
            {
                sourceList.Items.Remove(sourceList.SelectedItems[0]);
            }
        }

        public static void transferOne(this ListBox sourceList, ListBox targetList)
        {
            if (sourceList.Items.Count > 0)
            {
                object itemToTransfer = sourceList.Items[0];
                sourceList.Items.RemoveAt(0);
                targetList.Items.Add(itemToTransfer);
            }
            else
            {
                MessageBox.Show(emptyListWarningMessage);
                return;
            }


        }

        public static void transferAll(this ListBox senderList, ListBox getterList)
        {
            while (senderList.Items.Count > 0)
            {
                getterList.Items.Add(senderList.Items[0]);
                senderList.Items.RemoveAt(0);
            }

            if (getterList.Items.Count == 0)
            {
                MessageBox.Show(emptyListWarningMessage);
            }
        }
    }
}