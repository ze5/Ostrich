using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int DamageMin = 1;
    public int DamageMax = 5;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            int dmg = Random.Range(DamageMin, DamageMax);
            collision.gameObject.GetComponent<Player>().Hurt(dmg);
        }
    }
}
