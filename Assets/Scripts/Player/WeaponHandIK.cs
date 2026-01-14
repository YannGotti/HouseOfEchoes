using UnityEngine;

namespace Assets.Scripts.Player
{
    public class WeaponHandIK : MonoBehaviour
    {
        [SerializeField] private Transform weaponSocket;
        private Animator animator;

        void Start() => animator = GetComponent<Animator>();

        void OnAnimatorIK(int layerIndex)
        {
            if (weaponSocket != null)
            {
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
                animator.SetIKPosition(AvatarIKGoal.RightHand, weaponSocket.position);
            }
        }
    }
}
