using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MedidorDePoder : MonoBehaviour
{
    Image indicadorFuerza;
    // Start is called before the first frame update
    void Start()
    {
        indicadorFuerza = GetComponent<Image>();
    }
    public void AjustarFuerza(float fuerza, float fuerzaMaxima)
    {
        if (fuerza > fuerzaMaxima)
        {
            fuerza = fuerzaMaxima;
        }
        indicadorFuerza.fillAmount = (fuerza) / fuerzaMaxima;
    }

}
