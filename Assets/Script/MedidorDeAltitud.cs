using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody2D))]
public class MedidorDeAltitud : MonoBehaviour
{
    //Delegados
    public delegate void OnMovement();
    //
    public event OnMovement onMovement;
    
    [SerializeField]
    private UIObserver[] observers = new UIObserver[1];
    public bool hasRegisteredObservers;
    private Rigidbody2D _rigidbody2D;
    
    float alturaActual;
    float alturaMaxima;
    float acumuladoAlturaMaxima;
    bool puntoMaximo;
    private string sAlturaMaxima;
    private string sAlturaActual;

    public string SAlturaActual => sAlturaActual;
    public string SAlturaMaxima => sAlturaMaxima;

    public void IniciarMedidorDeAltitud()
    {
        if (observers !=null)
        {
            observers[0]=(GameObject.Find("GameManager").GetComponent<UIObserver>());
        }
        
        _rigidbody2D = GetComponent<Rigidbody2D>();
        RegisterObservers();
        NotifyObservers();
    }
    // Update is called once per frame

    /// <summary>
    /// revisa si la botella a superado su altura maxima para actualizarla y detecta la altura actual
    /// </summary>
    private void CalcularAlturas()
    {
        alturaActual = _rigidbody2D.position.y * 3;
        if (alturaActual > alturaMaxima)
        {
            alturaMaxima = alturaActual; 
        }

        sAlturaMaxima = ((int)alturaMaxima) +"m";
        sAlturaActual = ((int)alturaActual) +" Altura actual";
        NotifyObservers();
    }

    private void Update()
    {
        if (_rigidbody2D.velocity.magnitude > 2f)
        {
            CalcularAlturas();
        }
    }


    private void UnregisterObservers()
    {
        hasRegisteredObservers = false;

        foreach (UIObserver observer in observers)
        {
            observer.UnregisterAltitud(this);
        }
    }
    private void RegisterObservers()
    {
        foreach (UIObserver observer in observers)
        {
            observer.RegisterAltitud(this);
        }

        hasRegisteredObservers = true;
    }
    

    private void NotifyObservers()
    {
        if (onMovement != null)
        {
            onMovement();
        }
    }
}
