using NightglowAwakens.Common.Configs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NightglowAwakens.Common.Systems
{
    public class ChestItemWorldGen : ModSystem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<ServerConfig>().ProgressionEnabled;
        }

        public override void PostWorldGen()
        {
            int itemPlaced = 0;
            int maxItems = 2;
            int ItemToPlace = ItemID.FairyQueenMagicItem;
            for (int chestIndex = 0; chestIndex < Main.maxChests; ++chestIndex)
            {
                Chest chest = Main.chest[chestIndex];
                if (chest is null) continue;
                Tile chestTile = Main.tile[chest.x, chest.y];
                if (chestTile.TileType == TileID.Containers && chestTile.TileFrameX == 13 * 36)
                {
                    if (WorldGen.genRand.NextBool(4)) continue;
                    for (int inventoryIndex = 0; inventoryIndex < Chest.maxItems; ++inventoryIndex)
                    {
                        if (chest.item[inventoryIndex].type is not ItemID.None) continue;
                        chest.item[inventoryIndex].SetDefaults(ItemToPlace);
                        ++itemPlaced;
                        break;
                    }
                }
                if (itemPlaced >= maxItems) break;
            }
        }
    }
}
