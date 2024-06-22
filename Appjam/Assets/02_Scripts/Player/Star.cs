using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
{
    private bool start = true;
    public AudioSource AudioSource;
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
            AudioSource.volume = 0.1f;
            Debug.Log("DOODODO");
            start = false;
        }
        else if(GetComponent<Image>().enabled == false && !start)
        {
            AudioSource.volume = 0.5f;
            start = true;
        }
    }
}
