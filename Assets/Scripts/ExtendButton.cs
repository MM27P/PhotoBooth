using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ExtendButton : Button
{
    bool buttonDown;

    public void Update()
    {
        if(buttonDown)
        {
            GetComponent<Button>().onClick.Invoke();
        }
    }

    // Start is called before the first frame update
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        buttonDown = true;
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        buttonDown = false;
    }
}
