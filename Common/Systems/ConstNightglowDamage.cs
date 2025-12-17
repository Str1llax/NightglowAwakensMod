using NightglowAwakens.Common.Configs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NightglowAwakens.Common.Systems
{
    public class ConstNightglowDamage : GlobalItem
    {

        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<ServerConfig>().ModificationEnabled && !ModContent.GetInstance<ServerConfig>().ProgressionEnabled;
        }

        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return entity.type is ItemID.FairyQueenMagicItem;
        }

        public override void SetDefaults(Item entity)
        {
            entity.StatsModifiedBy.Add(Mod);

            entity.damage = ModContent.GetInstance<ServerConfig>().NightglowModifiedDamage;
        }
    }
}