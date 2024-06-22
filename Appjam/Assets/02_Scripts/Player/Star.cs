using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
{
    private bool start = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Image>().enabled == true && start)
        {
            GetComponent<AudioSource>().Play();
            Debug.Log("DOODODO");
            start = false;
        }
        else if(GetComponent<Image>().enabled == false && !start)
        {
            start = true;
        }
    }
}
