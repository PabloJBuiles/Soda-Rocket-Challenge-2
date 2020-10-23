using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Lanzamiento : MonoBehaviour
{

    private new Rigidbody2D rigidbody;
    [SerializeField] private float stopTime;
    private static bool lanzado = false;//VERIFICAR SI LA BOTELLA FUE LANZADA SRRY NMAYUS   
    
    public static bool Lanzado => lanzado;

    // Start is called before the first frame update
    private AgitacionBotella agitacionBotella;
    public void IniciarLanzamiento()
    {
        
        rigidbody = GetComponent<Rigidbody2D>();
        gameObject.AddComponent<PolygonCollider2D>();
    }
    /// <summary>
    /// Pone la botella en su posicion inicial
    /// Agrega fuerza a la botella
    /// activa la gravedad
    /// 
    /// </summary>
    public bool LanzamientoBotella()
    {
            if (!lanzado && AgitacionBotella.FuerzaBotella > 5)
            {
                
                rigidbody.freezeRotation = false;
                rigidbody.gravityScale = 1;
                lanzado = true;
                //Vector2 mvector = new Vector2(Input.acceleration.x, Input.acceleration.y * -1);

                //rigidbody.AddTorque(UnityEngine.Random.Range(-4.0f, 4.0f));
      
                rigidbody.AddForce(transform.right *  AgitacionBotella.FuerzaBotella, ForceMode2D.Impulse);
            
                return true;
            }
            return false;
    }
    private void OnCollisionStay2D(Collision2D collision) => Preparado();
    private void OnCollisionExit(Collision other) => stopTime = 0;


    /// <summary>
    ///verifica si la botella dejo de moverse para volver a hacer el lanzamiento. 
    /// </summary>
    public void Preparado()
    {
        if (rigidbody.velocity.magnitude < 0.03f && lanzado && stopTime > 3)
        {
            lanzado = false;
            rigidbody.freezeRotation = true;
            rigidbody.gravityScale = 0;
            rigidbody.velocity = Vector2.zero;
            Debug.Log("Preparado");
            stopTime = 0;
        }
        else if(lanzado)
        {
            stopTime += Time.deltaTime;
        }
           
    }//solucionar con rayos(solucionado :3)


}
