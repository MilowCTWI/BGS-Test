using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 0)]
public class ItemObject : ScriptableObject
{
    public string Name;
    public int Value;
    public Sprite Sprite;
    public GameObject Prefab;
    public ItemType Type;
}

public enum ItemType
{
    Clothing
}
