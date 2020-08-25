using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MedidorDeAltitud : MonoBehaviour
{
    // Start is called before the first frame update
    Transform tranformDeBotella;
    Text textMax;
    Text textMetrosTotales;
    float alturaActual;
    float alturaMaxima;
    float acumuladoAlturaMaxima;
    bool puntoMaximo;

 
    public void IniciarMedidorDeAltitud()
    {
        textMax = GetComponent<Text>();
        textMetrosTotales = GameObject.Find("AlturaActual").GetComponent<Text>();
        tranformDeBotella = GameObject.Find("Botella").GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        CalcularAlturas();
    }

    private void CalcularAlturas()
    {
        alturaActual = tranformDeBotella.position.y;
        if (alturaActual > alturaMaxima)
        {
            alturaMaxima = alturaActual;
            puntoMaximo = false;
        }
        else if (!puntoMaximo)
        {
            acumuladoAlturaMaxima += alturaMaxima;
            puntoMaximo = true;
        }
        textMax.text = ((int)alturaMaxima).ToString()+"m";
        textMetrosTotales.text = ((int)acumuladoAlturaMaxima).ToString()+" Altura maxima total";
    }
    public bool ReiniciarTextos(bool puedeReinicial)
    {
        if (puedeReinicial) {
            alturaActual = 0;
            alturaMaxima = 0;
            return true;
        }
        return false;
    }

    public float ConvertirDistanciaTotal()
    {
        float distanciaAConvertir = acumuladoAlturaMaxima;
        acumuladoAlturaMaxima = 0;
        return distanciaAConvertir;
    }
}
