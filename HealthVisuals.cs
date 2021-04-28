using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthVisuals : MonoBehaviour
{
    [SerializeField] private Sprite heartSprite;
    private void Start()
    {
        CreateHeartImage();
    }
    private Image CreateHeartImage()
    {
        //Create game obiject
        GameObject heartgameObject = new GameObject("Heart", typeof(Image));
        //set child
        heartgameObject.transform.parent = transform;
        heartgameObject.transform.localPosition = Vector3.zero;
        // Set Heart Sprite
        Image heartImage = heartgameObject.GetComponent<Image>();
        heartImage.sprite = heartSprite;

        return heartImage;

    }
}
