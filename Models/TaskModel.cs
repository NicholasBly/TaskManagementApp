using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManagementApp.Models
{
    public enum TaskPriority
    {
        Low,
        Medium,
        High,
        Critical
    }

    public class TaskModel // Renamed to TaskModel to avoid conflicts
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters")]
        public string Title { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters")]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Due Date")]
        public DateTime? DueDate { get; set; }

        [Required]
        public TaskPriority Priority { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
