using Grpc.Core;
using CountPack;
using System.Runtime.InteropServices.Marshalling;


try
{
    Grpc.Core.Server server = new Grpc.Core.Server(new[] {new
        Grpc.Core.ChannelOption(Grpc.Core.ChannelOptions.SoReuseport, 0)})
    {
        Services = { Count.BindService(new CountService()) },
        Ports = { new Grpc.Core.ServerPort("0.0.0.0", 8888,
                    Grpc.Core.ServerCredentials.Insecure) }
    };
    server.Start();
    Console.WriteLine("Service Start!");
    Console.ReadLine();
    Console.WriteLine("Service End!");
    server.ShutdownAsync().Wait();
}
catch(Exception ex)
{
    Console.WriteLine(ex.ToString());
}

class CountService: Count.CountBase
{
    public override async Task LotsofCounts(CountRequest1 request1,
        Grpc.Core.IServerStreamWriter<CountReply> response1,
        Grpc.Core.ServerCallContext context1)
    {
        Console.WriteLine($"MultiCounts Start!");
        int ans = 0;
        switch (request1.Opt)
        {
            case 1: ans = request1.NumA + request1.NumB; break;
            case 2: ans = request1.NumA - request1.NumB; break;
            case 3: ans = request1.NumA * request1.NumB; break;
            case 4: ans = request1.NumA / request1.NumB; break;
        }

        var reply = new CountReply()
        {
            ReNum = ans
        };
        await Task.Delay(50);
        await response1.WriteAsync(reply);
        Console.WriteLine($"MultiCounts Exit!");
    }

    public override async Task<CountReply> 
        QuickCounts(Grpc.Core.IAsyncStreamReader<CountRequest1> requestStream,
        Grpc.Core.IServerStreamWriter<CountReply> responseStream,
        Grpc.Core.ServerCallContext context)
    {
        Console.WriteLine($"QuickCounts Start!");
        while (await requestStream.MoveNext())
        {
            int ans = 0;
            switch (requestStream.Current.Opt)
            {
                case 1: ans = requestStream.Current.NumA + requestStream.Current.NumB; break;
                case 2: ans = requestStream.Current.NumA - requestStream.Current.NumB; break;
                case 3: ans = requestStream.Current.NumA * requestStream.Current.NumB; break;
                case 4: ans = requestStream.Current.NumA / requestStream.Current.NumB; break;
            }

            var areply = new CountReply()
            {
                ReNum = ans
            };
            Console.WriteLine($"Write{ans}");
            await Task.Delay(10);
            await responseStream.WriteAsync(areply);
        }
        var reply = new CountReply()
        {
            ReNum = 0
        };
        Console.WriteLine($"QuickCounts Exit!");
        return reply;
    }
}