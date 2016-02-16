using UnityEngine;
using System.Collections;

public class TargetMarker : MonoBehaviour {

    public Camera cam;
    public Transform target;
    public Vector3 targetPos;
    public Vector3 screenCenter;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


        //targetPos = cam.WorldToScreenPoint(target.transform.position);

        //screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);

        //float tarAngle = (Mathf.Atan2(targetPos.x - screenCenter.x, Screen.height - targetPos.y - screenCenter.y) * Mathf.Rad2Deg) + 90;

        //if (tarAngle < 0) tarAngle += 360;


        //Vector3 targetDir = target.transform.position - cam.transform.position;
        //Vector3 forward = cam.transform.forward;
        //float angle = Vector3.Angle(targetDir, forward);

        //if (angle < 90){
        //    transform.localRotation = Quaternion.Euler(0, 0, -tarAngle);
        //} else {
        //    transform.localRotation = Quaternion.Euler(0, 0, tarAngle);
        //}
        targetPos = target.position;
        transform.LookAt(targetPos);
        Quaternion rot = transform.rotation;
        Vector3 rotVec = rot.eulerAngles;
        rotVec.x = 0;
        transform.rotation = Quaternion.Euler(rotVec);
    }
}
