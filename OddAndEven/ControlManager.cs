using System;

public class ControlManager
{
    public ControlManager()
    { }


    public Button CreateButton(string name, string text, Point point, Size size)
    {
        Button button = new Button();
        button.Name = name;
        button.Text = text;
        button.Size = size;
        button.Location = point;
        return button;
    }

    public ListBox createListBox(string name, Point point, Size size)
    {
        ListBox listBox = new ListBox();
        listBox.Name = name;
        listBox.Size = size;
        listBox.Location = point;
        listBox.SelectionMode = SelectionMode.MultiExtended;
        return listBox;
    }

    public TextBox createTextBox(string name, Point point, Size size)
    {
        TextBox textBox = new TextBox();
        textBox.Name = name;
        textBox.Size = size;
        textBox.Location = point;
        textBox.Multiline = true;
        return textBox;
    }

}
