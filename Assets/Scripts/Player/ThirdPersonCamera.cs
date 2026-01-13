using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonCamera : MonoBehaviour
{
    [Tooltip("Цель, за которой следует камера (обычно игрок)")]
    public Transform target;

    [Tooltip("Смещение относительно цели (в локальных координатах цели, только по горизонтали)")]
    public Vector3 offset = new Vector3(0f, 1.8f, -3f);
    public Vector3 offsetLookAt = new Vector3(0f, 1.6f, 0.5f);

    [Range(0.01f, 1f)]
    public float smoothTime = 0.15f;

    [Header("Mouse Sway")]
    public float maxHorizontalAngle = 10f;   
    public float maxVerticalAngle = 5f;     
    public float returnSpeed = 5f;          
    public float sensitivity = 0.2f;        

    private Vector3 velocity = Vector3.zero;
    private Vector2 currentSway = Vector2.zero;

    public void HandleLookInput(Vector2 delta)
    {
        if (delta != Vector2.zero)
        {
            currentSway.x += delta.x * sensitivity;
            currentSway.y += delta.y * sensitivity;
            currentSway.x = Mathf.Clamp(currentSway.x, -maxHorizontalAngle, maxHorizontalAngle);
            currentSway.y = Mathf.Clamp(currentSway.y, -maxVerticalAngle, maxVerticalAngle);
        }
    }

    void LateUpdate()
    {
        if (target == null) return;

        currentSway = Vector2.Lerp(currentSway, Vector2.zero, returnSpeed * Time.deltaTime);

        Quaternion baseRotation = Quaternion.Euler(0, target.eulerAngles.y, 0);

        Quaternion swayRotation = Quaternion.Euler(-currentSway.y, currentSway.x, 0);
        Quaternion finalRotation = baseRotation * swayRotation;

        Vector3 desiredPosition = target.position + finalRotation * offset;
        Vector3 lookAtPoint = target.position + finalRotation * offsetLookAt;

        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
        transform.position = smoothedPosition;

        transform.LookAt(lookAtPoint);
    }

    public void FollowTarget(Transform newTarget)
    {
        target = newTarget;
    }

    public void BlendToFPS() { /* реализуем позже */ }
    public void BlendToTPS() { /* реализуем позже */ }

}