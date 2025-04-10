using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class RestAT : ActionTask {
		float timer;
		public float restTimer = 3f;
		float initSpeed;
        NavMeshAgent navAgent;
        
        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
            navAgent = agent.GetComponent<NavMeshAgent>();
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			timer = 0;
			initSpeed=navAgent.speed;
			navAgent.speed = 0;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			timer += Time.deltaTime;
			if(timer>restTimer)
			{
				navAgent.speed = initSpeed;
				EndAction();
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