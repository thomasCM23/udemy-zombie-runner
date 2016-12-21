using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
    public float minAttackVal;
    public float maxAttackVal;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public float Attack()
    {
        return Random.Range(minAttackVal, maxAttackVal);
    }
}
