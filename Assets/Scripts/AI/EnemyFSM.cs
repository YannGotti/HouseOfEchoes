using System;
using System.Collections.Generic;
using System.Text;

namespace Assets.Scripts.AI
{
    public class EnemyFSM
    {
        public void ChangeState<T>() where T : IEnemyState, new() { }
        public void Update() { }
    }
}
