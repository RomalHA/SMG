using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

    public Transform marker;

    private bool _bounce = false;
    private bool _running = false;

    private Animation _anim;

    private NavMeshAgent _navAgent;

    private Vector3 _markerScale;
    private Vector3 _targetPosition;

	// Use this for initialization
	void Start () {
        _anim = GetComponent<Animation>();
        _navAgent = GetComponent<NavMeshAgent>();
        _markerScale = marker.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit mouseHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out mouseHit))
            {
                NavMeshHit hit;

                if (NavMesh.SamplePosition(mouseHit.point, out hit, 2.0f, NavMesh.AllAreas))
                {
                    
                    NavMeshPath path = new NavMeshPath();
                    Vector3 result;

                    NavMesh.CalculatePath(transform.position, hit.position, NavMesh.AllAreas, path);
                    if (path.status == NavMeshPathStatus.PathComplete)
                    {
                        result = hit.position;
                        result.y = transform.position.y;

                        marker.gameObject.SetActive(true);
                        _bounce = true;
                        marker.position = new Vector3(result.x, marker.position.y, result.z);

                        _navAgent.SetDestination(result);
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
            Scanner.Instance.Scan();

        if (_bounce)
            marker.localScale = new Vector3(_markerScale.x + Mathf.PingPong(Time.time/5, 0.05f), _markerScale.y + Mathf.PingPong(Time.time / 5, 0.05f), _markerScale.z + Mathf.PingPong(Time.time / 5, 0.05f));

        if (marker.localScale.x < _markerScale.x + 0.01f)
            _bounce = false;

        if(_running)
        {
            if (_navAgent.velocity == Vector3.zero)
            {
                marker.gameObject.SetActive(false);
                _running = false;
                _anim.CrossFade("idle_normal");
            }
        }
        else
        {
            if(_navAgent.velocity != Vector3.zero)
            {
                _running = true;
                _anim.CrossFade("run_normal");
                _anim["run_normal"].speed = 3f;
            }
        }
    }
}
