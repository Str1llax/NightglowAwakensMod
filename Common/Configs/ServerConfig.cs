
using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace NightglowAwakens.Common.Configs
{
    public class ServerConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        public override void OnChanged()
        {
            if (ProgressionEnabled && ModificationEnabled)
            {
                ModificationEnabled = false;
            }
        }

        [DefaultValue(true)] [ReloadRequired] public bool ProgressionEnabled;
        [DefaultValue(false)] [ReloadRequired] public bool ModificationEnabled;
        
        [Header("Damage")]
        
        [DefaultValue(100)] [Range(0, int.MaxValue-1)] [ReloadRequired] public int NightglowModifiedDamage;
    }
}