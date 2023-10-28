using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fish"))
        {
            if (player.GetComponent<PlayerMovement>().getHunger() < 3)
            {
                player.GetComponent<PlayerMovement>().changeHunger(1);
                Debug.Log("Hunger: " + player.GetComponent<PlayerMovement>().getHunger());
            }

            Destroy(collision.gameObject);
        }
    }
}
