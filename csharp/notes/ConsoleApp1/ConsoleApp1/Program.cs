using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using InfiniteRemotingServer;
 
namespace InfiniteServicesHost
{
    class Server
    {
        static void Main(string[] args)
        {
            //create a new channel
            HttpChannel c = new HttpChannel(83);

            //regiter the channel
            ChannelServices.RegisterChannel(c);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(InfinteServices), "OurRemoteService", WellKnownObjectMode.Singleton);
            Console.WriteLine("Server services started at the Port No. 83...");
            Console.WriteLine("Press any key to stop the server..");
            Console.Read();
        }
    }
}