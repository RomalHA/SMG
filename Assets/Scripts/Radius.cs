using UnityEngine;
using System.Collections;

public class Radius : MonoBehaviour {

    public int speed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * speed));
    }
}
