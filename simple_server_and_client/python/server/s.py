from __future__ import print_function
from concurrent.futures import ThreadPoolExecutor
import count_pb2
import count_pb2_grpc
import time
import grpc


class CountServicer(count_pb2_grpc.CountNumServicer):
    def QuickCount(self, request, context):
        ans = request.numa + request.numb
        return count_pb2.CountReply(reNum=ans)
    

def serve():
    aexecutor = ThreadPoolExecutor(max_workers=10)
    server = grpc.server(aexecutor)
    count_pb2_grpc.add_CountNumServicer_to_server(CountServicer(), server)
    server.add_insecure_port("[::]:5001")
    print("Server Start!")
    server.start()
    server.wait_for_termination()
    print("Server End!")

if __name__ == '__main__':
    serve()