using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIOrientationHandler : MonoBehaviour
{
    [System.Serializable]
    class UIElement
    {
        public RectTransform rectTransform;
        public Vector2 landscapeScale;
        public Vector2 portraitScale;
    }

    CanvasScaler canvasScaler;
    bool isLandscape;

    [SerializeField] List<UIElement> UIElements = new List<UIElement>();
    void Start()
    {
        canvasScaler = GetComponent<CanvasScaler>();

        if (Screen.width > Screen.height)
        {
            setCanvasToLandscape();
        }
        else
        {
            setCanvasToPortrait();
        }
    }
    void Update()
    {
        if(Screen.width > Screen.height)
        {
            if(!isLandscape)
            {
                setCanvasToLandscape();
            }
        }
        else
        {
            if (isLandscape)
            {
                setCanvasToPortrait();
            }
        }
    }

    void setCanvasToLandscape() 
    { 
        isLandscape = true;
        canvasScaler.matchWidthOrHeight = 1;
        for (int i = 0; i < UIElements.Count; i++)
        {
            UIElements[i].rectTransform.localScale = new Vector3(UIElements[i].landscapeScale.x, UIElements[i].landscapeScale.y, 1);
        }
        Canvas.ForceUpdateCanvases();
    }

    void setCanvasToPortrait()
    {
        isLandscape = false;
        canvasScaler.matchWidthOrHeight = 0;
        for (int i = 0; i < UIElements.Count; i++)
        {
            UIElements[i].rectTransform.localScale = new Vector3(UIElements[i].portraitScale.x, UIElements[i].portraitScale.y, 1);
        }
        Canvas.ForceUpdateCanvases();
    }
}
