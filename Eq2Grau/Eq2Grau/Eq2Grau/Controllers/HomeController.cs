using Eq2Grau.Models;

using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace Eq2Grau.Controllers {
   public class HomeController : Controller {
      private readonly ILogger<HomeController> _logger;

      public HomeController(ILogger<HomeController> logger) {
         _logger = logger;
      }




      public IActionResult Index(string A, string B, string C) {
         /* Algoritm
          * - A, B, or C are numbers?
          * - if ok,
          *      if A=/=0 (A<>0) (A!=0)
          *         x1 = 
          *         x2 =       
          *      else
          *          send an error message to user
          *   else
          *     send an error message to user
          * 
          */


         // vars. auxiliares
         double auxA = 0, auxB = 0, auxC = 0;



         // 1.
         if (string.IsNullOrWhiteSpace(A) || string.IsNullOrWhiteSpace(B) || string.IsNullOrWhiteSpace(C)) {
            // enviar mensagem para o utilizador
            ViewBag.Mensagem = "The A, B and C parameters can not be empty.";

            // devolver controlo à View
            return View();
         }

         // 1.
         if (!double.TryParse(A, out auxA)) {
            // o A não é número.
            // enviar mensagem para o utilizador
            ViewBag.Mensagem = "The parameter A must be a number.";

            // devolver controlo à View
            return View();
         }

         // 1.
         if (!double.TryParse(B, out auxB)) {
            // o B não é número.
            // enviar mensagem para o utilizador
            ViewBag.Mensagem = "The parameter B must be a number.";

            // devolver controlo à View
            return View();
         }

         // 1.
         if (!double.TryParse(C, out auxC)) {
            // o C não é número.
            // enviar mensagem para o utilizador
            ViewBag.Mensagem = "The parameter C must be a number.";

            // devolver controlo à View
            return View();
         }


         // 2.
         if (auxA == 0) {
            // o A é ZERO.
            // enviar mensagem para o utilizador
            ViewBag.Mensagem = "The parameter A can not be 0 (zero).";

            // devolver controlo à View
            return View();
         }


         // 3.
         double delta = Math.Pow(auxB, 2) - 4 * auxA * auxC;
         // 3.1
         if (delta > 0) {
            string x1 = Math.Round((-auxB + Math.Sqrt(delta)) / 2 / auxA, 2) + "";
            string x2 = Math.Round((-auxB - Math.Sqrt(delta)) / 2 / auxA, 2) + "";
            // enviar mensagem para o utilizador
            ViewBag.Mensagem = "There are two real diferent roots";
            ViewBag.X1 = x1;
            ViewBag.X2 = x2;

            // devolver controlo à View
            return View();
         }

         if (delta == 0) {
            string x = Math.Round((-auxB + Math.Sqrt(delta)) / 2 / auxA, 2) + "";
            // enviar mensagem para o utilizador
            ViewBag.Mensagem = "There are two real roots, but equals";
            ViewBag.X1 = x;
            ViewBag.X2 = x;

            // devolver controlo à View
            return View();
         }

         if (delta < 0) {
            string x1 = Math.Round((-auxB) / 2 / auxA, 2) + " + " + Math.Round(Math.Sqrt(-delta) / 2 / auxA, 2) + " i";
            string x2 = Math.Round((-auxB) / 2 / auxA, 2) + " - " + Math.Round(Math.Sqrt(-delta) / 2 / auxA, 2) + " i";
            // enviar mensagem para o utilizador
            ViewBag.Mensagem = "There are two complex roots";
            ViewBag.X1 = x1;
            ViewBag.X2 = x2;

            // devolver controlo à View
            return View();
         }

         // se chegar aqui, alguma coisa correu muito mal...
         // devolver controlo à View
         return View();
      }




      public IActionResult Privacy() {
         return View();
      }

      [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
      public IActionResult Error() {
         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
      }
   }
}
