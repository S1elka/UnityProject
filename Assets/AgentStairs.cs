using UnityEngine;
using UnityEngine.AI;

public class AgentStairs : MonoBehaviour
{
    public Transform[] points;
    private UnityEngine.AI.NavMeshAgent agent;
    private int curPoint; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent =  GetComponent<UnityEngine.AI.NavMeshAgent>();
        curPoint = 0;
        SetNextPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.remainingDistance< 0.5){
            SetNextPoint();
        }
    }

    void SetNextPoint(){
        agent.SetDestination(points[curPoint].position);
        curPoint = (curPoint+1)%points.Length;
    }
}