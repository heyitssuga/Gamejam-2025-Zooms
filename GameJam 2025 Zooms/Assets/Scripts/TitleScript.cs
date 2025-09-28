using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    public Sprite image1; 
    public Sprite image2;

    private Image img;
    private float timer;

    public float switchInterval = 1f;

    void Start()
    {
        img = GetComponent<Image>();
        timer = 0f;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= switchInterval)
        {

            img.sprite = (img.sprite == image1) ? image2 : image1;

            timer = 0f;
        }
    }
}
