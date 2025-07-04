using Confluent.Kafka;

class Consumer
{
    public static void Main()
    {
        var config = new ConsumerConfig
        {
            BootstrapServers = "localhost:9092",
            GroupId = "stock-news-consumer-group",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        var topics = new[] { "stock.aapl", "stock.msft", "stock.tsla" };

        using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();
        consumer.Subscribe(topics);

        Console.WriteLine("[Consumer] Listening for stock news...");

        try
        {
            while (true)
            {
                var result = consumer.Consume(CancellationToken.None);
                Console.WriteLine($"[Consumer] {result.Topic}: {result.Message.Value}");
            }
        }
        catch (OperationCanceledException)
        {
            consumer.Close();
        }
    }
}
