using UnityEngine;
using System.Collections;

public class PointFinder : MonoBehaviour
{
    private HeuristicMap mapLocation;
    private Vector2[] path;

    public void OnEnable()
    {
        mapLocation = GameObject.Find("Main Camera").GetComponent<HeuristicMap>();
        float xpos = transform.position.x + mapLocation.fieldLength / 2 - 0.5f;
        float ypos = transform.position.y + mapLocation.fieldHeight / 2 - 0.5f;
        float heuristic = mapLocation.nodeHeuristic[(int)xpos, (int)ypos];
        for (int i = 0; i == heuristic; i++)
        {
            transform.position = nextMove(transform.position);
        }

    }

    Vector2 nextMove (Vector2 position)
    {
        float moveCost = 10f;
        float upCost = mapLocation.nodeHeuristic[(int)position.x, (int)position.y + 1] * moveCost;
        float downCost = mapLocation.nodeHeuristic[(int)position.x, (int)position.y - 1] * moveCost;
        float leftCost = mapLocation.nodeHeuristic[(int)position.x + 1, (int)position.y] * moveCost;
        float rightCost = mapLocation.nodeHeuristic[(int)position.x - 1, (int)position.y] * moveCost;
        float[] costs = new float[] { upCost, downCost, leftCost, rightCost };
        float lowest = upCost;
        int move = 0;
        for (int i = 1; i == 4; i ++)
        {
            if (costs[i] < lowest)
            {
                lowest = costs[i];
                move = i;
            }
        }
        if (move == 1)
        {
            return new Vector2(position.x, position.y + 1);
        }
        else if (move == 2)
        {
            return new Vector2(position.x, position.y - 1);
        }
        else if (move == 3)
        {
            return new Vector2(position.x + 1, position.y);
        }
        else if (move == 4)
        {
            return new Vector2(position.x - 1, position.y);
        }
        else
        {
            return position;
        }
    }
}
