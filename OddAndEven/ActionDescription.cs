using System;
using System.Collections.Generic;
using System.Windows.Forms;

public class ActionDescription
{

    public ActionType actionType {  get; set; }
    public List<int> Data {  get; set; }
    public ListBox TargetListBox { get; set; }
    public List<int> OriginalOrder {  get; set; }
    public ListBox SourceListBox { get; set; }

    public ActionDescription()
	{
       
	}

    public ActionDescription(
        ActionType actionType, List<int> data,
       ListBox sourceListBox, ListBox targetListBox)
    {
        this.actionType = actionType;
        this.Data = data;
        this.SourceListBox = targetListBox;
        this.TargetListBox = sourceListBox;
    }

    public ActionDescription(ActionType actionType,
        ListBox targetListBox, List<int> originalOrder)
    {
        this.actionType = actionType;
        this.TargetListBox = targetListBox;
        this.OriginalOrder = originalOrder;
    }

    public ActionDescription(
        ActionType actionType,
        ListBox sourceListBox,
        List<int> Data,
        ListBox targetListBox
        )
    { 
        this.actionType = actionType;
        this.SourceListBox = sourceListBox;
        this.TargetListBox = targetListBox;
        this.Data = Data;
    }

    public ActionDescription
        (ActionType actionType, List<int> data, ListBox targetListBox)
    {
        this.actionType = actionType;
        this.Data = data;
        this.TargetListBox = targetListBox;
    }

    public enum ActionType
    {
        Add,
        Remove,
        Transfer,
        Sort,
    }

}
