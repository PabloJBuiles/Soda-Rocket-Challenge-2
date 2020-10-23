using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AgitacionBotella : MonoBehaviour
{
    
     //Delegados
     public delegate void OnShake();
    //
     public event OnShake onShake;
    //
    private static float fuerzaBotella;
    [SerializeField] private float fuerzaMaxima;
    [SerializeField] private float aumentoDeFuerza;

    private float lowPassFilterFactor;
    private Vector3 aceleracionMobil;
    //lista de observers
    [SerializeField]
    private Observer[] observers;
    
    //revisar si se registraron 
    private bool hasRegisteredObservers;
    private const float accelerometerUpdateInterval = 1.0f / 60.0f;
    private const float lowPassKernelWidthInSeconds = 1.0f;

    private float shakeDetectionThreshold = 2.0f;
    // Start is called before the first frame update
    private Vector3 lowPassValue;
    private void Start()
    {
        NotifyObservers();
        lowPassFilterFactor = accelerometerUpdateInterval / lowPassKernelWidthInSeconds;
        lowPassValue = Input.acceleration;
        shakeDetectionThreshold *= shakeDetectionThreshold;
       
       RegisterObservers();
    }

     private void RegisterObservers()
     {
         foreach (Observer observer in observers)
         {
             observer.Register(this);
         }
    
         hasRegisteredObservers = true;
     }
    private void UnregisterObservers()
    {
        hasRegisteredObservers = false;

        foreach (Observer observer in observers)
        {
            observer.Unregister(this);
        }
    }
    // Update is called once per frame
    void Update()
    {
     
            Shake();  
        
        
    }

    /// <summary>
    /// Calcula la fuerza de lanzamiento viendo si el jugador esta agitando su celular
    /// </summary>
    private void Shake()
    {
     
            var acceleration = Input.acceleration;
            lowPassValue = Vector3.Lerp(lowPassValue, acceleration, lowPassFilterFactor);
            var deltaAcceleration = acceleration - lowPassValue;
            // verificando si hay agitacion
            if (deltaAcceleration.sqrMagnitude >= shakeDetectionThreshold && !Lanzamiento.Lanzado)
            {
                if (fuerzaMaxima >= fuerzaBotella)
                {
                    fuerzaBotella += Time.deltaTime * aumentoDeFuerza;
                    NotifyObservers();
                }
                else
                {
                    fuerzaBotella = fuerzaMaxima;
                }
            }
            else
            {
                if (fuerzaBotella > 0)
                {
                    fuerzaBotella -= Time.deltaTime * (aumentoDeFuerza/2);
                    NotifyObservers();
                }

            }
   
        

    }
    /// <summary>
    /// Notifica al observaror
    /// </summary>
    private void NotifyObservers()
     {
         if (onShake != null)
         {
             onShake();
         }
     }
    

    public static float FuerzaBotella => fuerzaBotella;
    public float FuerzaMaxima => fuerzaMaxima;
}
