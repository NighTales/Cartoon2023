using UnityEngine;
using UnityEngine.VFX;

public class Soul : MonoBehaviour
{
    [SerializeField]
    private VisualEffect soulEffect;
    [SerializeField]
    private string propertyName = "ColorOverLifeTime";

    [HideInInspector]
    public Gradient color;

    public void SetSoulColor(Gradient soulColor)
    {
        color = soulColor;
        soulEffect.SetGradient(propertyName, color);
    }
}
