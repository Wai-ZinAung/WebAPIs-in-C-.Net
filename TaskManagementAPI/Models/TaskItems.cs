using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagementAPI.Models
{
    [Table("TaskItems")]
    public class TaskItems
    {
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required, MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public bool IsCompleted { get; set; } = false;

        // Use DateTimeOffset instead of DateTime to keep timezone info
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    }
}