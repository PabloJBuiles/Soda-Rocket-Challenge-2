using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ZoomCamara : MonoBehaviour
{
    CinemachineVirtualCamera mCam;
    [SerializeField] float zoom;
    float zoomMax, zoomMin, velZoom;
    Rigidbody2D mRigidbody2D;
    // Start is called before the first frame update

    public void IniciarZoom(GameObject rb, float zoomInicial, float zoomMaxInicial, float zoomMinInicial, float velZoomInicial)
    {
        zoom = zoomInicial;
        zoomMax = zoomMaxInicial;
        zoomMin = zoomMinInicial;
        velZoom = velZoomInicial;
        mRigidbody2D = rb.GetComponent<Rigidbody2D>();
        mCam = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        mCam.m_Lens.OrthographicSize = zoom;
        

    }
    // Update is called once per frame
    void Update()
    {
        CalcularZoom();
    }

    private void CalcularZoom()
    {
       
            if (AgitacionBotella.FuerzaBotella < zoomMin)
            {
                mCam.m_Lens.OrthographicSize = zoomMin;
            }else if (AgitacionBotella.FuerzaBotella > zoomMax)
            {
                mCam.m_Lens.OrthographicSize = zoomMax;
            }else
                mCam.m_Lens.OrthographicSize = AgitacionBotella.FuerzaBotella/3 +1 ;
        
    }
}
