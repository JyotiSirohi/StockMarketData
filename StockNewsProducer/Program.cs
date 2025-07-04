using Confluent.Kafka;

class Producer
{
    public static async Task Main()
    {
        var config = new ProducerConfig
        {
            BootstrapServers = "localhost:9092"
        };

        var stockNews = new Dictionary<string, List<string>>
        {
            ["stock.aapl"] = new()
            {
                "Apple launches new AI-powered iPhone!",
                "AAPL stock rises after earnings report."
            },
            ["stock.msft"] = new()
            {
                "Microsoft enters quantum computing race.",
                "MSFT stock spikes on Azure growth."
            },
            ["stock.tsla"] = new()
            {
                "Tesla unveils next-gen EV battery.",
                "TSLA stock falls 2% after recall news."
            }
        };

        using var producer = new ProducerBuilder<Null, string>(config).Build();

        foreach (var topic in stockNews.Keys)
        {
            foreach (var news in stockNews[topic])
            {
                await producer.ProduceAsync(topic, new Message<Null, string> { Value = news });
                Console.WriteLine($"[Producer] Sent to {topic}: {news}");
                await Task.Delay(1000); // simulate delay between messages
            }
        }

        producer.Flush(TimeSpan.FromSeconds(5));
    }
}
