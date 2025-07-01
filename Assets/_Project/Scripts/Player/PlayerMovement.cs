using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Move Info")]
    public bool runBegun;
    public float moveSpeed = 3;

    [Header("Jump Info")]
    public float jumpForce = 5;

    private Rigidbody2D playerRigidbody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.ApplyMovement();
        this.CheckInput();
    }

    private void ApplyMovement()
    {
        if (this.runBegun)
        {
            this.playerRigidbody.linearVelocity = new Vector2(this.moveSpeed, this.playerRigidbody.linearVelocity.y);
        }
    }

    private void CheckInput()
    {
        if (InputManager.Instance.isMouseLeftClick) this.runBegun = false;
        if (InputManager.Instance.isMouseRightClick) this.runBegun = true;

        if (InputManager.Instance.isKeySpace)
            this.playerRigidbody.linearVelocity = new Vector2(this.playerRigidbody.linearVelocity.x, this.jumpForce);
    }
}
