using UnityEngine;
using System.Collections;

public class PointFinder : MonoBehaviour
{
    private HeuristicMap mapLocation;
    private Vector2[] path;
    private Vector2 heuristicPos;

    public void OnEnable()
    {
        mapLocation = GameObject.Find("Main Camera").GetComponent<HeuristicMap>();
        float xpos = transform.localPosition.x + mapLocation.fieldLength / 2;
        float ypos = transform.localPosition.y + mapLocation.fieldHeight / 2;
        float heuristic = mapLocation.nodeHeuristic[(int)xpos, (int)ypos];
        if (heuristic != 0f)
        {
            Vector2 destination = nextMove((int)xpos, (int)ypos);
            mapLocation.pathFind(destination, transform.parent.transform);
        }
    }

    Vector2 nextMove (int x, int y)
    {
        float index = Mathf.Infinity;
        Vector2 pos = Vector2.zero;
        if (x > 0)
        {
            if (mapLocation.nodeHeuristic[x - 1, y] < index) { index = mapLocation.nodeHeuristic[x - 1, y]; pos = new Vector2(x - 1, y); }
        }
        if (x < mapLocation.fieldLength / 2)
        {
            if (mapLocation.nodeHeuristic[x + 1, y] < index) { index = mapLocation.nodeHeuristic[x + 1, y]; pos = new Vector2(x + 1, y); }
        }
        if (y > 0)
        {
            if (mapLocation.nodeHeuristic[x, y - 1] < index) { index = mapLocation.nodeHeuristic[x, y - 1]; pos = new Vector2(x, y - 1); }
        }
        if (y < mapLocation.fieldHeight / 2)
        {
            if (mapLocation.nodeHeuristic[x, y + 1] < index) { index = mapLocation.nodeHeuristic[x, y + 1]; pos = new Vector2(x, y + 1); }
        }
        return pos - new Vector2(mapLocation.fieldLength / 2, mapLocation.fieldHeight / 2);
    }
}
