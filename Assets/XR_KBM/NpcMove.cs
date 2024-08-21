using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
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
    public Vector3[] wayPoints;
    //오리진
    int currWayPoint = 0;
    private float currTime;

    //Nod 크리에이트 타임
    public float nodTime = 2f;
    //서프라이즈 크이에이트 타임
    public float surprisedTime = 4f;


    public GameObject[] arts;
    public GameObject closestObject;

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


        agent.SetDestination(wayPoints[currWayPoint]);

        arts =GameObject.FindGameObjectsWithTag("art");
       

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
                agent.SetDestination(wayPoints[currWayPoint]);
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
        currTime += Time.deltaTime;
        if (currTime >= nodTime)
        {
            currTime = 0;
            currWayPoint++;
            if(currWayPoint >= wayPoints.Length)
            {
                currWayPoint = 0;
            }
            //currWayPoint %= wayPoints.Length;
            ChangState(ENpcState_BM.Walk);            
        }
        
    }
    //float s_currTime;
    void UpdateSurprised()
    {
        currTime += Time.deltaTime;
        if (currTime >= surprisedTime)
        {
            currTime = 0;
            currWayPoint++;
            if (currWayPoint >= wayPoints.Length)
            {
                currWayPoint = 0;
            }
            //currWayPoint %= wayPoints.Length;
            ChangState(ENpcState_BM.Walk);
        }
        
    }
    void Patrol()
    {
        if (Vector3.Distance(transform.position, wayPoints[currWayPoint]) <= 0.1f)
        {
            //ChangState(ENpcState_BM.Nod);
            if (currWayPoint != 2)
            {
                ChangState(ENpcState_BM.Nod);
                //ChangState(ENpcState_BM.Surprised);
            }
            else
            {
                ChangState(ENpcState_BM.Surprised);

            }

            closestObject = FindClosestObject();
            if (closestObject != null)
            {
                // 가장 가까운 오브젝트를 바라봄
                Vector3 look = closestObject.transform.position - transform.position;
                look.y = 0;
                look.Normalize();
                transform.forward = look;
                //transform.LookAt(closestObject.transform);
            }

        }
        //for (int i = 0; i < wayPoints.Length; i++)
        //{
        //    if (Vector3.Distance(transform.position, wayPoints[i]) <= 0.1f)
        //    {
        //        if (i != wayPoints.Length - 1)
        //        {

            //            agent.SetDestination(wayPoints[i + 1]);
            //            ChangState(ENpcState_BM.Nod);


            //        }
            //        else
            //        {
            //            agent.SetDestination(wayPoints[0]);
            //            //ChangState(ENpcState_BM.Nod);
            //        }


            //        //
            //    }
            //}
    }
    GameObject FindClosestObject()
    {
        GameObject closest = null;
        float closestDistance = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach (GameObject obj in arts)
        {
            if (obj != null) // 배열에 null이 포함되어 있을 수 있으므로 체크
            {
                float distance = Vector3.Distance(obj.transform.position, currentPosition);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closest = obj;
                }
            }
        }

        return closest;
    }
}
