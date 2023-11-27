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

    public bool actionStackEmpty() {
        return actionStack.Count == 0;
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
        ListBoxExtensions.addItemUndoer(action.TargetListBox, action.Data);
    }

    private void UndoTransferAction(ActionDescription action)
    {
        ListBoxExtensions.transferItem(action.TargetListBox, action.SourceListBox, action.Data);
    }

    private void UndoSortAction(ActionDescription action)
    {
        ListBoxExtensions.sortOriginal(action.TargetListBox, action.OriginalOrder);
    }
}
