using Microsoft.Xna.Framework.Graphics;
using SCPMod.Common.DataInterfaces;
using System.Reflection;

namespace SCPMod.Common.DataStructs
{
    public struct AssetSwapData : ILoadable
    {
        public FieldInfo VanillaAssetField { get; }

        public Texture2D OrigVanillaAsset { get; private set; }

        public Texture2D ReplacementAsset { get; }

        public AssetSwapData(FieldInfo vanillaAssetField, Texture2D replacementAsset)
        {
            VanillaAssetField = vanillaAssetField;
            ReplacementAsset = replacementAsset;
            OrigVanillaAsset = vanillaAssetField.GetValue(null) as Texture2D;
        }

        public void Load() => VanillaAssetField.SetValue(null, ReplacementAsset);

        public void Unload() => VanillaAssetField.SetValue(null, OrigVanillaAsset);
    }
}