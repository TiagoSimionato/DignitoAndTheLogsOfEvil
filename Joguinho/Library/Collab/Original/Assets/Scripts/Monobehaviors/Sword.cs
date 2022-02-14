using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public int damage;

    void OnCollisionEnter2D(Collider2D collision)
    {
        if ( (collision is BoxCollider2D) && collision.gameObject.CompareTag("Enemy"))
        {
            print("ADJSNDAJSNDJASNDASJDNASJDNASJDASNJDASJND");
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            StartCoroutine(enemy.DanoCharactere(damage, 1.0f));
        }
    }
    /*void OnCollisionExit2D(Collider2D collision)
    {
        if ( (collision is BoxCollider2D) && collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy.damageCoroutine != null)
            {
                StopCoroutine(enemy.DanoCharactere);
                enemy.DanoCharactere = null;
            }
        }
    }*/
}