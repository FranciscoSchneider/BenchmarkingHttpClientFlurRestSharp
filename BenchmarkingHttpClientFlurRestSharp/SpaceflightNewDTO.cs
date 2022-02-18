namespace BenchmarkingHttpClientFlurRestSharp
{
    public sealed class SpaceflightNewDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public string NewsSite { get; set; }
        public string Summary { get; set; }
        public DateTime PublishedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Featured { get; set; }
        public IEnumerable<EventDTO> Events { get; set; }
        public IEnumerable<LaunchDTO> Launches { get; set; }

        public sealed class EventDTO
        {
            public int Id { get; set; }
            public string Provider { get; set; }
        }

        public sealed class LaunchDTO
        {
            public Guid Id { get; set; }
            public string Provider { get; set; }
        }
    }
}
