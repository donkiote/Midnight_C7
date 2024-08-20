using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class NpcMove : MonoBehaviour
{

    public enum ENpcState_BM
    {
        
        Walk,
        Nod,
        Surprised
    }
    public ENpcState_BM currState;

    NavMeshAgent agent;
    Animator anim;

    public GameObject[] destination;
    private Vector3[] wayPoints;

    //int currPoint = 0;
    //현재시간
    //float currTime;
    // Start is called before the first frame update
    void Start()
    {
        currState = ENpcState_BM.Walk;
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        //wayPoint = GetComponent<GameObject>();

        wayPoints = new Vector3[destination.Length + 1];
        for (int i = 0; i < destination.Length; i++)
            wayPoints[i] = destination[i].transform.position;
        wayPoints[wayPoints.Length - 1] = transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        
        switch (currState)
        {         
            case ENpcState_BM.Walk:
                UpdateWalk();
                break;
            case ENpcState_BM.Nod:
                UpdateNod();
                break;
            case ENpcState_BM.Surprised:
                UpdateSurprised();
                break;
        }
    }

    public void ChangState(ENpcState_BM state)
    {
        print(currState + "-->" + state);
        currState = state;
        //currTime = 0;
        switch (currState)
        {
            case ENpcState_BM.Walk:
                anim.SetTrigger("Walk");
                break;
            case ENpcState_BM.Nod:
                anim.SetTrigger("Nod");
                break;
            case ENpcState_BM.Surprised:
                anim.SetTrigger("Surprised");
                break;
        }
    }
    
    void UpdateWalk()
    {
        Patrol();
    }
    void UpdateNod()
    {
        /*currTime += Time.deltaTime;
        if (currTime >= 5)
        {
            currTime = 0;
            
        }*/
        
        ChangState(ENpcState_BM.Walk);
    }
    void UpdateSurprised()
    {
        ChangState(ENpcState_BM.Walk);
    }
    void Patrol()
    {
        for (int i = 0; i < wayPoints.Length; i++)
        {
            if (Vector3.Distance(transform.position, wayPoints[i]) <= 0.1f)
            {
                if (i != wayPoints.Length - 1)
                {
                    
                    agent.SetDestination(wayPoints[i + 1]);
                    ChangState(ENpcState_BM.Nod);
                    

                }
                else
                {
                    agent.SetDestination(wayPoints[0]);
                    //ChangState(ENpcState_BM.Nod);
                }
                    
                
                //
            }
        }
    }
}
