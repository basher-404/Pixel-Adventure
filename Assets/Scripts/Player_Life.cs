using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Life : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField] private float height=-23.0f;

    [SerializeField] private AudioSource deathSoundEffect;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
      if(transform.position.y <= height)
        {
            die();
            Restart_Level(); 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            die();
        }
    }

    private void die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");
        deathSoundEffect.Play();
    }

    private void Restart_Level()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
