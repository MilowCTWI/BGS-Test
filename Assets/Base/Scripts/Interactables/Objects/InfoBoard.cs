using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoBoard : Interactable
{
    public override void OnInteract()
    {
        base.OnInteract();

        UIManager.Instance.ShowTutorial();
    }
}
