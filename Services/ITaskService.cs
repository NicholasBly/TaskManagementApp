using System.Collections.Generic;
using System.Threading.Tasks; // Keep this for Task<T>

namespace TaskManagementApp.Services
{
    public interface ITaskService
    {
        // Use fully qualified name to avoid ambiguity
        System.Threading.Tasks.Task<List<TaskManagementApp.Models.TaskModel>> GetAllTasksAsync();
        System.Threading.Tasks.Task<TaskManagementApp.Models.TaskModel> GetTaskByIdAsync(int id);
        System.Threading.Tasks.Task<TaskManagementApp.Models.TaskModel> AddTaskAsync(TaskManagementApp.Models.TaskModel task);
        System.Threading.Tasks.Task<TaskManagementApp.Models.TaskModel> UpdateTaskAsync(TaskManagementApp.Models.TaskModel task);
        System.Threading.Tasks.Task DeleteTaskAsync(int id);
        System.Threading.Tasks.Task<List<TaskManagementApp.Models.TaskModel>> GetTasksByPriorityAsync(TaskManagementApp.Models.TaskPriority priority);
    }
}
