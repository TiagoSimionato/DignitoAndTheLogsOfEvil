using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public int damage;

    private void OnTrigger2D(Collider2D collision)
    {
        if ( (collision is BoxCollider2D) && collision.gameObject.CompareTag("Enemy"))
        {
            print("ADJSNDAJSNDJASNDASJDNASJDNASJDASNJDASJND");
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            StartCoroutine(enemy.DanoCharactere(damage, 1.0f));
        }
    }
}
