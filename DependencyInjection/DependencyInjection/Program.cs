using Castle.Windsor;
using System;
using Castle.MicroKernel.Registration;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer();
            container.Register(Component.For<ICompositionRoot>().ImplementedBy<CompositionRoot>());
            container.Register(Component.For<IConsoleWriter>().ImplementedBy<ConsoleWriter>());
            container.Register(Component.For<ISingletonDemo>().ImplementedBy<SingletonDemo>().LifestyleTransient());

            var root = container.Resolve<ICompositionRoot>();
            root.LogMessage("Hello");
            Console.ReadLine();
        }
    }
}
