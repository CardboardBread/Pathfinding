using UnityEngine;
using System.Collections;

public class HeuristicMap : MonoBehaviour
{
    public string actionbutton;
    public GameObject field;
    public float fieldLength;
    public float fieldHeight;
    public float[,] nodeHeuristic;
    private Vector2 destination;
    public GameObject space;
    private float lengthIncrement;
    private float heightIncrement;
    private bool incrementSwap;
    public GameObject nodeContainer;

    void Start()
    {
        fieldLength = field.transform.localScale.x + field.transform.position.x;
        fieldHeight = field.transform.localScale.y + field.transform.position.y;
        destination = new Vector2(((int)(Random.Range(0, fieldLength / 2) - fieldLength / 2)), (int)(Random.Range(0, fieldHeight) - fieldHeight / 2));
        nodeHeuristic = new float[(int)field.transform.localScale.x, (int)field.transform.localScale.y];
        generateHeuristic();
    }

    public void Update()
    {
        if (Input.GetButtonDown(actionbutton))
        {
            destination = new Vector2(((int)(Random.Range(0, fieldLength / 2) - fieldLength / 2)), (int)(Random.Range(0, fieldHeight) - fieldHeight / 2));
            Debug.Log("Pathfinding to " + destination);
            generateHeuristic();
        }
    }

    void clearBoard ()
    {
        Destroy(GameObject.Find("Node Container(Clone)"));
    }

    void generateHeuristic()
    {
        clearBoard();
        Instantiate(nodeContainer, new Vector3(0, 0, -10), Quaternion.identity);
        for (int x = 0; x < fieldLength; x++)
        {
            for (int y = 0; y < fieldHeight; y++)
            {
                mapPoint(x, y);
            }
        }
    }

    float getHeuristic(Vector2 origin, Vector2 destination)
    {
        float xdistance = Mathf.Abs(destination.x - origin.x);
        float ydistance = Mathf.Abs(destination.y - origin.y);
        return (xdistance + ydistance);
    }

    void mapPoint(float x, float y)
    {
        Vector2 gridLocation;
        Vector3 position;
        gridLocation = new Vector2(x - fieldLength / 2, y - fieldHeight / 2);
        nodeHeuristic[(int)x, (int)y] = getHeuristic(gridLocation, destination);
        position = new Vector3(x - fieldLength / 2 + 0.5f, y - fieldHeight / 2 + 0.5f, -1);
        Instantiate(space, position, Quaternion.identity, nodeContainer.transform);
    }
}
