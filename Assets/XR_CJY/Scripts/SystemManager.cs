using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    public GameObject player;

    FirstPersonController fpc;


    void Start()
    {
        fpc = player.GetComponent<FirstPersonController>();
    }


    public void PlayerControl()
    {

    }
}
