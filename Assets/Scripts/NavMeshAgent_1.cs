using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshAgent_1 : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform[] WayPoints;
    private static NavMeshAgent _agent;
    private int _currentPointIndex;
    private Vector3 _radius;
    protected private bool ItIsPlayer;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
       // _player = GetComponent<Transform>();
    }

    private void Start()
    {        
        _agent.SetDestination(WayPoints[1].position);
    }

    private void Update()
    {
       Invoke(nameof(Patrul), 5.0f);
       
               

    }

    private void Patrul()
    {
        Invoke(nameof(Patrul), 15.0f);
        if (_agent.remainingDistance < 1)
        {
            _currentPointIndex = (_currentPointIndex + 1) % WayPoints.Length;
            _agent.SetDestination(WayPoints[_currentPointIndex].position);
        }

    }

    public static void Stop()
    {
        NavMeshAgent_1 x = new NavMeshAgent_1();
        x.Patrul();
    }

    public static void Chase(Transform _player)
    {
        
        _agent.SetDestination(_player.position);
        
    }
}
