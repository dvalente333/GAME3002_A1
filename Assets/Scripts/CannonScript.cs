using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    [SerializeField]
    private GameObject cannonballInstance;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    [Range(10f, 80f)]
    private float angle = 45f;

    [SerializeField]
    [Range(10f, 50f)]
    private float barrelSpeed = 10f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                FireCannonAtPoint(hitInfo.point);
            }
        }
        if (Input.GetKey(KeyCode.W))
            angle = Mathf.Clamp(angle - barrelSpeed * Time.deltaTime, 10f, 80f);
        if (Input.GetKey(KeyCode.S))
            angle = Mathf.Clamp(angle + barrelSpeed * Time.deltaTime, 10f, 80f);
        transform.eulerAngles = new Vector3(0f,0f,90f-angle);
    }

    private void FireCannonAtPoint(Vector3 point)
    {
        var velocity = BallisticVelocity(point, angle);
        Debug.Log("Firing at " + point + " velocity " + velocity);

        GameObject cannonBall = GameObject.Instantiate(cannonballInstance, spawnPoint.position, Quaternion.identity);

        cannonBall.GetComponent<Rigidbody>().velocity = velocity;
        GameObject.Destroy(cannonBall, 4.0f);
    }

    private Vector3 BallisticVelocity(Vector3 destination, float angle)
    {
        Vector3 dir = destination - spawnPoint.position; // get Target Direction
        float height = dir.y; // get height difference
        dir.y = 0; // retain only the horizontal difference
        float dist = dir.magnitude; // get horizontal direction
        float a = angle * Mathf.Deg2Rad; // Convert angle to radians
        dir.y = dist * Mathf.Tan(a); // set dir to the elevation angle.
        dist += height / Mathf.Tan(a); // Correction for small height differences

        // Calculate the velocity magnitude
        float velocity = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a));
        return velocity * dir.normalized; // Return a normalized vector.
    }
}

// Credits: https://unity3d.college/2017/06/30/unity3d-cannon-projectile-ballistics/
//          http://answers.unity3d.com/comments/236712/view.html