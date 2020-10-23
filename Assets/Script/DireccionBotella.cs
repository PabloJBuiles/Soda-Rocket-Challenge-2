using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DireccionBotella : MonoBehaviour
{
    Gyroscope m_Gyro;
    private void Start()
    {
        m_Gyro = Input.gyro;
        m_Gyro.enabled = true;
    }

    void Update()
    {
        if (!Lanzamiento.Lanzado)
        {
            
            this.transform.rotation = GyroToUnity(m_Gyro.attitude.normalized);
        }

    }
    private  Quaternion GyroToUnity(Quaternion q)
    {
        var rotation = transform.rotation;
        return new Quaternion(rotation.eulerAngles.x, rotation.eulerAngles.y, -q.z, -q.w);
    }
}
