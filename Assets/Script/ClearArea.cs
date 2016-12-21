using UnityEngine;
using System.Collections;

public class ClearArea : MonoBehaviour {
    public float timeSinceLastTrigger = 0f;

    public bool fondClearArea = false;
	// Update is called once per frame
	void Update ()
    {
        timeSinceLastTrigger += Time.deltaTime;
        if(timeSinceLastTrigger > 5f && Time.realtimeSinceStartup > 10f && !fondClearArea)
        {
            fondClearArea = true;
            SendMessageUpwards("OnFindClearArea");
        }
	
	}
    void OnTriggerStay(Collider other)
    {
        if (other.tag != "Player")
        {
            timeSinceLastTrigger = 0f;
        }
    }
}
