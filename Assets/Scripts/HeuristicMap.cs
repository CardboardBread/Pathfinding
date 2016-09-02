using UnityEngine;
using System.Collections;

public class HeuristicMap : MonoBehaviour
{

    public GameObject field;
    private float fieldLength;
    private float fieldHeight;
    private float[,] nodeHeuristic;
    private Vector2 destination;
    public GameObject space;

    void Start()
    {
        fieldLength = field.transform.localScale.x / 2 + field.transform.position.x;
        fieldHeight = field.transform.localScale.y / 2 + field.transform.position.y;
        destination = field.transform.position;
        nodeHeuristic = new float[(int)field.transform.localScale.x, (int)field.transform.localScale.y];
        mapHeuristic();
    }

    float getHeuristic(Vector2 origin, Vector2 destination)
    {
        float xdistance = Mathf.Abs(destination.x - origin.x);
        float ydistance = Mathf.Abs(destination.y - origin.y);
        return (xdistance + ydistance);
    }

    void mapHeuristic()
    {
        Vector2 gridLocation;
        Vector3 position;
        for (float x  = -fieldLength; x == fieldLength; x++)
        {
            for (float y = -fieldHeight; x == fieldHeight; x++)
            {
                gridLocation = new Vector2(x, y);
                nodeHeuristic[(int)x, (int)y] = getHeuristic(gridLocation, destination);
                position = new Vector3(x, y, 1);
                Instantiate(space, position, Quaternion.identity);
            }
        }
    }
}
