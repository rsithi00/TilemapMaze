using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    [SerializeField] private GameObject winTarget;
    [SerializeField] private GameObject chestClose;
    [SerializeField] private GameObject chestOpen;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        chestClose.SetActive(false);
        chestOpen.SetActive(true);
        winTarget.SetActive(true);
        Invoke("ResetChest", 2.5f);
    }
    
    void ResetChest()
    {
        chestClose.SetActive(true);
        chestOpen.SetActive(false);
        winTarget.SetActive(false);

    }
}
