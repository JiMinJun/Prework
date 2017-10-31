using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntuitProject.Api.Domain
{
    public class ReferralCount
    {
        //_timesCreated used to auto increment Id field;
        private static int _timesCreated {get;set;}
        public int Id { get; set; }
        public int ReferrerId { get; set; }
        public int Count { get; set; }
        public ReferralCount(Referrer referrer)
        {
            _timesCreated++;
            Id = _timesCreated;
            ReferrerId = referrer.Id;
            Count = 1;
        }
    }
}