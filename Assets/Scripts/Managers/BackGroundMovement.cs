using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundMovement : MonoBehaviour
{
    public float speed;
    public new RawImage renderer;

    public void Update()
    {
        renderer.material.mainTextureOffset = new Vector2(Time.time * speed, 0f); 
    }
}
