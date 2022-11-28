using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeCloud : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Segment;
    public int minSegments = 3;
    public int maxSegments = 8;
    public float Height = 1f;
    public float Gap = 1f;
    public Vector2 minScale;
    public Vector2 maxScale;
    void Start()
    {
        int segments = Random.Range(minSegments, maxSegments);
        Vector2 pos = transform.position;
        Vector3 Scale = Vector3.one;
        GameObject child;
        for (int i = 0; i < segments; i++)
        {
            pos.y = Random.value * Height;
            Scale.x = Random.Range(minScale.x, maxScale.x);
            Scale.y = Random.Range(minScale.y, maxScale.y);
            child = Instantiate(Segment, pos, Quaternion.identity, transform);
            child.transform.localScale = Scale;
            pos.x += Random.value * Gap;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
