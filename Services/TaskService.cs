using Microsoft.EntityFrameworkCore;
using TaskManagementApp.Data;
using TaskManagementApp.Models;

namespace TaskManagementApp.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _context;

        public TaskService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async System.Threading.Tasks.Task<List<TaskModel>> GetAllTasksAsync()
        {
            return await _context.Tasks
                .OrderByDescending(t => t.Priority)
                .ThenBy(t => t.DueDate)
                .ToListAsync();
        }

        public async System.Threading.Tasks.Task<TaskModel> GetTaskByIdAsync(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async System.Threading.Tasks.Task<TaskModel> AddTaskAsync(TaskModel task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async System.Threading.Tasks.Task<TaskModel> UpdateTaskAsync(TaskModel task)
        {
            _context.Entry(task).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return task;
        }

        public async System.Threading.Tasks.Task DeleteTaskAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }

        public async System.Threading.Tasks.Task<List<TaskModel>> GetTasksByPriorityAsync(TaskPriority priority)
        {
            return await _context.Tasks
                .Where(t => t.Priority == priority)
                .OrderBy(t => t.DueDate)
                .ToListAsync();
        }
    }
}
