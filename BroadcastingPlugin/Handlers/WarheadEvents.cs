using System;
using Exiled.API.Features;
using Exiled.Events.EventArgs;

namespace BroadcastingPlugin.Handlers
{
    public class WarheadEvents
    {
        public void OnAlphaStart(StartingEventArgs ev)
        {
            bool isresumed = AlphaWarheadController._resumeScenario != -1;
            double left = isresumed
                ? AlphaWarheadController.Host.timeToDetonation
                : AlphaWarheadController.Host.timeToDetonation - 4;
            double count = Math.Truncate(left / 10.0) * 10.0;
            if (!isresumed)
            {
                Map.Broadcast(15, Plugin.Instance.Config.AlphaStart_notresumed.Replace("{count}", count.ToString()));
            }
            else
            {
                Map.Broadcast(15, Plugin.Instance.Config.AlpahStart_resumed.Replace("{count}", count.ToString()));
            }
        }

        public void OnAlphaCancel(StoppingEventArgs ev)
        {
            Map.Broadcast(15, Plugin.Instance.Config.AlphaStop.Replace("{player.Nickname}", ev.Player.Nickname));
        }
    }
}