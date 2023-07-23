using Exiled.API.Features;
using Exiled.Events.EventArgs.Server;
using Server = Exiled.Events.Handlers.Server;

namespace SCP_Tesla.com.github.sekasin.scp_tesla {
    public class EventHandler {
        private readonly Plugin<Config> _main;
        private readonly bool _debugMode;
        
        public EventHandler(Plugin<Config> plugin){
            _main = plugin;
            _debugMode = plugin.Config.Debug;
            if (_debugMode) {
                Log.Info("Loading EventHandler");
            }
            
            Server.RoundStarted += OnRoundStart;
            Server.RestartingRound += OnRoundRestart;
            Server.RoundEnded += OnRoundEnd;
        }

        private void OnRoundStart() {
            Exiled.API.Features.TeslaGate.IgnoredTeams.Add(PlayerRoles.Team.Scientists);
            Exiled.API.Features.TeslaGate.IgnoredTeams.Add(PlayerRoles.Team.FoundationForces);
        }

        private void OnRoundRestart()
        {
            Exiled.API.Features.TeslaGate.IgnoredTeams.Clear();
        }

        private void OnRoundEnd(RoundEndedEventArgs ev)
        {
            OnRoundRestart();
        }

        public void UnregisterEvents()
        {
            Server.RoundStarted -= OnRoundStart;
            Server.RestartingRound -= OnRoundRestart;
            Server.RoundEnded -= OnRoundEnd;
            Exiled.API.Features.TeslaGate.IgnoredTeams.Clear();
        }
    }
}