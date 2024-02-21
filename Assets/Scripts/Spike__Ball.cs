using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike__Ball : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            // Destroy this object
            anim.SetBool("Touch", true);
            destroyComponents();
            Destroy(gameObject,2f); //Delays destruction for 2 seconds
        }
        Kill(collision.gameObject.transform);

    }

    void  Kill(Transform objectTransform)
    {
        if (objectTransform.CompareTag("Trap"))
        {
            anim.SetBool("Touch", true);
            destroyComponents();
            Destroy(objectTransform,2f);
        }
    }

    void destroyComponents()
    {
        Rigidbody2D objectRigidbody = GetComponent<Rigidbody2D>();
        if (objectRigidbody != null)
        {
            objectRigidbody.simulated = false;
        }

        BoxCollider2D objectBoxCollider = GetComponent<BoxCollider2D>();
        if (objectBoxCollider != null)
        {
            objectBoxCollider.enabled = false;
        }
    }
}
