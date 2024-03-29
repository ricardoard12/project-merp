﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using FrontEnd.ViewModel.Security;
using FrontEnd.ViewModel.Stammdaten.Product;
using LightCore;
using LightCore.Lifecycle;
using WpfApplication1.ViewModel.Security;
using WpfApplication1.ViewModel.Stammdaten.Product;
using IContainer = LightCore.IContainer;


namespace WpfApplication1.DI
{
    public class DIContainer
    {
        private IContainerBuilder _builder;
        private static IContainer _container;

        public DIContainer(bool registInterfaces)
        {
            _builder = new ContainerBuilder();
            _builder.Register<ILoginViewModel>(new LoginViewModel()).ControlledBy<SingletonLifecycle>();
            _builder.Register<IProductViewModel>(new ProductViewModel());
            _container = _builder.Build();
        }

        public static T GetClientLibrarie<T>()
        {
            return _container.Resolve<T>();
        }

        private void Builder()
        {
            
        }

    
    }
}
