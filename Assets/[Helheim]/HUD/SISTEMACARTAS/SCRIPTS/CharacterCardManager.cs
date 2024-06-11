using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterCardManager : MonoBehaviour
{

    [Header("Cards Parameters")]
    public int amtOfCards;
 
    public CharacterCardScriptableObject[] characterCardSO;
    public GameObject cardPrefab;
    public Transform cardHolderTransform;

    [Header("Character Parameters")]
    public GameObject[] characterCards;

    public Texture characterIcon;
    public Sprite levelCard;
    public string nombre;
    public string descripcion;

    public float cooldown;
    public int colocados;
    
    public static GameObject casillaActual;

    private void Start(){
        characterCards = new GameObject[amtOfCards];

        for(int i = 0 ; i<amtOfCards; i++){
            AddCharacterCard(i);
        }
    }

    public void AddCharacterCard(int index){
        GameObject card = Instantiate(cardPrefab,cardHolderTransform);
        CharacterManager cardManager= card.GetComponent<CharacterManager>();

        cardManager.characterPrefab = characterCardSO[index].characterSprite;
        cardManager.levelCard= characterCardSO[index].levelCard;
        cardManager.tiempoEspera=characterCardSO[index].cooldown;
        cardManager.nombre=characterCardSO[index].nombre;
        //cardManager.panelCanvas= characterCardSO[index].panelCanvas;

        characterCards[index] = card;

        //Coje las variables 
        characterIcon = characterCardSO[index].characterIcon;
        levelCard = characterCardSO[index].levelCard;
        nombre = characterCardSO[index].nombre;
        descripcion = characterCardSO[index].descripcion;

        cooldown = characterCardSO[index].cooldown;
        colocados=characterCardSO[index].colocados;

        //Actualiza la UI
        cardManager.CardImage.sprite= levelCard;
        card.GetComponentInChildren<RawImage>().texture = characterIcon;
        card.transform.GetChild(0).Find("Nombre Personaje").GetComponent<TMP_Text>().text= "" + nombre;
        card.transform.GetChild(0).Find("Descripcion Personaje").GetComponent<TMP_Text>().text= "" + descripcion;
        

  
    }

    
}
