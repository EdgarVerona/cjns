using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CitizenJournalismNetworkServer.Attributes;
using CitizenJournalismNetworkServer.Utility;

namespace CitizenJournalismNetworkServer.Models
{
    public class ContentType
    {
        public int Id { get; set; }

        public string Text { get; set; }


        public string GetAcceptType()
        {
            return UtilityContentType.GetAcceptTypeFromShortTypeCode(this.Text);
        }

    }
}