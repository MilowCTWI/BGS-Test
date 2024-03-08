using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    private InteractableType _interactableType;

    public virtual void OnInteract(){}

    public InteractableType GetInteractableType()
    {
        return _interactableType;
    }
}

public enum InteractableType
{
    Instantenous,
    Shop
}