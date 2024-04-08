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
        cardManager.tiempoEspera=characterCardSO[index].cooldown;
        //cardManager.panelCanvas= characterCardSO[index].panelCanvas;

        characterCards[index] = card;

        //Coje las variables 
        characterIcon = characterCardSO[index].characterIcon;
        levelCard = characterCardSO[index].levelCard;
        nombre = characterCardSO[index].nombre;
        descripcion = characterCardSO[index].descripcion;

        cooldown = characterCardSO[index].cooldown;

        //Actualiza la UI
        card.GetComponent<Image>().sprite= levelCard;
        card.GetComponentInChildren<RawImage>().texture = characterIcon;
        card.transform.Find("Nombre Personaje").GetComponent<TMP_Text>().text= "" + nombre;
        card.transform.Find("Descripcion Personaje").GetComponent<TMP_Text>().text= "" + descripcion;
        

  
    }

    
}
