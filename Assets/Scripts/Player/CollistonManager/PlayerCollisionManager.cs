using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Collider2D))]
public class PlayerCollisionManager : MonoBehaviour
{
    [SerializeField] private Collider2D feetCollider;
    [SerializeField] private LayerMask platformLayer;

    private Player player;



    [Inject]
    public void Construct(Player player)
    {
        this.player = player;
    }


    private void Awake()
    {
        if (feetCollider == null)
            feetCollider = GetComponent<Collider2D>();
    }


    private void OnEnable()
    {
        player.onJump += DisableFeetCollider;
        player.onGameOver += DisableFeetCollider;
        player.onFall += EnableFeetCollider;
    }


    private void OnDisable()
    {
        player.onJump -= DisableFeetCollider;
        player.onGameOver -= DisableFeetCollider;
        player.onFall -= EnableFeetCollider;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!IsPlatform(other))
            return;

        // Only land if falling
        if (player.CurrentState != PlayerState.Falling)
            return;

        player.onLand?.Invoke();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!IsPlatform(collision.collider))
            return;

        // Only land if falling
        if (player.CurrentState != PlayerState.Falling)
            return;

        player.onLand?.Invoke();
    }


    private bool IsPlatform(Collider2D other)
    {
        return (platformLayer.value & (1 << other.gameObject.layer)) != 0;
    }


    private void DisableFeetCollider()
    {
        feetCollider.enabled = false;
    }


    private void EnableFeetCollider()
    {
        feetCollider.enabled = true;
    }
}

