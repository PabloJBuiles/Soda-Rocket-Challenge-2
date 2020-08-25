using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUps : MonoBehaviour
{
    Text textLanzamientos;
    // Start is called before the first frame update
    void Start()
    {
        textLanzamientos = GameObject.Find("TextLanzamientos").GetComponent<Text>();
    }

    public void ActualizarLanzamientos(int lanzamientosActuales, int lanzamientosMaximos)
    {
        textLanzamientos.text = lanzamientosActuales + "/" + lanzamientosMaximos;
    }
}
