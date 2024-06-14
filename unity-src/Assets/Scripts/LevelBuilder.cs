using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    public GameObject backgroundParent;
    public GameObject backgroundPrefab;
    public float backgroundOffset = 12.7f;
    public float start = -12.7f;
    public List<GameObject> levelPrefabs = new List<GameObject>();
    public float levelOffset = 2.0f;
    private float levelHeight;
    private Vector2 middleBot, middleTop;

    public List<float> SectionStartPositions = new();
    private List<bool> MirroredSections = new();
    public float mirrorChance = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        Get_Geometry();
        SetMirroredSections(mirrorChance);
        Create_Backgrounds();
        Build();
    }
    void SetMirroredSections(float mirrorChance)
    {
        for (int i = 0; i < levelPrefabs.Count; i++)
        {
            if (Random.value < mirrorChance)
            {
                MirroredSections.Add(true);
            }
            else
            {
                MirroredSections.Add(false);
            }
        }
    }

    public void Create_Backgrounds()
    {
        var backgroundAmount = 2 + 3 * levelPrefabs.Count;
        for (int i = 0; i < backgroundAmount; i++)
        {
            var background = Instantiate(backgroundPrefab, backgroundParent.transform);
            background.transform.position = new Vector2(0, start + i * backgroundOffset);
        }
    }

    public void Rebuild()
    {
        Destroy();
        Build();
    }

    public void Build()
    {
        // Create the level out of the list 0 is the first section etc.
        for (int i = 0; i < levelPrefabs.Count; i++)
        {
            // Instantiate the level prefab
            var levelPrefab = Instantiate(levelPrefabs[i], transform);
            if (MirroredSections[i])
                MirrorLevel(levelPrefab);
            if (i == 0)
            {
                SectionStartPositions.Add(middleBot.y);
                continue; // Skip the first level as we dont have to modify it
            }
            Vector2 position = levelPrefab.transform.position;
            position.y = middleBot.y + i * levelHeight + levelOffset;
            SectionStartPositions.Add(position.y - 2 * levelOffset - 1.0f);
            levelPrefab.transform.position = position;
        }
    }

    public void Destroy()
    {
        SectionStartPositions.Clear();
        // Delete all children
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    void Get_Geometry()
    {
        var topLeft = GameMaster.Instance.topLeft.transform.position;
        var bottomRight = GameMaster.Instance.bottomRight.transform.position;
        middleBot = new Vector2((topLeft.x + bottomRight.x) / 2, bottomRight.y);
        var screenHeight = topLeft.y - bottomRight.y;
        levelHeight = 3 * screenHeight;
        middleTop = new Vector2(middleBot.x, middleBot.y + screenHeight);
    }

    void MirrorLevel(GameObject levelPrefab)
    {
        // Get all children of the level prefab
        var children = new List<GameObject>();
        foreach (Transform child in levelPrefab.transform)
        {
            MirrorObject(child);
        }
    }

    void MirrorRandom(GameObject levelPrefab, float mirrorChance)
    {
        // Get all children of the level prefab
        var children = new List<GameObject>();
        foreach (Transform child in levelPrefab.transform)
        {
            if (Random.value < mirrorChance)
            {
                MirrorObject(child);
            }
        }
    }

    void MirrorObject(Transform objectTransform)
    {
        Vector2 objectPos = objectTransform.position;
        // Calculate the distance from the object to the line of reflection (middleBot.x)
        float distanceToMirrorLine = objectPos.x - middleBot.x;
        // Mirror the position by subtracting this distance from the line of reflection twice
        Vector2 newPosition = new Vector2(middleBot.x - distanceToMirrorLine, objectPos.y);
        objectTransform.position = newPosition;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(middleBot, 0.1f);
        Gizmos.DrawSphere(middleTop, 0.1f);
    }

    public void ResetToCheckpoint()
    {
        //player.transform.position = playerInitialPosition;
        //cam.transform.position = new Vector3(0, 0, -10);
        //background.GetComponent<Background>().Reset();
    }

}
