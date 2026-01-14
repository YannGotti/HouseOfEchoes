using UnityEngine;

namespace Assets.Scripts.Core.Managers
{
    public class AudioManager : MonoBehaviour
    {
        void OnEnable()
        {
            GlobalEventBus.OnWeaponReloadStarted += PlayReloadSound;
        }

        private void PlayReloadSound()
        {
        }
    }
}
