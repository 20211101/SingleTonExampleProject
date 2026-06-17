using UnityEngine;

/// <summary>
/// Rigidbody의 linearVelocity를 직접 제어해 XZ 평면 이동과 점프 처리를 보여주는 예제를 책임집니다.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PlanarLinearVelocityExample : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float jumpVelocity = 6f;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private float groundCheckRadius = 0.25f;
    [SerializeField] private LayerMask groundLayer = ~0;

    private Rigidbody cachedRigidbody;
    private Vector3 moveDirection;
    private bool jumpRequested;

    private void Awake()
    {
        cachedRigidbody = GetComponent<Rigidbody>();
    }

    private void Reset()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        body.useGravity = true;
        body.freezeRotation = true;
    }

    private void Update()
    {
        ReadMoveInput();
        ReadJumpInput();
    }

    private void FixedUpdate()
    {
        ApplyPlanarVelocity();
        ApplyJumpVelocity();
    }

    private void ReadMoveInput()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(horizontal, 0f, vertical).normalized;
    }

    private void ReadJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpRequested = true;
        }
    }

    private void ApplyPlanarVelocity()
    {
        Vector3 currentVelocity = cachedRigidbody.linearVelocity;
        Vector3 planarVelocity = moveDirection * moveSpeed;

        cachedRigidbody.linearVelocity = new Vector3(planarVelocity.x, currentVelocity.y, planarVelocity.z);
    }

    private void ApplyJumpVelocity()
    {
        if (!jumpRequested)
        {
            return;
        }

        jumpRequested = false;

        if (!IsGrounded())
        {
            return;
        }

        Vector3 currentVelocity = cachedRigidbody.linearVelocity;
        cachedRigidbody.linearVelocity = new Vector3(currentVelocity.x, jumpVelocity, currentVelocity.z);
    }

    private bool IsGrounded()
    {
        Vector3 checkPosition = groundCheckPoint != null ? groundCheckPoint.position : transform.position;
        return Physics.CheckSphere(checkPosition, groundCheckRadius, groundLayer, QueryTriggerInteraction.Ignore);
    }
}
