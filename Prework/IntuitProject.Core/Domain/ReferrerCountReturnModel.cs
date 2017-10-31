using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntuitProject.Core.Domain
{
    public class ReferrerCountReturnModel
    {
        public string UrlHost { get; set; }
        public int Count { get; set; }
        public ReferrerCountReturnModel(string urlHost, int count)
        {
            UrlHost = urlHost;
            Count = count;
        }
    }
}
