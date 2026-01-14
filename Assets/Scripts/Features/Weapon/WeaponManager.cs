using Assets.Scripts.Core;
using Assets.Scripts.Core.Interfaces;
using Assets.Scripts.Player;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Features.Weapon
{
    public class WeaponManager : MonoBehaviour
    {
        [SerializeField] private PlayerAnimator animatorProxy;
        [SerializeField] private Transform weaponHolder; 
        [SerializeField] private WeaponData currentWeapon;
        [SerializeField] private Camera playerCamera;

        private float nextFireTime = 0f;
        private int currentAmmo;
        private bool isReloading = false;

        [SerializeField] private WeaponNetworkAdapter networkAdapter;
        private bool isMultiplayer => networkAdapter != null;

        public void Equip(WeaponData weapon)
        {
            if (weaponHolder.childCount > 0)
                Destroy(weaponHolder.GetChild(0).gameObject);

            GameObject model = Instantiate(weapon.modelPrefab, weaponHolder);
            model.transform.localPosition = Vector3.zero;
            model.transform.localRotation = Quaternion.identity;

            animatorProxy.SetWeaponOverride(weapon.overrideController);

            currentWeapon = weapon;
            currentAmmo = weapon.magazineSize;

            Debug.Log($"Equipped: {weapon.weaponName}");
        }

        public void Unequip()
        {
            if (currentWeapon == null) return;

            if (weaponHolder.childCount > 0)
                Destroy(weaponHolder.GetChild(0).gameObject);

            animatorProxy.SetBaseController(); 

            currentWeapon = null;
            currentAmmo = 0;
        }

        public void Shoot() 
        {
            if (currentWeapon == null) return;

            if (Time.time < nextFireTime || currentAmmo <= 0) return;

            currentAmmo--;
            nextFireTime = Time.time + currentWeapon.fireRate;

            animatorProxy.PlayShoot();

            GlobalEventBus.OnWeaponFired?.Invoke(currentWeapon.name);

            if (isMultiplayer)
                networkAdapter.RequestShoot();
            else
                ApplyLocalDamage();
        }

        private void ApplyLocalDamage()
        {
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit hit, 100f))
            {
                if (hit.collider.TryGetComponent(out IDamageable target))
                {
                    target.TakeDamage(currentWeapon.damage);
                }
            }
        }


        public void Reload()
        {
            if (currentWeapon == null) return;
            if (isReloading) return;
            if (currentAmmo >= currentWeapon.magazineSize) return;

            if (GameStateMachine.Instance?.GetCurrentState() != GameState.Explore) return;

            isReloading = true;
            animatorProxy.PlayReload();
            GlobalEventBus.OnWeaponReloadStarted?.Invoke();

            StartCoroutine(ReloadRoutine());
        }

        private IEnumerator ReloadRoutine()
        {
            yield return new WaitForSeconds(currentWeapon.reloadTime);
            currentAmmo = currentWeapon.magazineSize;
            isReloading = false;
        }

        public bool HasWeapon() => currentWeapon != null;
    }
}
