using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField] private float jumpHeight;
    [SerializeField] private float walkingSpeed;
    Rigidbody rb;
    Collider2D col;
    private bool isGrounded;

    private Vector2 move;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider2D>();

        Inputs.Init(this);
    }

    public void Movement(Vector2 direction)
    {
        move = direction;
    }


    public void Interact()
    {
        Debug.Log("INTERACTED LETS GO");
    }

    public void startCrouch()
    {
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    public void endCrouch()
    {
        transform.localScale = new Vector3(1,1,1);
    }


    void Update()
    {
        transform.Translate(Vector3.up * (move.y * Time.deltaTime * walkingSpeed), Space.Self);
        transform.Translate(Vector3.right * (move.x * Time.deltaTime * walkingSpeed), Space.Self);

        isGrounded = Physics.Raycast(transform.position, -Vector3.up, col.bounds.extents.y);
    }

}