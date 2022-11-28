using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hurt : MonoBehaviour
{
    public int MaxDmg = 10;
    public int MinDmg = 5;
    public Color TextColor;
    private Spawn TextPool;
    private GameObject emit;
    private TurnOff turn;
    private int dmg;
    // Start is called before the first frame update
    void Start()
    {
        TextPool = GameObject.Find("Text").GetComponent<Spawn>();
        turn = GetComponent<TurnOff>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!turn.dying)
        {
            dmg = Random.Range(MinDmg, MaxDmg);
            emit = TextPool.SpawnChild();
            emit.transform.position = transform.position;
            emit.GetComponent<FlyingNumber>().startColor = TextColor;
            emit.GetComponent<TextMeshPro>().text = dmg.ToString();
            collision.transform.GetComponent<Damage>().Hurt(dmg);
        }

    }
}
