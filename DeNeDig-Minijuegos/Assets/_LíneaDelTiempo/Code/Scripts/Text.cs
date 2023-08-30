using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Text : MonoBehaviour
{
    [SerializeField] int id;
    
    void Start()
    {
        transform.GetComponent<TextMeshProUGUI>().text = TextManager.Instance.setText(id);
       
    }

  
}
