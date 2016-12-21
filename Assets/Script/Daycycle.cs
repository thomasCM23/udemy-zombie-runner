using UnityEngine;
using System.Collections;

public class Daycycle : MonoBehaviour {

    public float timeScale = 60f;
    private Quaternion startRotation;

    void Start()
    {
        startRotation = transform.rotation;
    }
	
	// Update is called once per frame
	void Update ()
    {
        float angleThisFrame = (Time.deltaTime / 360) * timeScale;
        transform.RotateAround(transform.position, Vector3.forward, angleThisFrame);
	}
}
