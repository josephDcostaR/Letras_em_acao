using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChanges : MonoBehaviour
{
    public Button button;
    private bool isButtonClicked = false;
    private Color originalColor;
    public Color clickedColor = Color.red;

    private void Start()
    {  
        originalColor = button.image.color; 
        button.onClick.AddListener(ChangeButtonColor);
    }

    public void ChangeButtonColor()
    {
        isButtonClicked = !isButtonClicked;
       
        if (isButtonClicked)
        {
            button.image.color = clickedColor;
            Debug.Log("Botão clicado");
        }
        else
        {
            button.image.color = originalColor; 
        }
    }
}
