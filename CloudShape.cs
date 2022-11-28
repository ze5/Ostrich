using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class CloudShape : MonoBehaviour
{
    public float shift = 2;
    private SpriteShapeController shape;
    // Start is called before the first frame update
    void Start()
    {
        shape = GetComponent<SpriteShapeController>();
        GenerateRandom();
    }
    void GenerateRandom()
    {

        int i = 0;
        Vector3 splinepos = new Vector3();
        while (i < shape.spline.GetPointCount())
        {

            splinepos = shape.spline.GetPosition(i);
            splinepos.x += Random.Range(-shift, shift);
            splinepos.y += Random.Range(-shift, shift);
            shape.spline.SetPosition(i, splinepos);
            foreach (SpriteShapeController child in gameObject.GetComponentsInChildren<SpriteShapeController>())
            {
                child.spline.SetPosition(i, splinepos);
            }
            i++;
        }
        foreach (SpriteShapeController child in gameObject.GetComponentsInChildren<SpriteShapeController>())
        {
            child.UpdateSpriteShapeParameters();
        }
        shape.UpdateSpriteShapeParameters();
    }

}
