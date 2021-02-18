using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class DropPlace : MonoBehaviour,IDropHandler,IPointerEnterHandler,IPointerExitHandler
{
    private FieldInfo _fieldInfo;
    private void Start()
    {
        if (gameObject.GetComponent<FieldInfo>())
        {
            _fieldInfo = GetComponent<FieldInfo>();
        }
    }


    public void OnDrop(PointerEventData eventData)
    {
        CardMovement card = eventData.pointerDrag.GetComponent<CardMovement>();
        if (card)
        {
            card.defaultParent = transform;

            if (_fieldInfo)
                _fieldInfo.AddCardField(card.GetComponent<CardInfo>());
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
        {
            return;
        }
        CardMovement card = eventData.pointerDrag.GetComponent<CardMovement>();
        if (card)
        {
            card.defaultTempCardParent = transform; 
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
        {
            return;
        }
        CardMovement card = eventData.pointerDrag.GetComponent<CardMovement>();
        if (card&&card.defaultTempCardParent == transform)
        {
            card.defaultTempCardParent = card.defaultParent;
        }

    }
}
