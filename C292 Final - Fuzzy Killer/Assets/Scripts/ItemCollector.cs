using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fish")
        {
            if (player.GetComponent<PlayerMovement>().getHunger() < 4)
            {
                player.GetComponent<PlayerMovement>().changeHunger(1);
            }

            Destroy(collision.gameObject);
        }
    }
}
