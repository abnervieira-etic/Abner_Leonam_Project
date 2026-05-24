using UnityEngine;
using UnityEngine.UI;

public class CharacterSelected : MonoBehaviour
{
    public Color p1Color = Color.blue;
    public Color p2Color = Color.red;

    private Image p1Last;
    private Image p2Last;

    public void P1Select(Image btn)
    {
        if (p1Last) p1Last.color = Color.white;
        p1Last = btn;
        btn.color = p1Color;
    }

    public void P2Select(Image btn)
    {
        if (p2Last) p2Last.color = Color.white;
        p2Last = btn;
        btn.color = p2Color;
    }
}