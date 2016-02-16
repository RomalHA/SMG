using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {

    public Transform target;
    private Vector3 _targetPosition;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        _targetPosition = target.position;
        transform.position = new Vector3(_targetPosition.x, transform.position.y, _targetPosition.z);
	}
}
