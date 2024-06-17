using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class TowerSpawnButton : MonoBehaviour//, IDragHandler
{

    public Text buttonText;

    public Image towerIcon;

    public Button buyButton;


    public Image energyIcon;

    public Color energyDefaultColor;

    public Color energyInvalidColor;


    //public event Action<Tower> buttonTapped;

    //public event Action<Tower> draggedOff;

    //Tower m_Tower;

    //Currency m_Currency;


    RectTransform m_RectTransform;

    //public virtual void OnDrag(PointerEventData eventData)
    //{
    //    if (!RectTransformUtility.RectangleContainsScreenPoint(m_RectTransform, eventData.position))
    //    {
    //        if (draggedOff != null)
    //        {
    //            draggedOff(m_Tower);
    //        }
    //    }
    //}
   
 
    //public void InitializeButton(Tower towerData)
    //{
    //    m_Tower = towerData;

    //    if (towerData.levels.Length > 0)
    //    {
    //        TowerLevel firstTower = towerData.levels[0];
    //        buttonText.text = firstTower.cost.ToString();
    //        towerIcon.sprite = firstTower.levelData.icon;
    //    }
    //    else
    //    {
    //        Debug.LogWarning("[Tower Spawn Button] No level data for tower");
    //    }

    //    if (LevelManager.instanceExists)
    //    {
    //        m_Currency = LevelManager.instance.currency;
    //        m_Currency.currencyChanged += UpdateButton;
    //    }
    //    else
    //    {
    //        Debug.LogWarning("[Tower Spawn Button] No level manager to get currency object");
    //    }
    //    UpdateButton();
    //}


    protected virtual void Awake()
    {
        m_RectTransform = (RectTransform)transform;
    }


    //protected virtual void OnDestroy()
    //{
    //    if (m_Currency != null)
    //    {
    //        m_Currency.currencyChanged -= UpdateButton;
    //    }
    //}


    //public void OnClick()
    //{
    //    if (buttonTapped != null)
    //    {
    //        buttonTapped(m_Tower);
    //    }
    //}

    //void UpdateButton()
    //{
    //    if (m_Currency == null)
    //    {
    //        return;
    //    }

    //    // Enable button
    //    if (m_Currency.CanAfford(m_Tower.purchaseCost) && !buyButton.interactable)
    //    {
    //        buyButton.interactable = true;
    //        energyIcon.color = energyDefaultColor;
    //    }
    //    else if (!m_Currency.CanAfford(m_Tower.purchaseCost) && buyButton.interactable)
    //    {
    //        buyButton.interactable = false;
    //        energyIcon.color = energyInvalidColor;
    //    }
    //}
    //public void OnDrag(PointerEventData eventData)
    //{
    //    throw new NotImplementedException();
    //}
}
