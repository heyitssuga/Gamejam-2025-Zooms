using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; 

public class ButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image buttonImage;
    public Sprite defaultSprite; 
    public Sprite hoverSprite;  

    private void Start()
    {
        buttonImage.sprite = defaultSprite;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.sprite = hoverSprite; 
    }

    
    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.sprite = defaultSprite; 
    }
}
