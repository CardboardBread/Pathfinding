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
    public GameObject pathfinder;
    public string containerTag;
    private int iteration;
    private Vector2 pathStart;
    private float containerLayer;
    private float spaceLayer;

    void Start()
    {
        fieldLength = field.transform.localScale.x + field.transform.position.x;
        fieldHeight = field.transform.localScale.y + field.transform.position.y;
        destination = new Vector2(((int)(Random.Range(0, fieldLength / 2) - fieldLength / 2)), (int)(Random.Range(0, fieldHeight) - fieldHeight / 2));
        nodeHeuristic = new float[(int)field.transform.localScale.x, (int)field.transform.localScale.y];
        containerLayer = 0;
        spaceLayer = -1;
    }

    public void Update()
    {
        if (Input.GetButtonDown(actionbutton))
        {
            clearBoard();
            destination = new Vector2(((int)(Random.Range(0, fieldLength / 2) - fieldLength / 2)), (int)(Random.Range(0, fieldHeight) - fieldHeight / 2));
        }
        if (Input.GetButtonUp(actionbutton))
        {
            Debug.Log("Pathfinding to " + destination);
            Instantiate(nodeContainer, new Vector3(0, 0, containerLayer), Quaternion.identity);
            generateHeuristic();
        }
    }

    void clearBoard ()
    {
        if (GameObject.FindWithTag(containerTag) != null)
        {
            Transform parent = GameObject.FindWithTag(containerTag).transform;
            foreach (Transform child in parent)
            {
                foreach (Transform secChild in child)
                {
                    Destroy(secChild.gameObject);
                }
                Destroy(child.gameObject);
            }
            Destroy(parent.gameObject);
        }
    }

    void generateHeuristic()
    {
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
        Transform parent = GameObject.FindWithTag(containerTag).transform;
        gridLocation = new Vector2(x - fieldLength / 2, y - fieldHeight / 2);
        nodeHeuristic[(int)x, (int)y] = getHeuristic(gridLocation, destination);
        position = new Vector3(x - fieldLength / 2 + 0.5f, y - fieldHeight / 2 + 0.5f, spaceLayer);
        Instantiate(space, position, Quaternion.identity, parent);
    }

    public void pathFind (Vector3 position, Transform parent)
    {
        Instantiate(pathfinder, position, Quaternion.identity, parent);
    }
}
