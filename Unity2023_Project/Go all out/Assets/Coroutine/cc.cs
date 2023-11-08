using UnityEngine;
using System.Collections;

public class cc : MonoBehaviour
{
	public float smoothing = 4f;



	public Vector3 ps
	{
		get { return target; }
		set
		{
			target = value;
			
			StopCoroutine("Movement");
			StartCoroutine("Movement", target);
		}
	}
	
	
	public Vector3 target;
	
	
	IEnumerator Movement (Vector3 target)
	{
		while(Vector3.Distance(transform.position, target) > 0.05f)
		{
			transform.position = Vector3.Lerp(transform.position, target, smoothing * Time.deltaTime);
			
			yield return null;
		}
	}
}