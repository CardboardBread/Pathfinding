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
        float xpos = transform.position.x + mapLocation.fieldLength / 2;
        float ypos = transform.position.y + mapLocation.fieldHeight / 2;
        float heuristic = mapLocation.nodeHeuristic[(int)xpos, (int)ypos];
        label.text = heuristic.ToString();
        label.color = new Color(heuristic / 10, 0, 0);
    }

    public void pathHere()
    {
        mapLocation.pathFind(transform.localPosition, transform.parent);
    }
}
