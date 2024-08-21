using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    public PaintArtManager paintArt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            paintArt.gameObject.SetActive(true);
            paintArt.ShowImage(0);
            
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            paintArt.gameObject.SetActive(true);
            
            paintArt.ShowImage(1);
            
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            paintArt.gameObject.SetActive(true);
            
            paintArt.ShowImage(2);
            
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            paintArt.gameObject.SetActive(true);
            
            paintArt.ShowImage(3);
            
        }
    }
}
