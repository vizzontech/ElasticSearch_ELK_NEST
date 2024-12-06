using ElasticSearch_ELK_NEST.Models;
using ElasticSearch_ELK_NEST.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
                int pageNumber = 1,
                int pageSize = 10,
                string searchString = null)
        {
            ViewData["SearchString"] = searchString;

            IReadOnlyCollection<AirbnbData> airbnbDatas = new List<AirbnbData>();

            var matchAll = await _searchService.SearchDocumentsByName(pageNumber, _maxSize, searchString);

            if (matchAll != null && matchAll.Documents.Any())
                airbnbDatas = matchAll.Documents;

            _logger.LogInformation($"Searched document count :{airbnbDatas.Count}");
            var pagedList = PaginatedList<AirbnbData>.Create(matchAll.Documents.AsQueryable(), pageNumber, pageSize);

            return View(pagedList);
        }
    }
}
