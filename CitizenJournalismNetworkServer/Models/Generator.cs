﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using CitizenJournalismNetworkServer.Attributes;

namespace CitizenJournalismNetworkServer.Models
{
    public class Generator
    {
        public string Uri { get; set; }

        public string Version { get; set; }

        public string Text { get; set; }
    }
}