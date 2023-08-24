using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{
    public GameObject item;
    public Transform origin;

    private void Start()
    {
        origin = GameObject.Find("ItemDraggerParent").GetComponent<Transform>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Entro");

        if (!item)
        {
            item = DragHandler.objBeingDraged;
            item.transform.SetParent(transform);
            item.transform.position = transform.position;
        }
        
    }

  

    private void Update()
    {
        if (item != null && item.transform.parent != transform)
        {
            Debug.Log("Remover");
            item = null;
            
        }
    }
}
