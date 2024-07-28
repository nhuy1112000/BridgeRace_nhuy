using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorObject : MonoBehaviour
{
    [SerializeField] private ColorData colorData;
    public ColorType colorType;
    [SerializeField] private Renderer renderer;
    public void ChangeColor(ColorType colorType)
    {
        this.colorType = colorType;
        renderer.material = colorData.GetMat(colorType);

    }
}
