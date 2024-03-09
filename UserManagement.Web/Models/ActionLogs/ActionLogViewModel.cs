using System;

namespace UserManagement.Web.Models.ActionLogs
{

    public class ActionLogViewModel
    {
        public List<ActionLogItemViewModel> Items { get; set; } = new();
    }


    public class ActionLogItemViewModel
    {
        public long Id { get; set; }

        // foreign key property referencing the User's ID
        public long UserId { get; set; }

        public string ActionType { get; set; } = "";

        public DateTime Timestamp { get; set; } = DateTime.Now;

        public string Notes { get; set; } = "";

        public override string ToString()
        {
            // customize the string representation of the log entry if needed
            return $"{Timestamp}: {ActionType}";
        }
    }
}
