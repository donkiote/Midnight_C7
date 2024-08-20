using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    public GameObject player;
    public GameObject paintUI;

    FirstPersonController fpc;


    void Start()
    {
        fpc = player.GetComponent<FirstPersonController>();
    }

    public void ExitButton()
    {
        paintUI.SetActive(false);
        fpc.enabled = true;
    }
}
