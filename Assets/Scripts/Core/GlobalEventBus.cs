using System;

namespace Assets.Scripts.Core
{
    public static class GlobalEventBus
    {
        public static Action<float> OnPlayerDamaged;
        public static Action OnInteractRequested;

        public static Action<string> OnDoorOpened;
        public static Action OnMonsterSpotted;

        public static Action<string> OnPuzzleSolved;

        public static Action<string> OnWeaponFired;
        public static Action OnWeaponReloadStarted;

        public static Action<GameState, GameState> OnGameStateChanged;

        //public static void RaiseWeaponFired(string weaponName)
        //{
        //    OnWeaponFired?.Invoke(weaponName);
        //}

    }
}
