using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   private Rigidbody2D rb;
   private BoxCollider2D coll;
   private SpriteRenderer sprite;
   private Animator anim;

   [SerializeField] private LayerMask jumpableGround;
   private enum MovementState { idle, running, jumping, falling };
   [SerializeField] private float moveSpeed = 7f;
   public float jumpForce = 14f;
   [SerializeField] private float dirX = 0f;

   [SerializeField] private AudioSource jumpSoundEffect;

   private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        dirX= Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        updateAnimationState();

    }

    public void updateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }

        else if (dirX < 0)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }

        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }

        else if( rb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("State", (int)state);
    }

    public bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }
}
