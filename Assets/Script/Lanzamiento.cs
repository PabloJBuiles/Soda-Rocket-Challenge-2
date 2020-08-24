using Cinemachine;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Lanzamiento : MonoBehaviour
{

    //cambio de botalla

    //Contador de tiempo para sighuinte item gratis
    // float tiempoRestante;
    //lanzamiento en la ui    
    [SerializeField] Transform transformInicial;
    int lanzamientosDiponibles = 20;//cantidad de lanzamientos iniciales
    public DateTime LDate;
    private new Transform transform;
    [SerializeField] float fuerzaInicial;//medidor de fuerza hasta 5;
    private new Rigidbody2D rigidbody;
    private new ConstantForce2D constantForce;
    private bool lanzado = false;//VERIFICAR SI LA BOTELLA FUE LANZADA SRRY NMAYUS    
    CinemachineVirtualCamera mCam;// la camara para los zooms
    [SerializeField] float tt;
    PolygonCollider2D colliderDosDe;
    /// <summary>
    /// /Sahke
    /// </summary>
    [SerializeField] float distanciaDeAlejamiento = 1.47f;
    // Start is called before the first frame update
    void Start()
    {  
        constantForce = GetComponent<ConstantForce2D>();
        transform = GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody2D>();
        mCam = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        mCam.m_Lens.OrthographicSize = 5;
        this.gameObject.AddComponent<PolygonCollider2D>();
        colliderDosDe = GetComponent<PolygonCollider2D>();
        Debug.Log(lanzamientosDiponibles);

    }
    public void LanzamientoBotella()
    {
        if (lanzamientosDiponibles > 0)
        {
            if (!lanzado && fuerzaInicial > 0)
            {
                this.transform.position = transformInicial.position;
                this.transform.rotation = transformInicial.rotation;
                rigidbody.freezeRotation = false;
                colliderDosDe.isTrigger = true;
                rigidbody.gravityScale = 1;
                lanzado = true;
                colliderDosDe.isTrigger = false;
                Vector2 mvector = new Vector2(Input.acceleration.x, Input.acceleration.y * -1);
                rigidbody.AddForce(Vector2.up * ((fuerzaInicial * 400) + 250));
                lanzamientosDiponibles--;
                //fuerzaInicial = 0;
                Debug.Log(lanzamientosDiponibles + "Despues del lanzamiento");
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("collicion");
        if (rigidbody.velocity.magnitude < 1f && lanzado)
        {
            Invoke("Preparado", 2.1f);       
            Debug.Log("Preparado");
        }
    }
    public void Preparado()
    {
        if (rigidbody.velocity.magnitude < 0.05f)
        {
            lanzado = false;
            rigidbody.freezeRotation = true;
            rigidbody.gravityScale = 0;          
            rigidbody.velocity = Vector2.zero;
        }
    }//solucionar con rayos(solucionado :3)
}
