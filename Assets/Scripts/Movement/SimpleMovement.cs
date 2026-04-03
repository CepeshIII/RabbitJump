using UnityEngine;
using Zenject;




public class SimpleMovement : MonoBehaviour, IInitializable, IMovement
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float jumpForce = 5f;

    private Rigidbody2D rb;
    private IInputManager inputManager;
    private CameraBorder cameraBorder;
    private Player player;



    [Inject]
    public void Construct(IInputManager inputManager, CameraBorder cameraBorder, Player player)
    {
        this.inputManager = inputManager;
        this.cameraBorder = cameraBorder;
        this.player = player;
    }


    public void Initialize()
    {
        inputManager.onJump += Jump;
        inputManager.onMove += Move;
    }


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        if (cameraBorder.IsOutsideHorizontal(rb.position))
        {
            var position = rb.position;

            float normalizedX = Mathf.InverseLerp(cameraBorder.Left, cameraBorder.Right, position.x);
            float invertedNormalizedX = 1f - normalizedX;
            float newX = Mathf.Lerp(cameraBorder.Left, cameraBorder.Right, invertedNormalizedX);

            var newPosition = new Vector2(newX, rb.position.y);
            rb.MovePosition(newPosition);
        }

        if(cameraBorder.IsOutsideVertical(rb.position))
        {
            player.onGameOver?.Invoke();
        }

        if (player.CurrentState == PlayerState.Jumping) 
        { 
            if(rb.linearVelocityY < 0)
            {
                player.onFall?.Invoke();
            }
        }
        else if (player.CurrentState == PlayerState.Idle)
        {
            Jump();
        }

    }


    public void Jump()
    {
        if(player.CurrentState != PlayerState.Idle)
        {
            return;
        }
        player.onJump?.Invoke();
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
    
    
    public void Move(Vector2 direction)
    {
        rb.AddForceX(direction.x * speed);
    }


}

