using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalKeeper : MonoBehaviour
{
    [SerializeField] 
    public Vector3 m_rightPos; // Goalkeeper Movement Distance Right (Max)

    [SerializeField] 
    public Vector3 m_leftPos; // Goalkeeper Movement Distance Left (Max)

    [SerializeField] 
    public float m_speed; // Goalkeeper Speed

    void Update()
    {
        if (m_speed > 0.0f)
        {
            transform.position += (m_rightPos - transform.position).normalized * m_speed * Time.deltaTime;
            if ((m_rightPos - transform.position).sqrMagnitude < 0.01f)
                m_speed *= -1.0f;
        }
        else if (m_speed < 0.0f)
        {
            transform.position += (m_leftPos - transform.position).normalized * -m_speed * Time.deltaTime;
            if ((m_leftPos - transform.position).sqrMagnitude < 0.01f)
                m_speed *= -1.0f;
        }
    }
}
