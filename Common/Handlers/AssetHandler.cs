using SCPMod.Common.DataStructs;
using System.Collections.Generic;

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

        public static void LoadAssets()
        {
            AssetSwaps = new Dictionary<string, AssetSwapData>();

            foreach (AssetSwapData swapData in AssetSwaps.Values)
                swapData.Load();
        }

        public static void UnloadAssets()
        {
            foreach (AssetSwapData swapData in AssetSwaps.Values)
                swapData.Unload();

            AssetSwaps = null;
        }
    }
}