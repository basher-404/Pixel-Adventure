using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    public AudioSource launcherBlast_soundEffect;
    public GameObject objectPrefab; // Assign your prefab in the inspector
    float speed = 20f;
    float offset = 1f;

    void Start()
    {
        // Start the SpawnObject coroutine
        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject()
    {
        GameObject launcher = this.gameObject;
       while(true)
        {
            // Instantiate the object at the position of this script's GameObject
            Vector2 spawnPosition = new Vector2(transform.position.x + offset, transform.position.y);
            GameObject instance = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
            launcherBlast_soundEffect.Play();
            Rigidbody2D rb = instance.AddComponent<Rigidbody2D>();

            if (Mathf.Approximately(launcher.transform.rotation.eulerAngles.z, 0))
            {
                rb.velocity = new Vector2(speed, 0);
            }

            else
            {
                rb.velocity = new Vector2(25, -speed);
            }


            yield return new WaitForSeconds(2); // Wait for 3 seconds before the next iteration
        }

    }
}


    


