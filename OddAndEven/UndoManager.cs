using OddAndEven;
using System;

public class UndoManager
{
    public UndoManager()
    {
    }

    private Stack<ActionDescription> actionStack = new Stack<ActionDescription>();

    public void PushAction(ActionDescription action)
    {
        actionStack.Push(action);
    }

    public void Undo()
    {
        if (actionStack.Count > 0)
        {
            ActionDescription lastAction = actionStack.Pop();

            switch (lastAction.actionType)
            {
                case ActionDescription.ActionType.Add:
                    UndoAddAction(lastAction);
                    break;

                case ActionDescription.ActionType.Remove:
                    UndoRemoveAction(lastAction);
                    break;

                case ActionDescription.ActionType.Transfer:
                    UndoTransferAction(lastAction);
                    break;

                case ActionDescription.ActionType.Sort:
                    UndoSortAction(lastAction);
                    break;
            }
        }
    }

    private void UndoAddAction(ActionDescription action)
    {
        ListBoxExtensions.removeItem(action.TargetListBox, action.Data[0]);
    }

    private void UndoRemoveAction(ActionDescription action)
    {
        foreach(int item in action.Data)
        {
            ListBoxExtensions.addItemMethod(action.TargetListBox, item);
        }
    }

    private void UndoTransferAction(ActionDescription action)
    {
        foreach (int item in action.Data)
        {
            ListBoxExtensions.transferItem(action.TargetListBox, action.SourceListBox, item);
        }
    }

    private void UndoSortAction(ActionDescription action)
    {
        ListBoxExtensions.sortOriginal(action.TargetListBox, action.OriginalOrder);
    }
}
