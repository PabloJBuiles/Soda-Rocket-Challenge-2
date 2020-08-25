using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    // Start is called before the first frame update
    [SerializeField] float distanciaTotal, fuezaInicial;
    [SerializeField] int LanzamientosRestantes = 20;
    [SerializeField] int lanzamientosMaximos = 20;
    

    public float DistanciaTotal { get => distanciaTotal; set => distanciaTotal = value; }
    public float FuezaInicial { get => fuezaInicial; set => fuezaInicial = value; }
    public int LanzamientosRestantes1 { get => LanzamientosRestantes; set => LanzamientosRestantes = value; }
    public int LanzamientosMaximos { get => lanzamientosMaximos; set => lanzamientosMaximos = value; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

}
