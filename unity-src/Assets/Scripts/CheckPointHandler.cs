using System.Collections;
using UnityEngine;

public class CheckPointHandler : MonoBehaviour
{
    public GameObject checkPointPrefab;
    private LevelBuilder levelBuilder;
    private GameObject player;
    private GameObject cam;
    private float topYpos = float.MinValue;
    private GameObject spawnedCheckpoint;
    // Start is called before the first frame update
    void Start()
    {
        levelBuilder = GetComponent<LevelBuilder>();
        player = GameMaster.Instance.player;
        cam = GameMaster.Instance.cam;
    }

    private void Update()
    {
        topYpos = Mathf.Max(player.transform.position.y, topYpos);
    }

    public void GoToCheckpoint()
    {
        player.GetComponent<PlayerController>().SetInput(false);
        GameMaster.Instance.Deaths += 1;
        // Find the closest checkpoint, the list is sorted.
        var checkpoints = levelBuilder.SectionStartPositions;
        for (int i = 0; i < checkpoints.Count; i++)
        {
            if (topYpos < checkpoints[i])
            {
                var checkpoint = i == 0 ? checkpoints[0] : checkpoints[i - 1];
                // We found the closest checkpoint
                StartCoroutine(Checkpoint(checkpoint));
                break;
            }
        }

    }

    IEnumerator Checkpoint(float position)
    {
        if (spawnedCheckpoint != null)
        {
            Destroy(spawnedCheckpoint);
        }
        yield return new WaitForSeconds(0.2f);
        GameMaster.Instance.PlaySFX("die");

        levelBuilder.Rebuild();
        spawnedCheckpoint = Instantiate(checkPointPrefab, new Vector3(0.0f, position, 0.0f), Quaternion.identity);
        spawnedCheckpoint.transform.parent = transform;
        // spawn the player above the checkpoint
        player.transform.position = new Vector3(0.0f, position + 2.0f, 0.0f);
        cam.transform.position = new Vector3(0.0f, position + 2.0f, -10.0f);
        yield return new WaitForSeconds(1.0f);
        // Spawn the checkpoint
        player.GetComponent<PlayerController>().SetInput(true);
    }
}
