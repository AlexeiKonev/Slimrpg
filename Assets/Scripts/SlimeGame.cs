using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeGame : MonoBehaviour
{
 public static  SlimeGame instance;
    void Awake()
    {
        if(instance == null) {
            instance = gameObject.GetComponent<SlimeGame>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
