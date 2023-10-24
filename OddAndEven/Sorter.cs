using System;
using System.Collections.Generic;
using System.Windows.Forms; // Import the System.Windows.Forms namespace

namespace OddAndEven
{
    public static class ListBoxExtensions
    {
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

        public static void transferOne(this ListBox senderList, ListBox getterList)
        {
            if (senderList.Items.Count > 0)
            {
                object itemToTransfer = senderList.Items[0];
                senderList.Items.RemoveAt(0);
                getterList.Items.Add(itemToTransfer);
            }
            else
            {
                MessageBox.Show("No items in the list to transfer.");
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
                MessageBox.Show("No items in the list to transfer.");
            }
        }
    }
}