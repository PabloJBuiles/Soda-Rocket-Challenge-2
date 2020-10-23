using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;



    private int mentas;
    [SerializeField] private Sprite[] botellasSprites;

    private List<bool> botellasAdquiridas;

    public List<bool> BotellasAdquiridas => botellasAdquiridas;

    public int idBotellaEnUso;

   
    public  Sprite[] BotellasSprites => botellasSprites;

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
    {/*
        for (int i = 0; i < botellasSprites.Length; i++)
        {
            botellasAdquiridas.Add(new bool());
        }

        botellasAdquiridas[0] = true;
        */
    }

    public bool ComprarBotella(int idBotella)
    {
        if (mentas < 100) return false;
        mentas -= 100;
        botellasAdquiridas[idBotella] = true;
        return true;

    }

}
