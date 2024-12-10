namespace ElasticSearch_ELK_NEST.Models
{
    public interface IElasticSearchSettings
    {
        public string Url { get; set; }

        public string Index { get; set; }

        public int MaxFetchSize { get; set; }

    }
    public class ElasticSearchSettings : IElasticSearchSettings
    {
        public string Url { get; set; }

        public string Index { get; set; }

        public int MaxFetchSize { get; set; }

    }
}
