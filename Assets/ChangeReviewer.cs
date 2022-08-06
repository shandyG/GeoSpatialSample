using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ChangeReviewInfo : MonoBehaviour
{
    private string url = "https://lh3.googleusercontent.com/a-/AFdZucqAha4OmP5VT61icKDAqBvle1ZTO7-b9D3AZ1nn1A=s128-c0x00000000-cc-rp-mo-ba6";
    public GameObject ReviewerPic;

    IEnumerator Start()
    {

        WWW www = new WWW(url);
        yield return www;
        RawImage m_RawImage = ReviewerPic.GetComponent<RawImage>();
        m_RawImage.texture = www.texture;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
