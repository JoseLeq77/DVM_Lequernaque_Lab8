using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController3D : MonoBehaviour
{
    private Rigidbody myRB;
    public float speed = 5f;

    [SerializeField] private Vector2 movement;

    [SerializeField] private float jumpForce = 5f;

    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private float raycastDistance;

    private bool _canJump = false;


    private void Awake()
    {
        myRB = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        ApllyPhysics();
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

    public void ApllyPhysics()
    {
        movement = movement.normalized;
        myRB.linearVelocity = new Vector3(movement.x * speed, myRB.linearVelocity.y, movement.y * speed);

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

    public void ModifyCanJump(bool b)
    {
        _canJump = b;
    }

}
