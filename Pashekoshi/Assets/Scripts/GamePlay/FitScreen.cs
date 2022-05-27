using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var sr = GetComponent<SpriteRenderer>();
        if (sr == null) return;

        transform.localScale = new Vector3(1, 1, 1);

        var width = sr.sprite.bounds.size.x;
        var height = sr.sprite.bounds.size.y;

        var worldScreenHeight = Camera.main.orthographicSize * 2.0;
        var worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        var scale = new Vector3(0, 0, 0);
        scale.z = transform.localScale.z;
        scale.x = (float)(worldScreenWidth / width);
        scale.y = (float)(worldScreenHeight / height);

        transform.localScale = scale;
    }
}
