# dotnetcore-rabbitmq-example

### Setup RabbitMQ

Pull rabbitmq image `docker pull rabbitmq`

Run rabbitmq image `docker run -d -e RABBITMQ_DEFAULT_USER=user -e RABBITMQ_DEFAULT_PASS=password -p 15672:15672 -p 5672:5672 rabbitmq:3-management`