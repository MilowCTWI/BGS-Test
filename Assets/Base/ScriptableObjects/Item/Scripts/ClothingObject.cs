using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Clothing", menuName = "ScriptableObjects/Clothing", order = 2)]
public class ClothingObject : ItemObject
{
    public ClothingType ClothingType;
    public bool Equipped;
}

public enum ClothingType
{
    Outfit,
    Hats
}
