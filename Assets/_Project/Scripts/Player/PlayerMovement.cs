using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    private PlayerController playerController;

    [Header("Move Info")]
    public bool playerUnlocked;
    [SerializeField] private float moveSpeed = 3;

    [Header("Jump Info")]
    [SerializeField] private float jumpForce = 5;

    [Header("Colission Info")]
    private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask whatIsGround;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.playerRigidbody = GetComponent<Rigidbody2D>();
        this.playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        this.ApplyMovement();
        this.CheckCollision();
        this.CheckInput();
        this.AnimatorControllers();
    }

    private void ApplyMovement()
    {
        if (this.playerUnlocked)
            this.playerRigidbody.linearVelocity = new Vector2(this.moveSpeed, this.playerRigidbody.linearVelocity.y);

    }

    private void CheckInput()
    {
        if (InputManager.Instance.isButtonLeftClick) this.playerUnlocked = false;
        if (InputManager.Instance.isButtonRightClick) this.playerUnlocked = true;

        if (InputManager.Instance.isKeySpace && this.isGrounded)
            this.playerRigidbody.linearVelocity = new Vector2(this.playerRigidbody.linearVelocity.x, this.jumpForce);
    }

    private void CheckCollision()
    {
        this.isGrounded = Physics2D.Raycast(transform.position, Vector2.down, this.groundCheckDistance, this.whatIsGround);
    }

    private void AnimatorControllers()
    {
        this.playerController.animator.SetFloat(AnimationTags.FLOAT_X_VELOCITY, this.playerRigidbody.linearVelocity.x);
        this.playerController.animator.SetBool(AnimationTags.BOOL_IS_GROUNDED, this.isGrounded);
        this.playerController.animator.SetFloat(AnimationTags.FLOAT_Y_VELOCITY, this.playerRigidbody.linearVelocity.y);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - this.groundCheckDistance));
    }
}
