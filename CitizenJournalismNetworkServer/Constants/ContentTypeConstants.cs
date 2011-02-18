using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CitizenJournalismNetworkServer.Enumerations
{
    public class ContentTypeConstants
    {
        public const string Text = "text";
        public const string Html = "html";
        public const string XHtml = "xhtml";

        public const string Atom = "atom";
        public const string Json = "json";

        public const string Xml = "xml";
    }

    public class AcceptTypeConstants
    {
        public const string Atom = "application/atom+xml;type=entry";
        public const string Json = "application/json";
        public const string Html = "text/html";
        public const string Xml = "application/xml";
    }

    public class HttpContentTypeConstants
    {
        public const string Atom = "application/atom+xml";
        public const string Json = "application/json";
        public const string Html = "text/html";
        public const string Xml = "application/xml";
    }
}