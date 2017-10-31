using IntuitProject.Api.Services;
using IntuitProject.Core.DTOs;
using System.Web.Http;
using System.Web.Http.Cors;

namespace IntuitProject.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods:"*")]
    [AllowAnonymous]
    [RoutePrefix("api/Referrers")]
    public class ReferrersController : ApiController
    {
        private static ReferrerService _referrerService { get; set; }
        public ReferrerService ReferrerService
        {
            get
            {
                if (_referrerService == null)
                {
                    _referrerService = new ReferrerService();
                }
                return _referrerService;
            }
            set
            {
                _referrerService = value;
            }
        }

        /// <summary>
        /// Get Count of Referrer
        /// </summary>
        /// <param name="url"></param>
        /// <returns>Number of times the domain has been seen</returns>
        [HttpGet]
        [Route("{url}/Count")]
        public IHttpActionResult GetCount(string url)
        {
            var decodedUrl = System.Web.HttpUtility.UrlDecode(url);
            var result = ReferrerService.GetReferralCount(decodedUrl);
            return Ok(result);
        }

        /// <summary>
        /// Get Top Three Referrers
        /// </summary>
        /// <param></param>
        /// <returns>Top three referrers with the highest view count</returns>
        [HttpGet]
        [Route("Top3")]
        public IHttpActionResult GetTopThreeReferrers()
        {
            var results = ReferrerService.GetTopThreeReferrers();
            return Ok(results);
        }

        /// <summary>
        /// Increases the number of times a domain has been viewed
        /// </summary>
        /// <param name="url">url name</param>
        [HttpPost]
        [Route("IncreaseCount")]
        public IHttpActionResult IncreaseReferralCount(ReferrerDto referrer)
        {
            ReferrerService.IncreaseReferralCount(referrer.Url);
            return Ok();
            //return HttpStatusCode.NoContent;
        }

    }
}
