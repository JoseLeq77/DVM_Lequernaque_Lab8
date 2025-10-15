using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController3D : MonoBehaviour
{
    private Rigidbody myRB;
    public float speed = 5f;
    [SerializeField] private Vector3 initialPosition;

    [SerializeField] private Vector2 movement;

    [SerializeField] private float jumpForce = 5f;

    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private float raycastDistance;

    private bool _canJump = false;
    private bool _jumpAllowed = true;
    private bool _movementAllowed = true;


    private void Awake()
    {
        myRB = GetComponent<Rigidbody>();
        initialPosition = transform.position;
    }

    private void OnEnable()
    {
        GameManager.OnRestart += ResetPlayerPosition;
    }

    private void OnDisable()
    {
        GameManager.OnRestart -= ResetPlayerPosition;
    }

    private void FixedUpdate()
    {
        ApllyAllPhysics();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeathZone"))
        {
            GameManager.Instance.SetPlayerDead(true);
            GameManager.Instance.CheckLose();
        }
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && _canJump)
        {
            if (myRB.linearVelocity.y < 0)
            {
                myRB.linearVelocity = new Vector3(myRB.linearVelocity.x, 0, myRB.linearVelocity.z);
            }
            myRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    public void ApllyAllPhysics()
    {
        if (_movementAllowed)
        {
            MovementPhysics();
        }

        if (_jumpAllowed)
        {
            JumpPhysics();
        }
    }

    private void MovementPhysics()
    {
        movement = movement.normalized;
        myRB.linearVelocity = new Vector3(movement.x * speed, myRB.linearVelocity.y, movement.y * speed);
    }

    private void JumpPhysics()
    {
        bool RaycastDetection = Physics.Raycast(transform.position, Vector3.down, raycastDistance, groundLayers);

        if (RaycastDetection)
        {
            _canJump = true;
            Debug.DrawRay(transform.position, Vector3.down * raycastDistance, Color.green);
        }
        else
        {
            _canJump = false;
            Debug.DrawRay(transform.position, Vector3.down * raycastDistance, Color.red);
        }
    }

    public void SetJumpAllowed(bool b)
    {
        _jumpAllowed = b;
    }

    public void SetMovementAllowed(bool b)
    {
        _movementAllowed = b;
    }

    public void ResetPlayerPosition()
    {
        transform.position = initialPosition;
    }
}
