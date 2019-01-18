using System;
using System.Linq;
using System.Web.Mvc;
using StackExchange.Precompilation;

namespace Sitecorium.Helix.ViewCompilation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Home");
        }

        private void SwitchToStackExchange()
        {
            ViewEngines.Engines.Clear();
            var assemblyList = AppDomain.CurrentDomain.GetAssemblies();
            ViewEngines.Engines.Insert(0, new PrecompiledViewEngine(assemblyList.ToArray()));
        }

        private void SwitchToRazorGenerator()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
            Sitecorium.Feature.FeatureA.RazorGen.RazorGeneratorMvcStart.Start();
            Sitecorium.Feature.FeatureB.RazorGen.RazorGeneratorMvcStart.Start();
        }

        public ActionResult FeatureARazorGen()
        {
            SwitchToRazorGenerator();
            return RedirectToAction("Index", "RazorGenFeatureA");
        }

        public ActionResult FeatureBRazorGen()
        {
            SwitchToRazorGenerator();
            return RedirectToAction("Index", "RazorGenFeatureB");
        }

        public ActionResult FeatureAStackExchange()
        {
            SwitchToStackExchange();
            return RedirectToAction("Index", "StackExchangeFeatureA");
        }

        public ActionResult FeatureBStackExchange()
        {
            SwitchToStackExchange();
            return RedirectToAction("Index", "StackExchangeFeatureB");
        }
    }
}