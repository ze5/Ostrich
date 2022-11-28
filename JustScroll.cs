using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustScroll : MonoBehaviour
{
    public float paralax = 1f;
    private BackgroundSettings settings;
    private Rigidbody2D rig;
    private bool phys = false;
    private void Start()
    {
        settings = GameObject.Find("Level").GetComponent<BackgroundSettings>();

    }
    private void FixedUpdate()
    {
            transform.Translate(settings.globalScroll * settings.scrollSpeed * paralax * Time.deltaTime);
    }
}
