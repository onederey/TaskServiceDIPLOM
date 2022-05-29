using TaskService.CommonTypes.Classes;

namespace TaskService.Interface.Models
{
    public class TaskDTOViewModel
    {
        public ICollection<TaskDTO>? GetTaskDTOs { get; set; }
    }
}
