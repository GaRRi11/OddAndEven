using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddAndEven
{
    public class Operation
    {
        public ActionType Action { get; set; }
        public string[] Data { get; set; }

        public Operation(ActionType action, params string[] data)
        {
            Action = action;
            Data = data;
        }
    }
    public enum ActionType
    {
        Add,
        Delete,
        Transfer,
        Sort
    }
}
