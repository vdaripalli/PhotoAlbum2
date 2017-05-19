using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using Ninject.Extensions.Conventions;

namespace PhotoAlbum.Application
{
    public class ApplicationInjectionModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind(scanner => scanner
                .FromThisAssembly()
                .SelectAllClasses()
                .BindAllInterfaces()
                .Configure(b => b.InTransientScope()));
        }
    }
}
