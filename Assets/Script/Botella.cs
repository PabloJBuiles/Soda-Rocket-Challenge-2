using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Botella : MonoBehaviour
{
    public static Botella instance = null;
    GameManager gm;

    PowerUps powerUps;
    MedidorDePoder medidor;
    ZoomCamara zoomCamara;
    Lanzamiento lanzamiento;
    MedidorDeAltitud medidorDeAltitud;
    [SerializeField] GameObject alturaMax;


    [SerializeField] float zoomMax, zoomMin, velZoom, zoom;

    [SerializeField] float fuerzaInicial;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }else if(instance != this){
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        //TextLanzamientos
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        alturaMax.AddComponent<MedidorDeAltitud>();
        medidorDeAltitud = alturaMax.GetComponent<MedidorDeAltitud>();
        this.gameObject.AddComponent<ZoomCamara>();
        this.gameObject.AddComponent<Lanzamiento>();
        zoomCamara = GetComponent<ZoomCamara>();
        lanzamiento = GetComponent<Lanzamiento>();
        GameObject.Find("IndicadorFuerza").AddComponent<MedidorDePoder>();
        medidor = GameObject.Find("IndicadorFuerza").GetComponent<MedidorDePoder>();

        GameObject.Find("Canvas").AddComponent<PowerUps>();
        powerUps = GameObject.Find("Canvas").GetComponent<PowerUps>();

        zoomCamara.IniciarZoom(this.gameObject,zoom,zoomMax,zoomMin,velZoom);
        lanzamiento.IniciarLanzamiento();
        medidorDeAltitud.IniciarMedidorDeAltitud();
        Invoke("AjustarFuerzaInicio", 0.1f);
    }
    public void Lanzamiento()
    {
      if(medidorDeAltitud.ReiniciarTextos(lanzamiento.LanzamientoBotella(gm.FuezaInicial, gm.LanzamientosRestantes1)))
        {
            ActualizarLanzamientos();
        }
        
    }
    public void ConvertirDistanciaMaximaEnFuerza()
    {
        gm.FuezaInicial += medidorDeAltitud.ConvertirDistanciaTotal() / 10;
        medidor.AjustarFuerza(gm.FuezaInicial, 115);
    }
    public void AjustarFuerzaInicio()
    {
        medidor.AjustarFuerza(gm.FuezaInicial, 115);
    }

    public void ActualizarLanzamientos()
    {
        gm.LanzamientosRestantes1--;
        powerUps.ActualizarLanzamientos(gm.LanzamientosRestantes1,gm.LanzamientosMaximos);
    }
}
