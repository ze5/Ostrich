using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearTrail : MonoBehaviour
{
    private void OnDisable()
    {
        GetComponent<TrailRenderer>().Clear();
    }
}
