using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push3 : MonoBehaviour
{
    private GameObject Pushtext;
    void Start()
    {
        Pushtext = GameObject.Find("Pushtext3");
        Pushtext.gameObject.SetActive(false);

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pushtext.gameObject.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pushtext.gameObject.SetActive(false);
        }
    }
}