using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController2D : MonoBehaviour
{
    #region Variables
    [Header("Movimiento")]
    [SerializeField] private float moveSpeed = 5f;

    private Vector2 _inputVector;
    private Rigidbody2D _rb2d;
    #endregion

    #region Unity Methods
    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }
    #endregion

    #region Métodos de Movimiento
    private void Move()
    {
        _rb2d.linearVelocity = new Vector2(_inputVector.x * moveSpeed, _inputVector.y * moveSpeed);
    }
    #endregion

    #region Input System
    public void OnMove(InputAction.CallbackContext context)
    {
        _inputVector = context.ReadValue<Vector2>();
    }
    #endregion
}
