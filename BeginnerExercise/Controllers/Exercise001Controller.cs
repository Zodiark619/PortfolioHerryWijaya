using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.Arm;

namespace BeginnerExercise.Controllers
{
    public class Exercise001Controller : Controller
    {
       //  string  path = Directory.GetCurrentDirectory()+"Exercise001.txt";
         string  path = "Exercise001.txt";
        List<string> fortuneCookies = new List<string>();
        public IActionResult Index()
        {
           
            return View();
        }
        public IActionResult RandomFortuneCookie()
        {
            using StreamReader textIn = new(new FileStream(path, FileMode.Open, FileAccess.Read));

            while (textIn.Peek() != -1)
            {
                string row = textIn.ReadLine() ?? "";
                //string[] columns = row.Split(Sep);

                fortuneCookies.Add(row);

            }

    //        var counter = fortuneCookies.IndexOf(ViewBag.FortuneCookie);


            var random = new Random();
     //       var value = 0;
      //      do
     //       {
          var       value = random.Next(fortuneCookies.Count());

     //       } while (counter==value);


          

         

  
            ViewBag.FortuneCookie= fortuneCookies[value];
            return View(nameof(Index));
        }
    }
}
