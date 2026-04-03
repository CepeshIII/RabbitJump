using UnityEngine;
using Zenject;



[RequireComponent(typeof(Rigidbody2D))]
public class RB2DMovement : MonoBehaviour, IMovement
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float jumpForce = 5f;

    private Rigidbody2D rb;


    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    public void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
    
    
    public void Move(Vector2 direction)
    {
        rb.linearVelocityX = direction.x * speed;
    }


    public void SetPositionX(float x)
    {
        rb.MovePosition(new Vector2(x, rb.position.y));
    }


    public Vector2 GetVelocity()
    {
        return rb.linearVelocity;
    }


    public Vector2 GetPosition()
    {
        return rb.position;
    }
}

