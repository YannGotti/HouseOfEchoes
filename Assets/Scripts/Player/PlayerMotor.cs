using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerMotor : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 1f;
        [SerializeField] private float _rotationSpeed = 1f;
        private CharacterController _controller;
        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
        }

        public void Move(Vector2 moveInput, Camera mainCamera)
        {
            if (_controller == null || mainCamera == null) return;

            if (Mathf.Abs(moveInput.x) > 0.1f)
            {
                Vector3 strafeDirection = mainCamera.transform.right * moveInput.x;
                strafeDirection.y = 0f;
                strafeDirection.Normalize();

                Quaternion targetRotation = Quaternion.LookRotation(strafeDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
            }

            Vector3 forward = mainCamera.transform.forward;
            Vector3 right = mainCamera.transform.right;

            forward.y = 0f;
            right.y = 0f;
            forward.Normalize();
            right.Normalize();

            Vector3 movement = forward * moveInput.y + right * moveInput.x;
            _controller.SimpleMove(movement * _moveSpeed);
        }

        public void RotateToAimTarget(Vector3 aimPosition) { }
    }
}
