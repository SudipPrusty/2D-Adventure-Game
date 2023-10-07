using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                                                   //(namespace) external package for UI

public class ItemCollector : MonoBehaviour
{
    private int fruits = 0;

    [SerializeField] private Text fruitsText;

    [SerializeField] private AudioSource collectSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)                 //bcz inside box collider 2D "isTrigger" has been made turned on for fruits
    {
        if (collision.gameObject.CompareTag("Kiwi"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            fruits++;
            fruitsText.text = "Fruits: " + fruits;
        }

        if (collision.gameObject.CompareTag("Cherry"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            fruits++;
            fruitsText.text = "Fruits: " + fruits;
        }

        if (collision.gameObject.CompareTag("Banana"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            fruits++;
            fruitsText.text = "Fruits: " + fruits;
        }

        if (collision.gameObject.CompareTag("Pineapple"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            fruits++;
            fruitsText.text = "Fruits: " + fruits;
        }

        if (collision.gameObject.CompareTag("Melon"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            fruits++;
            fruitsText.text = "Fruits: " + fruits;
        }

        if (collision.gameObject.CompareTag("Apple"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            fruits++;
            fruitsText.text = "Fruits: " + fruits;
        }

        if (collision.gameObject.CompareTag("Orange"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            fruits++;
            fruitsText.text = "Fruits: " + fruits;
        }
    }
}
