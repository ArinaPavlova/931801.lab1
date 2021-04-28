using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab1.Models;
using Lab1.Services;

namespace Lab1.Controllers
{
    public class CalcController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UsingModelCalc()
        {
            Random rand = new Random();
            int value1 = rand.Next(0, 10);
            int value2 = rand.Next(0, 10);
            int add = value1 + value2;
            int sub = value1 - value2;
            int mult = value1 * value2;
            double div = (double)value1 / (double)value2;
            mylist l = new mylist(add,sub,mult,div,value1,value2);

            if (value2 != 0)
            {
                return View(l);
            }
            else
            {
                return View("ZeroErrorCalc");
            }
        }
    
        public IActionResult ViewDataCalc()
        {
        
            Random rand = new Random();
            int value1 = rand.Next(0, 10);
            int value2 = rand.Next(0, 10);
            
            int add = value1 + value2;
            int sub = value1 - value2;
            int mult = value1 * value2;
            double div = (double)value1 / (double)value2;
            
            ViewData["Value1"] = value1;
            ViewData["Value2"] = value2;
            ViewData["add"] = add;
            ViewData["sub"] = sub;
            ViewData["mult"] = mult;
            ViewData["div"] = div;

            if (value2 != 0)
            {
                return View("ViewDataCalc");
            }
            else
            {
                return View("ZeroErrorCalc");
            }
        }

        public IActionResult ViewBagCalc()
        {
            Random rand = new Random();
            int value1 = rand.Next(0, 10);
            int value2 = rand.Next(0, 10);

            ViewBag.Value1 = value1;
            ViewBag.Value2 = value2;

            int add = value1 + value2;
            int sub = value1 - value2;
            int mult = value1 * value2;
            double div = (double)value1 / (double)value2;

            ViewBag.add = add;
            ViewBag.sub = sub;
            ViewBag.mult = mult;
            ViewBag.div = div;

            if (value2 != 0)
            {
                return View("ViewBagCalc");
            }
            else
            {
                return View("ZeroErrorCalc");
            }
        }

        
        public IActionResult ServiceInjectionCalc()
        {
            return View();
        }
    }
}