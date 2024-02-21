using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever_Activation : MonoBehaviour
{
    private Animator anim;
    private bool Player_in_Range = false;

    public GameObject launcher;
    public float rotationSpeed;
    [SerializeField] private AudioSource leverActivate_soundEffect;
    [SerializeField] private BoxCollider2D boxC;
    void Start()
    {
        anim = GetComponent<Animator>();
        boxC = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if(Player_in_Range && Input.GetKeyDown("x"))
        {
            anim.SetBool("Contact", true);
            leverActivate_soundEffect.Play();
            launcher.transform.Rotate(new Vector3(0, 0, -rotationSpeed));
            Destroy(boxC);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        checkRange(collision.gameObject.transform);
    }

    void checkRange(Transform objectTransform)
    {
        if (objectTransform.CompareTag("Player") )
        {
            Player_in_Range = true;
        }
    }
}
