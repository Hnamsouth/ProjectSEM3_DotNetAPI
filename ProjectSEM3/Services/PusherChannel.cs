using Microsoft.AspNetCore.Mvc;
using PusherServer;

namespace ProjectSEM3.Services
{
    public class PusherChannel
    {
        public static Pusher Channel()
        {
            var options = new PusherOptions
            {
                Cluster = "ap1",
                Encrypted = true
            };
            var pusher = new Pusher(
              "1664411", // PUSHER_APP_ID
              "47e4e48aead7fea024b6",
              "527f38d0ceca06e2a129",
              options
            );
            return pusher;
        }

        public static Task<ITriggerResult> Trigger(object data, string channelName, string eventName)
        {
          return  Channel().TriggerAsync(
              channelName,
              eventName,
              data
            );
        }
    }
}
