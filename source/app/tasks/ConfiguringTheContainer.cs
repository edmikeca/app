﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using app.tasks.startup;
using app.utility.container;
using app.utility.container.basic;
using Container = app.utility.container.basic.Container;

namespace app.tasks
{
  public class ConfiguringTheContainer : IRunAStartupStep
  {
    IProvideStartupServices services;

    public ConfiguringTheContainer(IProvideStartupServices services)
    {
      this.services = services;
    }

    public void run()
    {
      IDictionary<Type, ICreateOneDependency> factories = new Dictionary<Type, ICreateOneDependency>();
      var dependency_factory = new DependencyFactories(factories, StartupItems.Errors.dependency_factory_missing);
      Fetch.container_resolution = () => new Container(dependency_factory, StartupItems.Errors.dependency_creation_error);
    }
  }
}