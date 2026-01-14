using Assets.Scripts.Features.Emotion;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;


        [SerializeField] private RuntimeAnimatorController _baseController;

        public void SetMoveDirection(Vector2 dir)
        {
            _animator.SetFloat("moveX", dir.x);
            _animator.SetFloat("moveY", dir.y);
        }

        public void SetIsAiming(bool aiming)
        {
            _animator.SetBool("isAiming", aiming);
        }

        public void PlayReload()
        {
            _animator.SetTrigger("Reload");
        }

        public void PlayEmotion(EmotionType emotion) { }

        public void PlayHitReaction() { }

        public void PlayShoot() 
        {

        }

        public void SetBaseController()
        {
            _animator.runtimeAnimatorController = _baseController;
        }

        public void SetWeaponOverride(AnimatorOverrideController overrideController)
        {
            if (overrideController != null)
            {
                _animator.runtimeAnimatorController = overrideController;
            }
        }
    }
}
