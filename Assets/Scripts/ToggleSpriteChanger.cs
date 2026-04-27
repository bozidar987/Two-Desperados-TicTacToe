using UnityEngine;
using UnityEngine.UI;

public class ToggleSpriteChanger : MonoBehaviour
{
    Toggle toggle;
    [SerializeField] Sprite toggleOnSprite;
    [SerializeField] Sprite toggleOffSprite;
    void Start()
    {
        toggle = GetComponent<Toggle>();
    }

    public void changeSprite() 
    {        
        if (toggle.isOn)
        {
            toggle.image.sprite = toggleOnSprite;
            toggle.interactable = false;
        }
        else
        {
            toggle.image.sprite = toggleOffSprite;
            toggle.interactable = true;
        }
        
    }
}
