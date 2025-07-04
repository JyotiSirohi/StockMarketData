# 📈 Stock Market News Kafka App (.NET + Docker)

This is a simple real-time **Stock Market News** application built with **.NET console apps** using **Kafka** as the message broker.

The system includes:
- 📰 A **Producer** app that sends stock news updates
- 📥 A **Consumer** app that listens for real-time updates on specific stock topics
- 🐳 Kafka + Zookeeper setup using Docker

---

## 🚀 How to Run the Project

> Run all commands from the **project root** (`StockMarketData/`)
> Create Kafka Topic Manually
    docker exec stockmarketdata-kafka-1 kafka-topics \
      --bootstrap-server localhost:9092 \
      --create --topic stock.aapl --partitions 1 --replication-factor 1

    docker exec stockmarketdata-kafka-1 kafka-topics \
      --bootstrap-server localhost:9092 \
      --create --topic stock.msft --partitions 1 --replication-factor 1
    
    docker exec stockmarketdata-kafka-1 kafka-topics \
      --bootstrap-server localhost:9092 \
      --create --topic stock.tsla --partitions 1 --replication-factor 1
> Run Producer and Consumer

This app listens to all stock.* topics and prints incoming messages.

