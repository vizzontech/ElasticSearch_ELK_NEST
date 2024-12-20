﻿using ElasticSearch_ELK_NEST.Models;
using Nest;

namespace ElasticSearch_ELK_NEST.Service
{
    public interface ISearchService 
    {
        Task<ISearchResponse<AirbnbData>> GetById(string id);
        Task<ISearchResponse<AirbnbData>> GetByPrice(string price);
        Task<ISearchResponse<AirbnbData>> SearchDocumentsByName(int pageNumber, int maxSize, string name);
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

        public async Task<ISearchResponse<AirbnbData>> SearchDocumentsByName(int pageNumber, int maxSize, string name)
        {
            var searchResponse = await _searchClient.SearchAsync<AirbnbData>(s => s
                    .Query(q => q
                           .Match(m => m
                           .Field(f => f.name).Query(name)
                           .Fuzziness (Fuzziness.Auto)
                           )
                        )
                        .From(pageNumber)
                        .Size(maxSize)
                    );

            return searchResponse;
        }

    }
}
