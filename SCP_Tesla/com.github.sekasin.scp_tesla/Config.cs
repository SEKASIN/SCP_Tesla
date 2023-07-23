using System.ComponentModel;
using Exiled.API.Interfaces;

namespace SCP_Tesla.com.github.sekasin.scp_tesla
{
    public sealed class Config : IConfig
    {
        [Description("Is the Plugin enabled.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Debug mode.")]
        public bool Debug { get; set; } = false;
    }
}