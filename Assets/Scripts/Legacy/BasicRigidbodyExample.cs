using UnityEngine;

/// <summary>
/// Rigidbody를 사용하는 오브젝트의 기본 물리 이동, 점프, 회전, 속도 제어 예제를 책임집니다.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class BasicRigidbodyExample : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveForce = 12f;
    [SerializeField] private float maxHorizontalSpeed = 6f;
    [SerializeField] private float jumpForce = 6f;
    [SerializeField] private float torqueForce = 4f;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private float groundCheckRadius = 0.25f;
    [SerializeField] private LayerMask groundLayer = ~0;

    private Rigidbody cachedRigidbody;
    private Vector3 startPosition;
    private Quaternion startRotation;

    private void Awake()
    {
        cachedRigidbody = GetComponent<Rigidbody>();
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    private void Reset()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        body.mass = 1f;
        body.linearDamping = 0.2f;
        body.angularDamping = 0.5f;
        body.useGravity = true;
    }

    private void FixedUpdate()
    {
        MoveWithForce();
        RotateWithTorque();
        LimitHorizontalVelocity();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetBody();
        }
    }

    private void MoveWithForce()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 inputDirection = new Vector3(horizontal, 0f, vertical).normalized;
        cachedRigidbody.AddForce(inputDirection * moveForce, ForceMode.Force);
    }

    private void RotateWithTorque()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            cachedRigidbody.AddTorque(Vector3.down * torqueForce, ForceMode.Force);
        }

        if (Input.GetKey(KeyCode.E))
        {
            cachedRigidbody.AddTorque(Vector3.up * torqueForce, ForceMode.Force);
        }
    }

    private void Jump()
    {
        cachedRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void LimitHorizontalVelocity()
    {
        Vector3 velocity = cachedRigidbody.linearVelocity;
        Vector3 horizontalVelocity = new Vector3(velocity.x, 0f, velocity.z);

        if (horizontalVelocity.sqrMagnitude <= maxHorizontalSpeed * maxHorizontalSpeed)
        {
            return;
        }

        Vector3 limitedHorizontalVelocity = horizontalVelocity.normalized * maxHorizontalSpeed;
        cachedRigidbody.linearVelocity = new Vector3(limitedHorizontalVelocity.x, velocity.y, limitedHorizontalVelocity.z);
    }

    private bool IsGrounded()
    {
        Vector3 checkPosition = groundCheckPoint != null ? groundCheckPoint.position : transform.position;
        return Physics.CheckSphere(checkPosition, groundCheckRadius, groundLayer, QueryTriggerInteraction.Ignore);
    }

    private void ResetBody()
    {
        cachedRigidbody.linearVelocity = Vector3.zero;
        cachedRigidbody.angularVelocity = Vector3.zero;
        cachedRigidbody.MovePosition(startPosition);
        cachedRigidbody.MoveRotation(startRotation);
    }
}
