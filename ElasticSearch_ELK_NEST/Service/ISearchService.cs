using ElasticSearch_ELK_NEST.Models;
using Nest;

namespace ElasticSearch_ELK_NEST.Service
{
    public interface ISearchService 
    {
        Task<ISearchResponse<AirbnbData>> GetById(string id);
        Task<ISearchResponse<AirbnbData>> GetByPrice(string price);
        Task<ISearchResponse<AirbnbData>> MatchAll(int pageNumber, int maxSize);
    }

    public class SearchService :  ISearchService
    {
        private IElasticClient _searchClient;
        public SearchService(IElasticClient searchClient)
        {
            _searchClient = searchClient;
        }

        public async Task<ISearchResponse<AirbnbData>> GetById(string id)
        {
            var searchResponse = await _searchClient.SearchAsync<AirbnbData>(s => s
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.id)
                        .Query(id)
                        .Fuzziness(Fuzziness.Auto)
                    )
                )
            );

            return searchResponse;
        }

        public async Task<ISearchResponse<AirbnbData>> GetByPrice(string price)
        {
            var searchResponse = await _searchClient.SearchAsync<AirbnbData>(s => s
                    .Query(q => q
                           .Match(m => m
                           .Field(f => f.price).Query(price)
                           )
                        )
                    );

            return searchResponse;
        }

        public async Task<ISearchResponse<AirbnbData>> MatchAll(int pageNumber, int maxSize)
        {
            var searchResponse = await _searchClient.SearchAsync<AirbnbData>(s => s
                    .Query(q => q
                           .MatchAll(m => m)
                        )
                        .From(pageNumber)
                        .Size(maxSize)
                    );

            return searchResponse;
        }

    }
}
