using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace UserManagement.Models
{
    public class ActionLog
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
