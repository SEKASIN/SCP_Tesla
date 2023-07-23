using System;
using Exiled.API.Features;

namespace SCP_Tesla.com.github.sekasin.scp_tesla {
    public class SCP_Tesla : Plugin<Config> {
        public override string Name => "SCP_Tesla";
        public override string Author => "TenDRILLL";
        public override Version Version => new Version(1, 0, 0);
        public EventHandler EventHandler;

        public override void OnEnabled() {
            Log.Info("SCP_Tesla loading...");
            if (!Config.IsEnabled) {
                Log.Warn("SCP_Tesla disabled from config, unloading...");
                OnDisabled();
                return;
            }
            EventHandler = new EventHandler(this);
            Log.Info("SCP_Tesla loaded.");
        }

        public override void OnDisabled()
        {
            EventHandler.UnregisterEvents();
            Log.Info("SCP_Tesla unloaded.");
        }
    }
}