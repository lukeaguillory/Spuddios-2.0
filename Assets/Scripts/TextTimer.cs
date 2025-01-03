using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTimer : MonoBehaviour
    
{
    public float _maximumShownTime;
    public GameObject thisText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _maximumShownTime -= Time.deltaTime;

        if (_maximumShownTime <= 0)
        {
            Destroy(thisText);
        }
    }
}
