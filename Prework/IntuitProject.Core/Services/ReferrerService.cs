using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IntuitProject.Api.Domain;
using IntuitProject.Core.Domain;

namespace IntuitProject.Api.Services
{
    public class ReferrerService
    {
        //List of Referrers that have been viewewd
        private static List<Referrer> Referrers { get; set; }
        
        //List of Referral Counts that corresponds to the list of Referrers
        private static List<ReferralCount> ReferralCounts { get; set; }

        public ReferrerService()
        {
            if (Referrers == null || ReferralCounts == null)
            {
            //Constructor to populate List of Referrers and Counts if the lists do not already exist
                Referrers = new List<Referrer>();
                ReferralCounts = new List<ReferralCount>();
                var referrer1 = new Referrer("https://www.google.com/");
                var referrer2 = new Referrer("https://www.facebook.com/");
                var referrer3 = new Referrer("https://www.amazon.com/");
                var referrer4 = new Referrer("https://www.intuit.com/");
                Referrers.Add(referrer1);
                Referrers.Add(referrer2);
                Referrers.Add(referrer3);
                Referrers.Add(referrer4);

                var referralCount1 = new ReferralCount(referrer1);
                referralCount1.Count = 15;
                var referralCount2 = new ReferralCount(referrer2);
                referralCount2.Count = 4;
                var referralCount3 = new ReferralCount(referrer3);
                referralCount3.Count = 12;
                var referralCount4 = new ReferralCount(referrer4);
                referralCount4.Count = 29;
                ReferralCounts.Add(referralCount1);
                ReferralCounts.Add(referralCount2);
                ReferralCounts.Add(referralCount3);
                ReferralCounts.Add(referralCount4);
            }
        }

        public int GetReferralCount(string url)
        {
            var urlDomain = new Uri(url).Host;
            var count = (from referrer in Referrers
                         join counts in ReferralCounts
                         on referrer.Id equals counts.ReferrerId
                         where referrer.UrlHost == urlDomain
                         select (counts.Count)).FirstOrDefault();
            return count;
        }

        public void IncreaseReferralCount(string url)
        {
            var urlDomain = new Uri(url).Host;
            var existingReferrer = Referrers.FirstOrDefault(x => x.UrlHost == urlDomain);
            if (existingReferrer == null)
            {
                CreateReferrer(url);
            }
            else
            {
                IncrementReferralCount(existingReferrer);
            }
        }

        public List<ReferrerCountReturnModel> GetTopThreeReferrers()
        {
            var referrers = (from referrer in Referrers
                             join counts in ReferralCounts
                             on referrer.Id equals counts.ReferrerId
                             orderby counts.Count descending
                             select new ReferrerCountReturnModel(referrer.UrlHost, counts.Count))
                             .Take(3).ToList();
            return referrers;
        }

        private void CreateReferrer(string url)
        {
            var referrer = new Referrer(url);
            Referrers.Add(referrer);
            ReferralCounts.Add(new ReferralCount(referrer));
        }

        private void IncrementReferralCount(Referrer referrer)
        {
            var count = ReferralCounts.FirstOrDefault(x => x.ReferrerId == referrer.Id);
            count.Count++;
        }
    }
}