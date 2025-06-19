using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 movementInput;

    [Header("Movimiento")]
    [SerializeField] private float velocity;

    [Header("Salto")]
    [SerializeField]  private float jumpForce;
    [SerializeField] private float groundRayDistance;
    [SerializeField] private LayerMask groundMask;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        InputHandler.movementPlayer += MovementPlayer;
        InputHandler.jumpEvent += Jump;
 
    }

    private void OnDisable()
    {
        InputHandler.movementPlayer -= MovementPlayer;
        InputHandler.jumpEvent -= Jump;
    }

    private void MovementPlayer(Vector2 value)
    {
        movementInput = value;
    }

    private void Jump()
    {
        Debug.DrawRay(transform.position, Vector3.down * groundRayDistance, Color.red);

        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, groundRayDistance, groundMask);
        if (!isGrounded) return;

        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
