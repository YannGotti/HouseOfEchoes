using UnityEngine;

namespace Assets.Scripts.Features.Weapon
{
    [CreateAssetMenu]
    public class WeaponData : ScriptableObject
    {
        public string weaponName;
        public int id;
        public float damage;
        public float fireRate;
        public int magazineSize;
        public float reloadTime;
        public GameObject modelPrefab;
        public AnimatorOverrideController overrideController;
        public AudioClip fireSound;
    }
}
