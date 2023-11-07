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
        action.TargetListBox.Items.Remove(action.Data[0]);
    }

    private void UndoRemoveAction(ActionDescription action)
    {
        if (action.Data is List<int> itemsToRemove)
        {
            foreach (var item in itemsToRemove)
            {
                action.TargetListBox.Items.Add(item);
            }
        }
    }

    private void UndoTransferAction(ActionDescription action)
    {
        if (action.Data is List<int> itemsToTransfer)
        {
            foreach (var item in itemsToTransfer)
            {
                action.SourceListBox.Items.Add(item);
                action.TargetListBox.Items.Remove(item);
            }
        }
    }

    private void UndoSortAction(ActionDescription action)
    {
        action.TargetListBox.Items.Clear();
        foreach (var item in action.OriginalOrder)
        {
            action.TargetListBox.Items.Add(item);
        }
    }
}
