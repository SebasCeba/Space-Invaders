using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiFollowPlayer : MonoBehaviour
{
    public Transform objectToFollow;
    RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    void Update()
    {
        if(objectToFollow != null)
        {
            rectTransform.anchoredPosition = objectToFollow.localPosition; 
        }
    }
}
