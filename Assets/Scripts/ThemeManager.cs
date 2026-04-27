using UnityEngine;

[CreateAssetMenu(fileName = "ThemeManager", menuName = "Scriptable Objects/ThemeManager")]
public class ThemeManager : ScriptableObject
{
    [System.Serializable]
    public struct Theme
    {
        public Sprite xSprite;
        public Sprite oSprite;
    }

    public Theme theme1;
    public Theme theme2;
    public Theme theme3;

    Theme selectedTheme;

    public void SetTheme(int gameTheme)
    {
        switch (gameTheme)
        {
            case 1:
                selectedTheme = theme1;
                break;
            case 2:
                selectedTheme = theme2;
                break;
            case 3:
                selectedTheme = theme3;
                break;
            default:
                selectedTheme = theme1;
                break;
        }
    }

    public Sprite setMark(int player)
    {
    
        if (player == 1)
        {
            return selectedTheme.xSprite;
        }
        else if (player == 2)
        {
            return selectedTheme.oSprite;
        }
        return null;
    }
}
