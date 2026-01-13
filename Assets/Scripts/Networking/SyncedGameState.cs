using Mirror;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assets.Scripts.Networking
{
    public class SyncedGameState
    {
        [SyncVar] public string matchId;
        [SyncVar] public bool isMatchActive;
        public SyncList<string> players = new SyncList<string>();
    }
}
