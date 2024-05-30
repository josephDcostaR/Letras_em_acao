using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCard : MonoBehaviour
{
    [SerializeField] private sceneController controller;
    [SerializeField] private GameObject CardBack;

      public void OnMouseDown()
    {
     
        if(CardBack.activeSelf && controller.canReveal)
        {
            CardBack.SetActive(false);
            controller.cardRevealed(this);
          
        }
    }

    private int _id;
    public int id
    {
        get {return _id; }
    }

    public void ChangeSprite(int id, Sprite image)
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image;

    }

    public void Unreveal()
    {
        CardBack.SetActive(true);
    }

}
