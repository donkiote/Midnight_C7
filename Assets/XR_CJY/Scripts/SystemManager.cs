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
        Cursor.lockState = CursorLockMode.Locked;
        fpc.enabled = true;
    }
}
