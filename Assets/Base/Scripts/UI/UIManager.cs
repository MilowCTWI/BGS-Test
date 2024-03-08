using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public InventoryController InventoryController;
    public ShopController ShopController;
   
    [SerializeField]
    private GameObject _tutorialScreen;

    public void Awake()
    {
        Instance = this;

        if (PlayerPrefs.GetInt("ShowTutorial", 0) == 0)
        {
            _tutorialScreen.SetActive(true);
            PlayerPrefs.SetInt("ShowTutorial", 1);
        }
    }

    public void ShowShopScreen(InventoryObject inventory)
    {
        ShopController.OpenShop(inventory);
        InventoryController.OpenInventory();
    }

    public void CloseShopScreen()
    {
        ShopController.CloseShop();
        InventoryController.CloseInventory();
    }

    public void ShowTutorial()
    {
        if (!_tutorialScreen.activeInHierarchy)
            _tutorialScreen.SetActive(true);
    }

    public void HideTutorial()
    {
        if(_tutorialScreen.activeInHierarchy)
            _tutorialScreen.SetActive(false);
    }
}
