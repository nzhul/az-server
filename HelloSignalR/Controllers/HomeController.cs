using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HelloSignalR.Models;
using Microsoft.AspNetCore.SignalR;

namespace HelloSignalR.Controllers
{
    public class HomeController : Controller
    {
        IHubContext<Chat> _chatHubContext;

        public HomeController(IHubContext<Chat> chatHubContext)
        {
            _chatHubContext = chatHubContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Call()
        {
            _chatHubContext.Clients.All.InvokeAsync("Send", "zzzzz");
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
