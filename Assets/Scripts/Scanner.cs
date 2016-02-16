using UnityEngine;
using System.Collections;

public class Scanner : MonoBehaviour {

    private static Scanner _instance;

    public float speed = 1f;
    public Transform sprite;

    public Vector3 startScale = new Vector3(0.01f, 0.01f, 1);

    private bool _active = false;
    private float _timer = 0;
    private Vector3 _origScale;
    private Vector3 _startScale;

    // Use this for initialization
    void Start()
    {
        _origScale = sprite.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(_active)
        {
            sprite.localScale = Vector3.Lerp(startScale,
                                      _origScale,
                                      speed * _timer);
            _timer = Mathf.Clamp(_timer + Time.deltaTime, 0.0f, 1.0f / speed);

            if (sprite.localScale == _origScale)
            {
                _active = false;
                sprite.gameObject.SetActive(false);
            }
        }
    }

    public void Scan()
    {
        sprite.localScale = startScale;
        _timer = 0;
        sprite.gameObject.SetActive(true);
        _active = true;
    }

    public static Scanner Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<Scanner>();
            return _instance;
        }
    }
}
