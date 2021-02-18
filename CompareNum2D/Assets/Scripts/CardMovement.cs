using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardMovement : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    private Camera _mainCamera;
    private Vector3 _offset;
    public Transform defaultParent , defaultTempCardParent;
    GameObject tempCardGO;

    private void Awake()
    {
        _mainCamera = Camera.main;
        tempCardGO = GameObject.Find("TempCardGO");
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        _offset = transform.position - _mainCamera.ScreenToWorldPoint(eventData.position);
        defaultParent = defaultTempCardParent = transform.parent;

        tempCardGO.transform.SetParent(defaultParent);
        tempCardGO.transform.SetSiblingIndex(transform.GetSiblingIndex());

        transform.SetParent(defaultParent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 newPos = _mainCamera.ScreenToWorldPoint(eventData.position);
        
        transform.position = newPos +_offset;


        if (tempCardGO.transform.parent != defaultTempCardParent)
        {
            tempCardGO.transform.SetParent(defaultTempCardParent); 
        }
        CheckPosition();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(defaultParent);
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        transform.SetSiblingIndex(tempCardGO.transform.GetSiblingIndex());
        tempCardGO.transform.SetParent(GameObject.Find("Canvas").transform);
        tempCardGO.transform.localPosition = new Vector3(2150, 0);
    }

    private void CheckPosition()
    {
        int newIndex = defaultTempCardParent.childCount;
        for (int i = 0; i < defaultTempCardParent.childCount; i++)
        {
            if(transform.position.x< defaultTempCardParent.GetChild(i).position.x)
            {
                newIndex = i;
                if (tempCardGO.transform.GetSiblingIndex() < newIndex)
                {
                    newIndex--;
                }
                break;
            }
        }

        tempCardGO.transform.SetSiblingIndex(newIndex);
    }
}
