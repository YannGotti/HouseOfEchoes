using Mirror;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assets.Scripts.Player
{
    public class PlayerNetworkHandler : NetworkBehaviour
    {
        public override void OnStartLocalPlayer() 
        {
        }

        [Command]
        void CmdShoot() { }

        [ClientRpc]
        void RpcOnShootEffect() { }

    }
}
