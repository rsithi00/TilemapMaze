using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("makeDisappear", 5f);
    }

    void makeDisappear()
    {
        this.gameObject.SetActive(false);
    }
}
