using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.UI;
public class AgregarBotellas : MonoBehaviour
{
    List<Image> imageBotellas = new List<Image>();
    private GameObject comprarEquiparBotella;

    [SerializeField]
    GameObject comprarEquiparBotellaPrefab;
    private GameManager gameManager;

    private List<BotonCombrarOEquipar> combrarOEquipar = new List<BotonCombrarOEquipar>();
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        for (var i = 0; i < gameManager.BotellasSprites.Length; i++)
        {
            Instantiate(comprarEquiparBotellaPrefab, transform);
        }
        

       
        foreach (var VARIABLE in GameObject.FindGameObjectsWithTag("Botella"))
        {
            imageBotellas.Add(VARIABLE.GetComponent<Image>());
            combrarOEquipar.Add(VARIABLE.GetComponent<BotonCombrarOEquipar>());
        }

        for (var i = 0; i < gameManager.BotellasSprites.Length; i++)
        {
            imageBotellas[i].sprite = gameManager.BotellasSprites[i];
            combrarOEquipar[i].idBotella = i;
        }
    }

    public void ActualizarGameObjects()
    {
        foreach (var VARIABLE in combrarOEquipar)
        {
            VARIABLE.ActualizarGameObject();
        }
    }

}
