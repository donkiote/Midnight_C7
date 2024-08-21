using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    public GameObject player;

    FirstPersonController fpc;
    Highlight hl;

    void Start()
    {
        fpc = player.GetComponent<FirstPersonController>();
    }

    public void ExitButton()
    {
        hl.paintUI.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        fpc.enabled = true;
    }
}
