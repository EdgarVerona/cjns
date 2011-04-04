using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CitizenJournalismNetworkServer.Domain.Models;

namespace CitizenJournalismNetworkServer.Domain.Factories
{

    public interface IGeneratorFactory
    {
        Generator CreateGenerator();
    }

    public class GeneratorFactory : IGeneratorFactory
    {

        public GeneratorFactory()
        {
        }


        public Generator CreateGenerator()
        {
            return new Generator()
            {
                Text = "CJNS ASP.NET MVC 1.0",
                Uri = "http://cjns.github.com",
                Version = "1.0"
            };
        }
    }
}