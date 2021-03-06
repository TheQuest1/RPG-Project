using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RPG.Core;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour, IAction
    {
        [SerializeField] Transform target;
        NavMeshAgent navMestAgent;

        void Start()
        {
            navMestAgent = GetComponent<NavMeshAgent>();
            
        }

        void Update()
        {
            UpdateAnimator();
        }

        public void StartMoveAction(Vector3 destination)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            MoveTo(destination);
        }
        public void MoveTo(Vector3 destination)
        {
            navMestAgent.SetDestination(destination);
            navMestAgent.isStopped = false;
        }

        public void Cancel()
        {
            navMestAgent.isStopped = true;
        }

    
        private void UpdateAnimator()
        {
            Vector3 velocity = navMestAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        }

    }
}
