import example_pb2
import example_pb2_grpc
import grpc
import time

channel = grpc.insecure_channel("localhost:8888") #
stub = example_pb2_grpc.GreeterStub(channel)

# response = stub.SayHello(example_pb2.HelloRequest(name="MyName!"))
# print(response.reply)

# response_future = stub.SayHello.future(example_pb2.HelloRequest(name="MyName!"))
# print(response_future.result().reply)

replies = stub.LotsOfReplies(example_pb2.HelloRequest(name="MyName!"))
time.sleep(5)
for reply in replies:
    print(reply.reply)

nameList = ["Alice", "Bob", "Cindy"]
def GenerateName():
    for name in nameList:
        yield example_pb2.HelloRequest(name=name)
time.sleep(1)
names = GenerateName()
response = stub.LotsOfGreetings(names)
print(response)