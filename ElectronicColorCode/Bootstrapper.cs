using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using ElectronicColorCode.Interface;
using ElectronicColorCode.Helper;
using ElectronicColorCode.Controllers;
using ElectronicColorCode.Models;

namespace ElectronicColorCode
{
  public static class Bootstrapper
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

      // register all your components with the container here
      // it is NOT necessary to register your controllers

      // e.g. container.RegisterType<ITestService, TestService>();    
      //RegisterTypes(container);
      container.RegisterType<IOhmValueCalculator, OhmValueCalculator>();
      container.RegisterType<IController, OhmValueController>();
      container.RegisterType<OhmCalculator>();
      MvcUnityContainer.Container = container;

      return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
    
    }
  }
}