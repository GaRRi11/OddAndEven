using System;

public class ActionDescription
{
	public ActionDescription()
	{

	}

    public enum ActionType
    {
        Add,
        Remove,
        Transfer,
        Sort,
        RemoveBoth
    }

    public ActionType Type { get; set; }
    public object Data { get; set; }
    public ListBox TargetListBox { get; set; }
    public List<object> OriginalOrder { get; set; } // Add this property
    public ListBox SourceListBox { get; set; }
}
