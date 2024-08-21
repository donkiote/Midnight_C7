using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintArtManager : MonoBehaviour
{
    public GameObject[] allImage;

    public int currIdx;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowImage(int idx)
    {
        allImage[currIdx].SetActive(false);
        
        currIdx = idx;
        allImage[idx].SetActive(true);
    }
}
