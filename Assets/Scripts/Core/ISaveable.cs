using System;
using System.Collections.Generic;
using System.Text;

namespace Assets.Scripts.Core
{
    public interface ISaveable
    {
        void Save();
        void Load();
    }
}
