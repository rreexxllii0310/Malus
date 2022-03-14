using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MapRegion : MonoBehaviour
{
    [SerializeField]
    private MapRegionSO mapRegionSO;

    public Button button;
    //public TMP_Text buttonText;
    public Image buttonImage;
    public Image lockedImage;

    // Start is called before the first frame update
    void Start()
    {
        button.interactable = false;
        //buttonText.text = mapRegionSO.name;
        //buttonImage.sprite = mapRegionSO.regionSprite;
        lockedImage.sprite = mapRegionSO.lockedSprite;
    }

    // Update is called once per frame
    void Update()
    {
        bool isOpened = (!mapRegionSO.isLocked || mapRegionSO.isReachable);
        lockedImage.gameObject.SetActive(!isOpened);
        button.interactable = (isOpened && !mapRegionSO.isHere);
        
    }
}
