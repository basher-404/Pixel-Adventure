using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone_Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private AudioSource deathSoundEffect;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        BoxCollider2D objectBoxCollider = GetComponent<BoxCollider2D>();
        if (collision.gameObject.name == "Sand Block")
        {
            Effects(collision.gameObject.transform);
            if (objectBoxCollider != null)
            {
                objectBoxCollider.enabled = false;
            }
        }
        

    }

    void Effects(Transform objectTransform)
    {
     
        anim.SetTrigger("Death");
        deathSoundEffect.Play();
       
    }

    private void die()
    {
       Destroy(gameObject);
    }

}
