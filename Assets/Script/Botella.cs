using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botella : MonoBehaviour
{
    public static Botella instance = null;
    static GameManager gm;
    ZoomCamara zoomCamara;
    Lanzamiento lanzamiento;
    MedidorDeAltitud medidorDeAltitud;
    private static SpriteRenderer spriteRenderer;
    

    public MedidorDeAltitud _MedidorDeAltitud => medidorDeAltitud;
    [SerializeField] float zoomMax, zoomMin, velZoom, zoom;
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
        spriteRenderer = GetComponent<SpriteRenderer>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameObject.AddComponent<MedidorDeAltitud>();
        medidorDeAltitud = GetComponent<MedidorDeAltitud>();
        this.gameObject.AddComponent<ZoomCamara>();
        this.gameObject.AddComponent<Lanzamiento>();
        gameObject.AddComponent<DireccionBotella>();
        zoomCamara = GetComponent<ZoomCamara>();
        lanzamiento = GetComponent<Lanzamiento>();
        zoomCamara.IniciarZoom(this.gameObject,zoom,zoomMax,zoomMin,velZoom);
        lanzamiento.IniciarLanzamiento();
        medidorDeAltitud.IniciarMedidorDeAltitud();
        

    }
    
    public static void ActualizarSprite()
    {
        spriteRenderer.sprite = gm.BotellasSprites[gm.idBotellaEnUso];
    }
    public void Lanzamiento()
    {
        lanzamiento.LanzamientoBotella();
    }
}
