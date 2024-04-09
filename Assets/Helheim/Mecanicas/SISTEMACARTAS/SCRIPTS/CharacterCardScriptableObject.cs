using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Personajes/Nueva Carta",fileName="Nueva Carte De Personaje")]
public class CharacterCardScriptableObject : ScriptableObject
{
   public Texture characterIcon;
   public GameObject characterSprite;
   public GameObject panelCanvas;
   public Sprite levelCard;
   public string nombre;
   public string descripcion;

   public float cooldown;
}
