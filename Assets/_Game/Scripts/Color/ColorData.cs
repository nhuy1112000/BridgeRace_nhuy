using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ColorType { Default, Red, Green, Blue, Yellow, Pink, Orange }
[CreateAssetMenu(fileName = "DataColor", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class ColorData : ScriptableObject 
{
    [SerializeField] private Material[] material;
    

    public Material GetMat(ColorType colorType)
    {
        return material[(int)colorType];

    }
}
