using SCPMod.Common.Handlers;
using System.Reflection;
using Terraria.ModLoader;

namespace SCPMod
{
    /// <summary>
    /// Main mod class. <br />
    /// Handles most initialization in one way or another.
    /// </summary>
    public class SCPMod : Mod
    {
        public static SCPMod Instance { get; private set; }

        public static Assembly Assembly { get; private set; }

        public static Assembly TMLAssembly { get; private set; }

        public SCPMod()
        {
            Instance = this;
            Assembly = GetType().Assembly;
            TMLAssembly = typeof(ModLoader).Assembly;
        }

        public override void Load()
        {
            AssetHandler.LoadAssets();
        }

        public override void Unload()
        {
            AssetHandler.UnloadAssets();
            UnloadStaticFields();
        }

        private static void UnloadStaticFields()
        {
            Instance = null;
            Assembly = null;
            TMLAssembly = null;
        }
    }
}