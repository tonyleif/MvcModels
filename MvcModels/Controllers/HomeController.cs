using System.Linq;
using System.Web.Mvc;
using MvcModels.Models;
using System.Collections.Generic;
using System;

namespace MvcModels.Controllers
{
    public class HomeController : Controller
    {
        private Person[] personData = {new Person { PersonId = 1, FirstName = "Adam", LastName = "Freeman", Role = Role.Admin},
                                       new Person { PersonId = 2, FirstName = "Jacqui", LastName = "Gryffyth", Role = Role.User},
                                       new Person { PersonId = 3, FirstName = "John", LastName = "Smith", Role = Role.User},
                                       new Person { PersonId = 4, FirstName = "Anne", LastName = "Jones", Role = Role.Guest}
        };

        public ActionResult Index(int id = 1)
        {
            Person dataItem = personData.Where(p => p.PersonId == id).First();
            return View(dataItem);
        }

        public ActionResult CreatePerson()
        {
            return View(new Person());
        }

        [HttpPost]
        public ActionResult CreatePerson(Person model)
        {
            return View("Index", model);
        }

        public ActionResult DisplaySummary([Bind(Prefix = "HomeAddress", Exclude = "Country")] AddressSummary summary)
        {
            return View(summary);
        }

        //public ActionResult Names(string[] names)
        //{
        //    names = names ?? new string[0];
        //    return View(names);
        //}

        public ActionResult Names(IList<string> names)
        {
            names = names ?? new List<string>();
            return View(names);
        }

        //public ActionResult Address(IList<AddressSummary> addresses)
        //{
        //    addresses = addresses ?? new List<AddressSummary>();
        //    return View(addresses);
        //}

        //public ActionResult Address()
        //{
        //    IList<Address> addresses = new List<Address>();
        //    //UpdateModel(addresses);
        //    UpdateModel(addresses, new FormValueProvider(ControllerContext));
        //    return View(addresses);
        //}

        public ActionResult Address()
        {
            IList<AddressSummary> addresses = new List<AddressSummary>();
            //UpdateModel(addresses);
            UpdateModel(addresses, new FormValueProvider(ControllerContext));
            return View(addresses);
        }

        //public ActionResult Address(FormCollection formData)
        //{
        //    IList<Address> addresses = new List<Address>();
        //    //try
        //    //{
        //    //    UpdateModel(addresses, formData);
        //    //}
        //    //catch (InvalidOperationException ex)
        //    //{
        //    //    //Provide feedback to user
        //    //}
        //    if (TryUpdateModel(addresses))
        //    {
        //        //proceed as normal
        //    }
        //    else
        //    {
        //        //Provide feedback to user
        //    }

        //    return View(addresses);
        //}
    }


}