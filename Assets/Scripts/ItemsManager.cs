using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ItemsManager : MonoBehaviour
{
    [SerializeField] private List<Image> itemsIconBlack;
    [SerializeField] private List<Sprite> itemsIconSprite;
    [SerializeField] private List<GameObject> itemsSlot;
    [SerializeField] private Animator inventoryAnimator;
    private bool isOpen = false;
    

    private PlayerInputSystem mInputSystem;
    private InputAction interaction;

    private void Awake()
    {
        mInputSystem = new PlayerInputSystem();
    }

    void OnEnable()
    {
        interaction = mInputSystem.Interact.Use1;
        interaction.Enable();
        interaction.performed += OpenItem;
    }

    void OnDisable()
    {
        interaction.Disable();

    }

    void Update()
    {
        ChangeIconSprite();
        DeactivateItem();
    }

    private void ChangeIconSprite()
    {
        if (VariableHolder.greenItem)
        {
            itemsIconBlack[0].sprite = itemsIconSprite[0];
        }

        if (VariableHolder.testItem)
        {
            itemsIconBlack[6].sprite = itemsIconSprite[6];
        }

        if (VariableHolder.redItem)
        {
            itemsIconBlack[3].sprite = itemsIconSprite[3];
        }

        if (VariableHolder.blueItem)
        {
            itemsIconBlack[1].sprite = itemsIconSprite[1];
        }

        if (VariableHolder.purpleItem)
        {
            itemsIconBlack[2].sprite = itemsIconSprite[2];
        }

        if (VariableHolder.orangeItem)
        {
            itemsIconBlack[5].sprite = itemsIconSprite[5];
        }

        if (VariableHolder.greenItem2)
        {
            itemsIconBlack[4].sprite = itemsIconSprite[4];
        }
    }

    private void DeactivateItem()
    {
        if(VariableHolder.blueQuest)
        {
            itemsSlot[1].SetActive(false);
        }
        if (VariableHolder.greenQuest)
        {
            itemsSlot[0].SetActive(false);
            itemsSlot[6].SetActive(false);
        }

        if (VariableHolder.purpleQuest)
        {
            itemsSlot[2].SetActive(false);
        }

        if (VariableHolder.orangeQuest)
        {
            itemsSlot[5].SetActive(false);
        }

        if (VariableHolder.greenQuest2)
        {
            itemsSlot[4].SetActive(false);
        }

        if (VariableHolder.redQuest)
        {
            itemsSlot[3].SetActive(false);
        }
    }

    private void OpenItem(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (!isOpen)
            {
                inventoryAnimator.SetTrigger("Open");
                isOpen = true;
                VariableHolder.Instance.InventorySound();
            }
            else
            {
                inventoryAnimator.SetTrigger("Close");
                isOpen = false;
                VariableHolder.Instance.InventorySound();
            }
        }
    }
}
