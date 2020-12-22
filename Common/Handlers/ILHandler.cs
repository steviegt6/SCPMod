using SCPMod.Common.Data;
using System.Collections.Generic;

namespace SCPMod.Common.Handlers
{
    internal static class ILHandler
    {
        internal static List<ILEdit> ILEdits;

        internal static void LoadILEdits()
        {
            ILEdits = new List<ILEdit>();

            AddILEdits();

            foreach (ILEdit edit in ILEdits)
                edit.Load();
        }

        internal static void UnloadILEdits()
        {
            foreach (ILEdit edit in ILEdits)
                edit.Unload();

            ILEdits = null;
        }

        private static void AddILEdits()
        {
        }
    }
}