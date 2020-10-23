using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonCombrarOEquipar : MonoBehaviour
{
    enum estadoBoton
    {
        paraEquipar,
        equipado,
        paraComprar
    }
    public AgregarBotellas agregarBotellas;
    private estadoBoton estado = estadoBoton.paraComprar;
    private GameManager gameManager;
    [SerializeField] private GameObject gComprar, gEquipar, gEnUso;

    public int idBotella;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();


        ActualizarGameObject();
    }

    
    public void ActualizarGameObject()
    {
        if (gameManager.BotellasAdquiridas[idBotella])
        {
            if (gameManager.idBotellaEnUso == idBotella)
            {
                estado = estadoBoton.equipado;
            }
            else
            {
                estado = estadoBoton.paraEquipar;
            }
        }
        else
        {
            estado = estadoBoton.paraComprar;
        }
        switch (estado)
        {
            case estadoBoton.paraEquipar:
                gComprar.SetActive(false);
                gEquipar.SetActive(true);
                gEnUso.SetActive(false);
                break;
            case estadoBoton.equipado:
                gComprar.SetActive(false);
                gEquipar.SetActive(false);
                gEnUso.SetActive(true);
                break;
            case estadoBoton.paraComprar:
                gComprar.SetActive(true);
                gEquipar.SetActive(false);
                gEnUso.SetActive(false);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    public void Usar()
    {
        switch (estado)
        {
            case estadoBoton.paraEquipar:
                if (gameManager.BotellasAdquiridas[idBotella])
                {
                    estado = estadoBoton.equipado;
                    gameManager.idBotellaEnUso = idBotella;
                }
                break;
           
            case estadoBoton.paraComprar:
                if (gameManager.ComprarBotella(idBotella))
                {
                    estado = estadoBoton.paraEquipar;
                }
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        agregarBotellas.ActualizarGameObjects();
    }
    
}
