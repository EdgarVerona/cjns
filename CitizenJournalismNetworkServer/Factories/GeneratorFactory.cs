﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CitizenJournalismNetworkServer.Models;

namespace CitizenJournalismNetworkServer.Factories
{

    public interface IGeneratorFactory
    {
        Generator GetGenerator();
    }

    public class GeneratorFactory : IGeneratorFactory
    {

        public GeneratorFactory()
        {
        }


        public Generator GetGenerator()
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