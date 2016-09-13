using UnityEngine;
using System.Collections;

public class ClickTest : MonoBehaviour
{
    private Transform container;
    private SpaceHandler handler;

    public void OnMouseUpAsButton()
    {
        container = transform.parent;
        handler = container.GetComponent<SpaceHandler>();
        handler.pathHere();
    }
}
