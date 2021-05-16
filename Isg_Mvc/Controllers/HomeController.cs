using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Isg_Mvc.Models;

namespace Isg_Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BlogContext _context;

        public HomeController(ILogger<HomeController> logger, BlogContext context)
        {
            _logger = logger;
            _context=context;
        }

        public IActionResult Index()
        {
            var list=_context.Blog.OrderByDescending(x => x.CreateTime).ToList();

            foreach (var blog in list)
            {
                blog.Author=_context.Author.Find(blog.AuthorId);
            }

            return View(list);
        }

        public IActionResult Post(int Id)
        {
            var blog=_context.Blog.Find(Id);
            blog.Author=_context.Author.Find(blog.AuthorId);

            return View(blog);
        }
       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    
        public FileResult Download(string file) {
            byte[] fileBytes = System.IO.File.ReadAllBytes(("~/Content/" + file + ""));
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, file);

        }

    
    }
}
