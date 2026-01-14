using System;
using System.Collections.Generic;
using System.Text;

namespace Assets.Scripts.Core.Interfaces
{
    public interface ISaveable
    {
        void Save();
        void Load();
    }
}
