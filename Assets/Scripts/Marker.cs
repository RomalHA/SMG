using UnityEngine;
using System.Collections;

public class Marker : MonoBehaviour {

    public int speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, Time.deltaTime * speed, 0));
	}
}
