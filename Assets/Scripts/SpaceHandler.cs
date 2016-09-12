using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpaceHandler : MonoBehaviour
{
    private HeuristicMap mapLocation;
    private Text label;

    public void OnEnable()
    {
        mapLocation = GameObject.Find("Main Camera").GetComponent<HeuristicMap>();
        label = GetComponentInChildren<Text>();
        float xpos = transform.position.x + mapLocation.fieldLength / 2 - 0.5f;
        float ypos = transform.position.y + mapLocation.fieldHeight / 2 - 0.5f;
        float heuristic = mapLocation.nodeHeuristic[(int)xpos, (int)ypos];
        label.text = heuristic.ToString();
        label.color = new Color(heuristic / 10, 0, 0);
    }

    public void pathFind()
    {
        mapLocation.pathFind(transform.localPosition + new Vector3(0, 0, -4), transform.parent);
    }
}
