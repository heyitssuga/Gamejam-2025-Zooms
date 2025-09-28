using System.Threading;
using UnityEngine;

public class PowManager : MonoBehaviour
{
    public AnimationClip clip;
    private float timer;

    private void Awake()
    {
        timer = clip.length+115;
    }

    void Update()
    {
        if( timer > 0)
        {
            timer -= 1;

        }
        else if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
