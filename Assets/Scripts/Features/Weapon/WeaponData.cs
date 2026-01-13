using UnityEngine;

namespace Assets.Scripts.Features.Weapon
{
    [CreateAssetMenu]
    public class WeaponData : ScriptableObject
    {
        public int id;
        public float damage;
        public float fireRate;
        public GameObject modelPrefab;
        public RuntimeAnimatorController overrideController;
    }
}
