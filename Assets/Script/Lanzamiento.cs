using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Lanzamiento : MonoBehaviour
{

    Transform transformInicial;
    int lanzamientosDiponibles = 20;//cantidad de lanzamientos iniciales
   
    private new Rigidbody2D rigidbody;
    
    private bool lanzado = false;//VERIFICAR SI LA BOTELLA FUE LANZADA SRRY NMAYUS    
    // Start is called before the first frame update

    public void IniciarLanzamiento()
    {

        rigidbody = GetComponent<Rigidbody2D>();
        this.gameObject.AddComponent<PolygonCollider2D>();
        transformInicial = GameObject.Find("PosicionInicial").GetComponent<Transform>();
        Debug.Log(lanzamientosDiponibles);
    }
    /// <summary>
    /// Pone la botella en su posicion inicial
    /// Agrega fuerza a la botella
    /// activa la gravedad
    /// 
    /// </summary>
    public bool LanzamientoBotella(float fuerzaInicial,int LanzamientosRestantes)
    {
            if (!lanzado && fuerzaInicial > 0 && LanzamientosRestantes > 0)
            {
                transform.position = transformInicial.position;
                transform.rotation = transformInicial.rotation;
                rigidbody.freezeRotation = false;
                rigidbody.gravityScale = 1;
                lanzado = true;
                //Vector2 mvector = new Vector2(Input.acceleration.x, Input.acceleration.y * -1);

                rigidbody.AddTorque(UnityEngine.Random.Range(-4.0f, 4.0f));
      
                rigidbody.AddForce(Vector2.up * fuerzaInicial*50);
                Debug.Log(lanzamientosDiponibles + "Despues del lanzamiento");
                return true;
            }
                return false;
    }
    private void OnCollisionStay2D(Collision2D collision) => Preparado();
    //verifica si la botella dejo de moverse para volver a hacer el lanzamiento.
    public void Preparado()
    {
        if (rigidbody.velocity.magnitude < 0.05f && lanzado)
        {
            lanzado = false;
            rigidbody.freezeRotation = true;
            rigidbody.gravityScale = 0;
            rigidbody.velocity = Vector2.zero;
            Debug.Log("Preparado");
        }
    }//solucionar con rayos(solucionado :3)

}
