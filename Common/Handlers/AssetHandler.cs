using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SCPMod.Common.Data;
using System.Collections.Generic;
using System.Reflection;
using Terraria;
using Terraria.ModLoader;

namespace SCPMod.Common.Handlers
{
    public static class AssetHandler
    {
        /// <summary>
        /// Dictionary that stores all swapped asset data.
        /// <para></para>
        /// TKey: The namespace followed by the field name of the swapped asset (i.e. "Terraria.Main.sunTexture"). <br />
        /// TValue: The swapped asset data (<see cref="AssetSwapData"/>).
        /// </summary>
        public static Dictionary<string, AssetSwapData> AssetSwaps;

        /// <summary>
        /// A 1x1-pixel <see cref="Texture2D"/> with no color.
        /// </summary>
        public static Texture2D BlankTexture;

        public static void LoadAssets()
        {
            // Manually create a see Texture2D with a singular white pixel with zero opacity (transparent).
            (BlankTexture = new Texture2D(Main.graphics.GraphicsDevice, 1, 1)).SetData(new Color[1] { new Color(255, 255, 255, 0) });

            AssetSwaps = new Dictionary<string, AssetSwapData>();

            LoadAssetSwaps();

            foreach (AssetSwapData swapData in AssetSwaps.Values)
                swapData.Load();
        }

        public static void UnloadAssets()
        {
            // Call swap unloads before we unload our assets so they don't have any null values.
            foreach (AssetSwapData swapData in AssetSwaps.Values)
                swapData.Unload();

            AssetSwaps = null;

            BlankTexture = null;
        }

        private static void LoadAssetSwaps()
        {
            AssetSwapData.AddAssetSwap("Terraria.Main" + ".sunTexture", typeof(Main).GetField("sunTexture", BindingFlags.Public | BindingFlags.Static), ModContent.GetTexture("SCPMod/Assets/DayBrokenSun1"));
            AssetSwapData.AddAssetSwap("Terraria.Main" + ".sun2Texture", typeof(Main).GetField("sun2Texture", BindingFlags.Public | BindingFlags.Static), ModContent.GetTexture("SCPMod/Assets/DayBrokenSun2"));
            AssetSwapData.AddAssetSwap("Terraria.Main" + ".sun3Texture", typeof(Main).GetField("sun3Texture", BindingFlags.Public | BindingFlags.Static), ModContent.GetTexture("SCPMod/Assets/DayBrokenSun3"));
        }
    }
}