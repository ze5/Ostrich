using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBG : MonoBehaviour
{
    public Sprite[] spriteArray;
    private Vector3 scale = Vector3.one;
    private float speed;
    public Gradient color;
    public BackgroundSettings settings;
    // Start is called before the first frame update
    private void Update()
    {

        transform.Translate(settings.globalScroll * speed * Time.deltaTime);
    }
    public void Randomize()
    {
        settings = GetComponentInParent<BackgroundSettings>();
        GetComponent<SpriteRenderer>().sprite = spriteArray[Random.Range(0, spriteArray.Length)];
        if (Random.value > 0.5f)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (Random.value > 0.7f)
        {
            scale.x = Random.Range(0.2f, 5);
            scale.y = Random.Range(0.2f, 3);
            transform.localScale = scale;
        }
        else
        {
            transform.localScale = Vector3.one;
        }
        
        speed = Random.Range(1, settings.scrollSpeed * 100) * transform.localScale.magnitude;
        speed /= 100;
        GetComponent<SpriteRenderer>().color = color.Evaluate(Mathf.Clamp((speed/10) + 0.5f, 0, 1));
        GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(speed - 100);
        //GetComponent<Rigidbody2D>().AddForce(settings.globalScroll * );
    }

}
