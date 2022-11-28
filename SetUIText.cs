using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetUIText : MonoBehaviour
{
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "LegGun")
        {
            text.text = SaveData.LegGunLevel.ToString();
        }
    }
}
