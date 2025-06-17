using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    Rigidbody2D RB;
    public bool movementAllowed;
    private Vector2 _moveInput;
    [SerializeField] private float movementSpeed = 5.0f;

    public bool IsFacingRight { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IsFacingRight = true;
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movementAllowed = !GameStateManager.Instance.minigameInProgress;

        if (movementAllowed)
        {
            _moveInput.x = Input.GetAxisRaw("Horizontal");
            _moveInput.y = Input.GetAxisRaw("Vertical");
            animator.SetFloat("Speed", Mathf.Abs(_moveInput.x));
            if (_moveInput.x != 0)
            {
                CheckDirectionToFace(_moveInput.x > 0);
            }
        }
        else
        {
            _moveInput.x = 0;
        }
        
       
    }
    private void FixedUpdate()
    {
        //movementAllowed = !GameStateManager.Instance.minigameInProgress;
        if(!movementAllowed)
        {
            RB.linearVelocityX = 0;
        }
        RB.linearVelocityX = _moveInput.x * movementSpeed;

    }
    public void CheckDirectionToFace(bool isMovingRight)
    {
        if (isMovingRight != IsFacingRight)
            Turn();
    }

    private void Turn()
    {
        //stores scale and flips the player along the x axis, 
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        IsFacingRight = !IsFacingRight;
    }
}
