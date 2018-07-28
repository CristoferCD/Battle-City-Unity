using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

    private Camera mainCamera;
    private GameObject target;

	// Use this for initialization
	void Start () {
        mainCamera = GetComponent<Camera>();
        target = GameObject.Find("MainTank");
	}
	
	void LateUpdate () {
        mainCamera.transform.position = new Vector3(target.transform.position.x, 
                                                    target.transform.position.y + 12,
                                                    target.transform.position.z - 16);
    }
}
