using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2;
    private Rigidbody rb;
    private bool moveLeft;
    private bool moveRight;
    private float horizontalMove; // Added missing type declaration

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        moveLeft = false;
        moveRight = false;
        horizontalMove = 0; // Initialize horizontalMove
    }

    public void PointerDownLeft()
    {
        moveLeft = true;
        MovePlayer(); // Call MovePlayer when button is pressed
    }

    public void PointerUpLeft()
    {
        moveLeft = false;
        MovePlayer(); // Call MovePlayer when button is released
    }

    public void PointerDownRight()
    {
        moveRight = true;
        MovePlayer(); // Call MovePlayer when button is pressed
    }

    public void PointerUpRight()
    {
        moveRight = false;
        MovePlayer(); // Call MovePlayer when button is released
    }

    void Update()
    {
        // You can add other update logic here if needed
    }

    public void MovePlayer()
    {
        if (moveLeft)
        {
            horizontalMove = -moveSpeed;
        }
        else if (moveRight) 
        {
            horizontalMove = moveSpeed;
        }
        else
        {
            horizontalMove = 0;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(horizontalMove, rb.velocity.y, 0); // Use Vector3 for Rigidbody velocity
    }
}
