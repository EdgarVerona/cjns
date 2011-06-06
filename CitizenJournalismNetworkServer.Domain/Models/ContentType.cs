using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CitizenJournalismNetworkServer.Domain.Utilities;

namespace CitizenJournalismNetworkServer.Domain.Models
{
    public class ContentType : DomainEntity
    {

        public string Text { get; set; }

        public string GetAcceptType()
        {
            return UtilityContentType.GetAcceptTypeFromShortTypeCode(this.Text);
        }

    }
}