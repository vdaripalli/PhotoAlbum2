namespace PhotoAlbum
{
    public class Program
    {
        static int Main(string[] args)
        {
            NinjectCommon.Start();
            var batchProgram = NinjectCommon.GetBatchProgram();
            var result = batchProgram.Run(args);
            return (int)result;
        }
    }
}
