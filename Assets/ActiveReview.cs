using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveReview : MonoBehaviour
{
    public GameObject Review;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChangeObjectActive()
    {
        bool b = Review.activeSelf ? false : true;
        Review.SetActive(b);
    }
}
