using Microsoft.AspNetCore.Mvc;
using StoreFlowEntityFramework.Context;
using StoreFlowEntityFramework.Entities;
using System.Linq;

namespace StoreFlowEntityFramework.Controllers
{
    public class ToDoController : Controller
    {
        private readonly StoreContext _context;

        public ToDoController(StoreContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            _context.Todos.AddRange();
            return View();
        }

        [HttpGet]
        public IActionResult CreateToDo()
        {
            var todos = new List<Todo>
            {
                new Todo {Description="Mail Gönder" ,Status=true,Priority="Birincil"},
                new Todo {Description="Rapor Hazırla" ,Status=true,Priority="İkincil"},
                new Todo {Description="Toplantıya Katıl" ,Status=false,Priority="Birincil"},
            };
            _context.Todos.AddRange(todos);
            _context.SaveChanges();
            return View();
        }


        public IActionResult TodoAggreagatePriority()
        {
            var priorityFirstliyTodo = _context.Todos.
                Where(x => x.Priority == "Birincil").
                Select(y => y.Description).Take(5).
                ToList();

            string result = priorityFirstliyTodo.Aggregate(string.Empty, (acc, desc) => acc + $"<li>{desc}</li>");
            ViewBag.result = result;
            return View();
        }

        public IActionResult IncompleteTask()
        {
            var values = _context.Todos.Where(x => !x.Status).Select(y => y.Description).ToList().Append("Gün sonunda tüm görevleri kontrol etmeyi unutmayın").ToList();
            return View(values);
        }
        public IActionResult NotcompleteTask()
        {
            var values = _context.Todos.Where(x => !x.Status).Select(y => y.Description).ToList().Prepend("Gün Başında tüm görevleri kontrol etmeyi unutmayın").ToList();
            return View(values);
        }

        public IActionResult TodoChunk()
        {
            var values = _context.Todos.Where(x => !x.Status).ToList().Chunk(3).ToList();
            return View(values);
        }

        public IActionResult TodoConcat()
        {
            var values = _context.Todos.Where(x => x.Priority == "Birincil").ToList().Concat(_context.Todos.Where(y => y.Priority == "İkincil").ToList()).ToList();
            return View(values);
        }


        public IActionResult TodoUnion()
        {
            var values = _context.Todos.Where(x => x.Priority == "Birincil").ToList();
            var values2 = _context.Todos.Where(y => y.Priority == "İkincil").ToList();
            var values3 = values.UnionBy(values2,x=>x.Description).ToList();
            return View(values3);
        }

    }
}
