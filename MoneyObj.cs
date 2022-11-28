using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyObj : MonoBehaviour
{
    public int Value = 100;
    public Color TextColor;
    private Spawn TextPool;
    private GameObject emit;
    public AudioSource sound;
    private void Start()
    {
        TextPool = GameObject.Find("Text").GetComponent<Spawn>();
        sound = GameObject.Find("Sounds").transform.Find(gameObject.name).GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SaveData.Money += Value;
        emit = TextPool.SpawnChild();
        emit.transform.position = transform.position;
        emit.GetComponent<FlyingNumber>().startColor = TextColor;
        emit.GetComponent<TextMeshPro>().text = Value.ToString();
            sound.Play();
    }
}
