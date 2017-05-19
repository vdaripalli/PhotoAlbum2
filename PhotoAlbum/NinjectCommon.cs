using Ninject;
using PhotoAlbum.Application;

namespace PhotoAlbum
{
    public class NinjectCommon
    {
        private static StandardKernel _kernel;

        /// <summary>
        ///     Starts the application
        /// </summary>
        public static void Start()
        {
            CreateKernel();
        }

        public static IBatchAlbum GetBatchProgram()
        {
            return _kernel.Get<IBatchAlbum>();
        }

        /// <summary>
        ///     Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static void CreateKernel()
        {
            _kernel = new StandardKernel(new NinjectSettings { InjectNonPublic = true });

            RegisterServices(_kernel);
        }

        /// <summary>
        ///     Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IBatchAlbum>().To(typeof(BatchAlbum));
            kernel.Load(new ApplicationInjectionModule());
        }
    }
}
