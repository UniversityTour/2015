using UnityEngine;
using System.Collections;

public static class Extensions{

	// INSERT EXTENSIONS HERE
	public static void Destroy(this GameObject g){
		Destroy(g);
	}

	public static Vector3 checkBoundaries(this Vector3 vec){
		if(vec.x < -8 || vec.x > 8)
			return Vector3.zero;
		else if(vec.y > 5 || vec.y < -5)
			return Vector3.zero;
		else
			return vec;
	}
}