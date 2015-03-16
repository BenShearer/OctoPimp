using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Octopus.Client;
using Octopus.Client.Model;

namespace OctoPimp.Web.Controllers
{
    public class VariableSetController : Controller {

        private OctopusClient Client;
        private OctopusRepository Repo;
        private string Endpoint;
        private string ApiKey;
        public VariableSetController() {

            Endpoint = ConfigurationManager.AppSettings["Octopus.Api.Endpoint"];
            ApiKey = ConfigurationManager.AppSettings["Octopus.Api.Key"];

            Client = new OctopusClient(new OctopusServerEndpoint(Endpoint,ApiKey));
            Repo = new OctopusRepository(new OctopusServerEndpoint(Endpoint, ApiKey));
            
        }

        public ActionResult Index()
        {
            return View();
        }



        private 

    }
}
