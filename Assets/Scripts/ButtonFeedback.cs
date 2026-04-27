using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ButtonFeedback : MonoBehaviour,
                           IPointerEnterHandler,
                           IPointerExitHandler,
                           IPointerDownHandler, 
                           IPointerUpHandler
{
    [SerializeField] float hoverScale = 1.05f;
    [SerializeField] float clickScale = 0.9f;
    float normalScale = 1.0f;
    Selectable element;

    private void Start()
    {
        element = GetComponent<Selectable>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        normalScale = transform.localScale.x;
        if(!element.interactable) return;
        transform.localScale = new Vector3(hoverScale*normalScale, hoverScale*normalScale, 1);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = new Vector3(normalScale, normalScale, 1);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(!element.interactable) return;
        transform.localScale = new Vector3(clickScale*normalScale, clickScale*normalScale, 1);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localScale = new Vector3(normalScale,normalScale, 1);
    }
}
