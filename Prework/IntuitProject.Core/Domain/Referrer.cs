using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntuitProject.Api.Domain
{
    public class Referrer
    {
        //_timesCreated used to auto increment Id field;
        public static int _timesCreated { get; set; }
        public int Id { get; set; }
        public string UrlHost { get; set; }

        public Referrer(string url)
        {
            UrlHost = new Uri(url).Host;
            _timesCreated++;
            Id = _timesCreated;
        }
    }
}