using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class floor : MonoBehaviour
{
    private SpriteShapeController shape;
    private BackgroundSettings settings;
    public float paralax = 1f;
    public float width = 20;
    public float points = 10;
    public int MaxHeight = 5;
    // Start is called before the first frame update
    void Start()
    {
        shape = GetComponent<SpriteShapeController>();
        settings = GameObject.Find("Level").GetComponent<BackgroundSettings>();
        GenerateRandom();
    }
    void GenerateRandom()
    {

        int i = 0;
        Vector3 splinepos = new Vector3();
        while (i < points)
        {
           
            splinepos.x = (width/points)* i;
            splinepos.x += (width / points) * Random.value;
            splinepos.y = Random.Range(0, MaxHeight);
            shape.spline.SetPosition(i, splinepos);
            i++;
        }
        shape.UpdateSpriteShapeParameters();
    }
    private void FixedUpdate()
    {
        transform.Translate(settings.globalScroll * settings.scrollSpeed * paralax* Time.deltaTime);
        if (transform.position.x < -width*1.5f)
        {
            GenerateRandom();
            transform.position = new Vector3(width*1.5f,transform.position.y);
        }
    }
}
