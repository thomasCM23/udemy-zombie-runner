using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Helicopter : MonoBehaviour {
    
   

    public bool called;
    private Rigidbody rb;
    private Transform landingArea;

    public Transform BeforeMountain; 
    public float speed = .1F;
    private float startTime;
    private float journeyLength;

    private bool StartDecenting = false;
    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        called = false;

    }
    void Update()
    {
        if(StartDecenting)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(BeforeMountain.position, landingArea.position, fracJourney);
        }
    }
	
    void OnDispatchHelicopter()
    {
        called = true;
        landingArea = GameObject.FindGameObjectWithTag("Landing").transform;
        rb.velocity = (BeforeMountain.position - transform.position).normalized * 50f;
        called = true;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "MidPoint")
        {
            startTime = Time.time;
            StartDecenting = true;
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;
            journeyLength = Vector3.Distance(BeforeMountain.position, landingArea.position);
        }
        if (other.transform.GetComponent<PlayerScript>())
        {
            SceneManager.LoadScene("Start");
        }
    }
}
