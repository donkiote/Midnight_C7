using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public List<GameObject> Npc = new List<GameObject>();
    //NpcMove npc_s;

    int netNpc = 0;

    // Start is called before the first frame update
    void Start()
    {
        //npc_s = Npc[0].GetComponent<NpcMove>();
        //6°³
        //Npc[0].SetActive(false);
        
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            GameObject npc = Npc[netNpc];
            npc.transform.position = this.transform.position;
            npc.SetActive(true);

            netNpc++;
            if (netNpc >= Npc.Count)
            {
                netNpc = 0;
            }
            yield return new WaitForSeconds(7);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Npc"))
        {
            other.gameObject.SetActive(false);
        }
    }

}
