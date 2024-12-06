using ElasticSearch_ELK_NEST.Models;
using ElasticSearch_ELK_NEST.Service;
using Microsoft.AspNetCore.Mvc;

namespace ElasticSearch_ELK_NEST.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ISearchService _searchService;
        private static int _maxSize = 1000;
        public HomeController(ISearchService searchService, ILogger<HomeController> logger)
        {
            _logger = logger;
            _searchService = searchService;
        }

        public async Task<IActionResult> Index(
                string searchString = null,
                int pageNumber = 1,
                int pageSize = 20)
        {
            ViewData["CurrentFilter"] = searchString;

            IReadOnlyCollection<AirbnbData> airbnbDatas = new List<AirbnbData>();

            var matchAll = await _searchService.MatchAll(pageNumber, _maxSize);

            if (matchAll != null && matchAll.Documents.Any())
                airbnbDatas = matchAll.Documents;

            _logger.LogInformation($"Searched document count :{airbnbDatas.Count}");
            var pagedList = PaginatedList<AirbnbData>.Create(matchAll.Documents.AsQueryable(), pageNumber, pageSize);

            return View(pagedList);
        }
    }
}
