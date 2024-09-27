using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScroll : MonoBehaviour
{
    public float scrollSpeed = 500f;
    const float backgroundPositionY = 320;
    const float backgroundOutPositionX = -1920;
    const float backgroundStartPositionX = 3840;

    public Image[] backgroundSprite;
    float[] backgroundOffset;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Time.deltaTime);
        InitBackgroundSpritePosition();
    }

    // Update is called once per frame
    void Update()
    {
        MoveBackgroundSpritePosition();
    }

    void InitBackgroundSpritePosition()
    {
        backgroundOffset = new float[backgroundSprite.Length];

        for (int i = 0; i < backgroundSprite.Length; ++i)
        {
            backgroundOffset[i] = backgroundSprite[i].transform.localPosition.x;

        }
    }

    void MoveBackgroundSpritePosition()
    {
        for (int i = 0; i < backgroundSprite.Length; ++i)
        {
            backgroundOffset[i] -= Time.deltaTime * scrollSpeed;
            backgroundSprite[i].transform.localPosition = new Vector3(backgroundOffset[i], backgroundPositionY);

            if (backgroundSprite[i].transform.localPosition.x <= backgroundOutPositionX)
            {
                backgroundSprite[i].transform.localPosition = new Vector3(backgroundStartPositionX, backgroundPositionY);
                backgroundOffset[i] = backgroundSprite[i].transform.localPosition.x;

            }
        }
    }

    public void SetBackgroundScrollSpeed(float setSpeed)
    {
        scrollSpeed = setSpeed;
    }
}
