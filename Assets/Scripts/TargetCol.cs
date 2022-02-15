using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetCol : MonoBehaviour {
    private TargetSpawn targetSpawn;
    
    void Awake()
    {
        targetSpawn = GameObject.Find("Plane").GetComponent<TargetSpawn>();
    }

    private void OnCollisionEnter(Collision col) // Ball collision with target, destroys game object 
    { 
        if (col.gameObject.name != "Plane")
        {
            GameObject.Destroy(col.gameObject);
            targetSpawn.SpawnTarget();
            targetSpawn.IncrementScore();
            GameObject.Destroy(this.gameObject);
        }
    }

}
