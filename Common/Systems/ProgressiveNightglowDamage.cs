using System.Collections.Generic;
using Microsoft.Xna.Framework;
using NightglowAwakens.Common.Configs;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace NightglowAwakens.Common.Systems
{
    public class ProgressiveNightglowDamage : GlobalItem
    {
        private static string PreBossText = "Mods.NightglowAwakens.Progression.Nightglow.PreBoss";
        private static string PostKingSlimeText = "Mods.NightglowAwakens.Progression.Nightglow.PostKingSlime";
        private static string PostEyeOfCthulhuText = "Mods.NightglowAwakens.Progression.Nightglow.PostEyeOfCthulhuText";
        private static string PostWorldCorruptionText = "Mods.NightglowAwakens.Progression.Nightglow.PostWorldCorruptionText";
        private static string PostSkeletronText = "Mods.NightglowAwakens.Progression.Nightglow.PostSkeletronText";
        private static string PostWallOfFleshText = "Mods.NightglowAwakens.Progression.Nightglow.PostWallOfFleshText";
        private static string PostQueenSlimeText = "Mods.NightglowAwakens.Progression.Nightglow.PostQueenSlimeText";
        private static string PostMech1Text = "Mods.NightglowAwakens.Progression.Nightglow.PostMech1Text";
        private static string PostMech2Text = "Mods.NightglowAwakens.Progression.Nightglow.PostMech2Text";
        private static string PostMech3Text = "Mods.NightglowAwakens.Progression.Nightglow.PostMech3Text";
        private static string PostPlanteraText = "Mods.NightglowAwakens.Progression.Nightglow.PostPlanteraText";
        private static string PostGolemText = "Mods.NightglowAwakens.Progression.Nightglow.PostGolemText";
        private static string PostDukeFishronText = "Mods.NightglowAwakens.Progression.Nightglow.PostDukeFishronText";
        private static string PostEmpressOfLightText = "Mods.NightglowAwakens.Progression.Nightglow.PostEmpressOfLightText";
        private static string PostLunaticCultistText = "Mods.NightglowAwakens.Progression.Nightglow.PostLunaticCultistText";
        private static string PostMoonlordText = "Mods.NightglowAwakens.Progression.Nightglow.PostMoonlordText";

        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<ServerConfig>().ProgressionEnabled && !ModContent.GetInstance<ServerConfig>().ModificationEnabled;
        }

        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return entity.type is ItemID.FairyQueenMagicItem;
        }

        public override void SetDefaults(Item entity)
        {
            entity.StatsModifiedBy.Add(Mod);

            entity.damage = 10;
            entity.mana = 10;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (NPC.downedMoonlord) tooltips.Add(new TooltipLine(Mod, "Progress", Language.GetTextValue(PostMoonlordText)) { OverrideColor = Color.PaleVioletRed} );//state = "Well Done!";
            else if (NPC.downedAncientCultist) tooltips.Add(new TooltipLine(Mod, "Progress", Language.GetTextValue(PostLunaticCultistText)) { OverrideColor = Color.LightSkyBlue} );//state = "Now I need you to kill The Cosmic God itself!";
            else if (NPC.downedEmpressOfLight) tooltips.Add(new TooltipLine(Mod, "Progress", Language.GetTextValue(PostEmpressOfLightText)) { OverrideColor = Color.LightYellow} );//state = "Now I need you to kill satanic being!";
            else if (NPC.downedFishron) tooltips.Add(new TooltipLine(Mod, "Progress", Language.GetTextValue(PostDukeFishronText)) { OverrideColor = Color.LightCyan} );//state = "Now I need you to kill my rainbow mother!";
            else if (NPC.downedGolemBoss) tooltips.Add(new TooltipLine(Mod, "Progress", Language.GetTextValue(PostGolemText)) { OverrideColor = Color.LightSeaGreen} );//state = "Now I need you to kill stinky fish!";
            else if (NPC.downedPlantBoss) tooltips.Add(new TooltipLine(Mod, "Progress", Language.GetTextValue(PostPlanteraText)) { OverrideColor = Color.Brown} );//state = "Now I need you to kill ancient scumbag!";
            else if (NPC.downedMechBoss3) tooltips.Add(new TooltipLine(Mod, "Progress", Language.GetTextValue(PostMech3Text)) { OverrideColor = Color.LightGreen} );//state = "Now I need you to kill Flowey parody!";
            else if (NPC.downedMechBoss2) tooltips.Add(new TooltipLine(Mod, "Progress", Language.GetTextValue(PostMech2Text)) { OverrideColor = Color.Blue} );//state = "Now I need you to kill the last mech!";
            else if (NPC.downedMechBoss1) tooltips.Add(new TooltipLine(Mod, "Progress", Language.GetTextValue(PostMech1Text)) { OverrideColor = Color.Red} );//state = "Now I need you to kill the second mech!";
            else if (NPC.downedQueenSlime) tooltips.Add(new TooltipLine(Mod, "Progress", Language.GetTextValue(PostQueenSlimeText)) { OverrideColor = Color.Green} );//state = "Now I need you to kill the first mech!";
            else if (Main.hardMode) tooltips.Add(new TooltipLine(Mod, "Progress", Language.GetTextValue(PostWallOfFleshText)) { OverrideColor = Color.LightPink} );//state = "Now I need you to kill Slime King's Queen!";
            else if (NPC.downedBoss3) tooltips.Add(new TooltipLine(Mod, "Progress", Language.GetTextValue(PostSkeletronText)) { OverrideColor = Color.DarkRed} );//state = "Now I need you to kill this meat wall!";
            else if (NPC.downedBoss2) tooltips.Add(new TooltipLine(Mod, "Progress", Language.GetTextValue(PostWorldCorruptionText)) { OverrideColor = Color.LightGray} );//state = "Now I need you to kill that annoying Skull!";
            else if (NPC.downedBoss1) tooltips.Add(new TooltipLine(Mod, "Progress", Language.GetTextValue(PostEyeOfCthulhuText)) { OverrideColor = Color.RosyBrown} );//state = "Now I need you to kill the world curse!";
            else if (NPC.downedSlimeKing) tooltips.Add(new TooltipLine(Mod, "Progress", Language.GetTextValue(PostKingSlimeText)) { OverrideColor = Color.Red} );//state = "Now I need you to kill Eye of Cthulhu!";
            else tooltips.Add(new TooltipLine(Mod, "Progress", Language.GetTextValue(PreBossText)) { OverrideColor = Color.LightBlue} );//string state = "I need you to kill King Slime!";
        }

        public override void ModifyWeaponDamage(Item item, Player player, ref StatModifier damage)
        {
            if (NPC.downedSlimeKing) damage += 0.5f; //15
            if (NPC.downedBoss1) damage += 0.5f; //20
            if (NPC.downedBoss2) damage += 0.5f; //25
            if (NPC.downedBoss3) damage += 0.5f; //30
            // if (NPC.downedDeerclops) damage += 2;
            // if (NPC.downedQueenBee) damage += 2;
            // if (NPC.downedGoblins) damage += 2;
            
            if (Main.hardMode) damage += 1.0f; //40
            
            // if (NPC.downedPirates) damage += 4;
            if (NPC.downedQueenSlime) damage += 1.0f; //50
            if (NPC.downedMechBoss1) damage += 0.5f; //55
            if (NPC.downedMechBoss2) damage += 0.5f; //60
            if (NPC.downedMechBoss3) damage += 0.5f; //65
            if (NPC.downedPlantBoss) damage += 0.5f; //70
            if (NPC.downedGolemBoss) damage += 1.0f; //80
            // if (NPC.downedHalloweenTree) damage += 2;
            // if (NPC.downedHalloweenKing) damage += 3;
            // if (NPC.downedChristmasTree) damage += 2;
            // if (NPC.downedChristmasSantank) damage += 2;
            // if (NPC.downedChristmasIceQueen) damage += 3;
            // if (NPC.downedMartians) damage += 4;
            if (NPC.downedFishron) damage += 0.5f; //85
            if (NPC.downedEmpressOfLight) damage += 0.5f; //90
            if (NPC.downedAncientCultist) damage += 1.0f; //100
            // if (NPC.downedTowerNebula) damage += 3;
            // if (NPC.downedTowerSolar) damage += 3;
            // if (NPC.downedTowerStardust) damage += 3;
            // if (NPC.downedTowerVortex) damage += 3;
            if (NPC.downedMoonlord) damage += 10.0f; //200


            // if (NPC.savedGoblin) damage += 1;
            // if (NPC.savedMech) damage += 1;
            // if (NPC.savedWizard) damage += 1;
        }

        public override void ModifyWeaponCrit(Item item, Player player, ref float crit)
        {
            
        }

        public override void ModifyManaCost(Item item, Player player, ref float reduce, ref float mult)
        {
            if (NPC.downedBoss3) reduce += 0.2f; //12
            if (Main.hardMode) reduce += 1.2f; //24
            if (NPC.downedPlantBoss) reduce += 0.05f; //25
            if (NPC.downedGolemBoss) reduce -= 0.2f; //20
            if (NPC.downedFishron) reduce -= 0.1f; //18
            if (NPC.downedEmpressOfLight) reduce -= 0.17f; //15
            if (NPC.downedAncientCultist) reduce -= 0.34f; //10
            if (NPC.downedMoonlord) reduce -= 1f; //0
        }

        public override float UseAnimationMultiplier(Item item, Player player)
        {
            float speed = 1.0f;
            
            if (NPC.downedBoss2) speed -= 0.05f; //105%
            if (Main.hardMode) speed -= 0.05f; //110%
            if (NPC.downedPlantBoss) speed -= 0.05f; //115%
            if (NPC.downedAncientCultist) speed -= 0.05f; //120%
            if (NPC.downedMoonlord) speed = 0.3f;

            return speed;
        }
    }
}