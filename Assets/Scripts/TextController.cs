using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public Transform playerTransform; 
    public float maxHeight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform){
            float meters = maxHeight - playerTransform.position.y + GameModeController.GetRound() * maxHeight;
            textMeshPro.text = "Fallen: " + meters.ToString("F2") + " m";
        }
    }
}
