using System.Collections;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class FlashLightAT : ActionTask {
		private Renderer renderer;
		private Color[] colors = {Color.green, Color.yellow, Color.red};
		private int colorInd;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			renderer = agent.GetComponent<Renderer>();
			
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            renderer.material.color = Color.white;
			StartCoroutine(Countdown());
			EndAction(true);
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}

		IEnumerator Countdown()
		{
			//for(int i = 0; i < colors.Length; i++)
			//{
			//	Color start = renderer.material.color;
			//	Color target = colors[i];

			//	float duration = 1f;
			//	float timer = 0f;

			//	while(timer < duration)
			//	{
			//		renderer.material.color = Color.Lerp(start, target, timer/duration);
			//		timer += Time.deltaTime;
			//		yield return null;
			//	}
			//}
			while (colorInd < colors.Length)
			{
				yield return new WaitForSeconds(1f);
				renderer.material.color = colors[colorInd];
				colorInd++;
			}
		}
	}
}