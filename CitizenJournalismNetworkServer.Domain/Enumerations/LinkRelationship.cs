﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CitizenJournalismNetworkServer.Domain.Enumerations
{
    public enum LinkRelationship
    {
        None,
        Alternate,
        Related,
        Self,
        Enclosure,
        Via
    }
}