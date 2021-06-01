using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshAgentOne : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform[] WayPoints;

    [SerializeField] private Observe ItIsPlayer;

    [SerializeField] private string SpeedWalk;
    private Animator Walk;
    private float SpeedTransform;
    private int SpeedWalkID;

    private static NavMeshAgent _agent;
    private int _currentPointIndex;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        Walk = GetComponent<Animator>();
        SpeedWalkID = Animator.StringToHash(SpeedWalk);
    }

    private void Start()
    {        
        _agent.SetDestination(WayPoints[1].position);
    }

    private void Update()
    {

       if(ItIsPlayer.itIsPlayer)
        {
            Debug.LogWarning(ItIsPlayer.itIsPlayer);
            Chase();
        }

       if(!ItIsPlayer.itIsPlayer)
        {
            Invoke(nameof(Patrul), 3.0f);
        }

/*       SpeedTransform = 
       Walk.speed = */
    }

    private void Patrul()
    {

        if (_agent.remainingDistance < 1)
        {
            _currentPointIndex = (_currentPointIndex + 1) % WayPoints.Length;
            _agent.SetDestination(WayPoints[_currentPointIndex].position);
        }

    }

    private void Chase()
    {
        _agent.SetDestination(_player.position);
    }    

    private void Animtions()
    {
        
    }
}
