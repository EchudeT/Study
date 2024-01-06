using Grpc.Core;
using Count;

var channel = new Grpc.Core.Channel("localhost:5001", ChannelCredentials.Insecure);
var client = new CountNum.CountNumClient(channel);

var response = client.QuickCount(new CountRequest { Numa = 1,Numb = 2, Opt = 3 });

Console.WriteLine(response.ReNum);