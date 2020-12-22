using SCPMod.Common.DataInterfaces;

namespace SCPMod.Common.Data
{
    public abstract class ILEdit : ILoadable
    {
        public abstract void Load();

        public abstract void Unload();
    }
}