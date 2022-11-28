using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject child;
    private GameObject reuse;
    private List<GameObject> children = new List<GameObject>();

    public GameObject SpawnChild()
    {
        for (int i = 0; i < children.Count; i++)
        {
            if (children[i].activeSelf == false)
            {
                reuse = children[i];
                reuse.SetActive(true);
                return reuse;
            }
        }
        reuse = Instantiate(child, transform);
        children.Add(reuse);
        return reuse;
    }
    public int AliveChildren()
    {
        int Alive = 0;
        for (int i = 0; i < children.Count; i++)
        {
            if (children[i].activeSelf)
            {
                Alive++;
            }
        }
        return Alive;
    }
    
}
