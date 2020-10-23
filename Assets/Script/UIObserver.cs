using System.Globalization;
using UnityEngine;
using UnityEngine.UI;


public class UIObserver : Observer
{
    [SerializeField]
    private Image forceIndicator;

    [SerializeField] private Text alturaMaxima, alturaActual;
    
    [SerializeField] private AgitacionBotella agitacionBotella;
    [SerializeField] private Botella botella;

    private float fuerzaActual;
    
    
    public override void Notify()
    {
        ShowForce();
    }

    /// <summary>
    /// Muestra la fuerza usada en la UI
    /// </summary>
    private void ShowForce()
    {
        if (forceIndicator != null)
        {
    
            forceIndicator.fillAmount = (AgitacionBotella.FuerzaBotella) / agitacionBotella.FuerzaMaxima;
        }
    }

    /// <summary>
    /// muestra la altura maxima y la actual en la UI
    /// </summary>
    private void ShowAlturas()
    {
        alturaMaxima.text = botella._MedidorDeAltitud.SAlturaMaxima;
        alturaActual.text = botella._MedidorDeAltitud.SAlturaActual;
    }
    private void Start()
    {
        ShowForce();
    }

    private void PrintAnything()
    {
        //print("Anything");
    }

    public override void Register(AgitacionBotella _agitacion)
    {
        _agitacion.onShake += Notify;
        _agitacion.onShake += PrintAnything;
    }
    
    public void RegisterAltitud(MedidorDeAltitud _medidor)
    {
        _medidor.onMovement += ShowAlturas;
        _medidor.onMovement += PrintAnything;
    }

    public override void Unregister(AgitacionBotella _agitacion)
    {
        _agitacion.onShake -= Notify;
        _agitacion.onShake -= PrintAnything;
    }
    public void UnregisterAltitud(MedidorDeAltitud _medidor)
    {
        _medidor.onMovement  -= ShowAlturas;
        _medidor.onMovement  -= PrintAnything;
    }

}

