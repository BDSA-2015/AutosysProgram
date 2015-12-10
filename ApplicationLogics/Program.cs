using ApplicationLogics.AutosysServer;
using ApplicationLogics.AutosysServer.Mapping;

namespace ApplicationLogics
{
    public class Program
    {
        private static void Main(string[] args)
        {
            AutoMapperConfigurator.Configure(); //Initialize AutoMapper
            var mainHandler = new MainHandler();
        }
    }
}