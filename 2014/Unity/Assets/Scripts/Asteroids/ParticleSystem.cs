using UnityEngine;
	public class ParticleSystem : MonoBehaviour 
	{
		void LateUpdate () 
		{
			if (!particleSystem.IsAlive())
				Object.Destroy (this.gameObject);	
		}
	}