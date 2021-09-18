using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ClickChara : MonoBehaviour,IPointerClickHandler
{

    void Start()
    {
        Debug.Log("started");
    }
   void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("click");
        SceneManager.LoadScene("Main");
    }
}
