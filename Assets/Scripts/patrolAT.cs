using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class patrolAT : ActionTask {
		NavMeshAgent navAgent;
		public Transform pointsParent;
		Transform[] points;
		int desIndex;
        public Transform player;
        public float distance = 10f;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			navAgent = agent.GetComponent<NavMeshAgent>();
			desIndex = 1;
			points=pointsParent.GetComponentsInChildren<Transform>();
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			navAgent.SetDestination(points[desIndex].position);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			if(Vector3.Distance(player.position, navAgent.transform.position) < distance)
			{
				EndAction();
			}
            if (Vector3.Distance(navAgent.transform.position, navAgent.destination) < 1.1f)
			{
				desIndex=desIndex%(points.Length-1)+1;
                navAgent.SetDestination(points[desIndex].position);
            }
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}