using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : Singleton<CameraController>
{
    public Camera camera;
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        camera = this.gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(PrintXY());
    }
    IEnumerator PrintXY()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
        }
    }
}
