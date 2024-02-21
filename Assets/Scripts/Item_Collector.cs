using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    private int cherries_collected = 0;
    [SerializeField] private Text cherries_text;
    [SerializeField] private AudioSource item_collection_SoundEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry_Tag"))
        {
            Destroy(collision.gameObject);
            cherries_collected++;
            cherries_text.text = "Cherries: " + cherries_collected;
            item_collection_SoundEffect.Play();
        }
    }
}
