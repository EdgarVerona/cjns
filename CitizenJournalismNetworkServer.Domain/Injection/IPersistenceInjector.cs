using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;

namespace CitizenJournalismNetworkServer.Domain.Injection
{

    public interface IPersistenceInjector
    {


        void RegisterRepositories(ContainerBuilder builder);

        void RegisterRepositoriesTest(ContainerBuilder builder);

    }

}
