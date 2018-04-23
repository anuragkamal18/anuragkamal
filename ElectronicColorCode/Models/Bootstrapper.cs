using ElectronicColorCode.Controllers;
using ElectronicColorCode.Helper;
using ElectronicColorCode.Interface;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity.Mvc4;

namespace ElectronicColorCode.Models
{
    public class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            return container;
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<IOhmValueCalculator, OhmValueCalculator>();
            container.RegisterType<IController, OhmValueController>();
            MvcUnityContainer.Container = container;
            return container;
        }
    }
}