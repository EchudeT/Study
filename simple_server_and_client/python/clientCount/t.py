import link_pb2
import link_pb2_grpc
import grpc
import random
import numpy as np
import time

channel = grpc.insecure_channel("localhost:8888") 
stub = link_pb2_grpc.CountStub(channel)

replies = stub.LotsofCounts(link_pb2.CountRequest1(num_a=3,num_b=2,opt=1))

for reply in replies:
    print(reply)

num = np.random.randint(1, 10, (2, 100))

# def GenerateNum():
#     for i in range(10):
#         yield link_pb2.CountRequest1(num_a=np.random.randint(1, 9),num_b=np.random.randint(1, 9),opt=1)


def GenerateNum():
    for i in range(10):
        yield link_pb2.CountRequest1(num_a=num[0, i],num_b=num[1, i],opt=3)

nums = GenerateNum()

replies2 = stub.QuickCounts(nums)

print(replies2)

cnt = 0
for reply2 in replies2:
    print("{} + {} = {}".format(str(num[0,cnt]),str(num[1,cnt]),str(reply2)))
    cnt=cnt+1
    
