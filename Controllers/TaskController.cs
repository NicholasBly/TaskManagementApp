using Microsoft.AspNetCore.Mvc;
using TaskManagementApp.Models;
using TaskManagementApp.Services;

namespace TaskManagementApp.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public async System.Threading.Tasks.Task<IActionResult> Index()
        {
            var tasks = await _taskService.GetAllTasksAsync();
            return View(tasks);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<IActionResult> Create(TaskModel task)
        {
            if (ModelState.IsValid)
            {
                await _taskService.AddTaskAsync(task);
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        public async System.Threading.Tasks.Task<IActionResult> Edit(int id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<IActionResult> Edit(int id, TaskModel task)
        {
            if (id != task.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _taskService.UpdateTaskAsync(task);
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        public async System.Threading.Tasks.Task<IActionResult> Delete(int id)
        {
            await _taskService.DeleteTaskAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}