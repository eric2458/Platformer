using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelParser : MonoBehaviour
{
    [Header("Level")]
    public TextAsset levelFile;
    public Transform levelRoot;

    [Header("Prefabs")]
    public GameObject rockPrefab;   // 'x'
    public GameObject brickPrefab;  // 'b'
    public GameObject goldPrefab;   // '?'
    public GameObject stonePrefab;  // 's'

    void Start()
    {
        LoadLevel();
    }

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.rKey.wasPressedThisFrame)
            ReloadLevel();
    }

    void LoadLevel()
    {
        if (levelFile == null)
        {
            Debug.LogError("LevelParser: levelFile is not assigned.");
            return;
        }

        if (levelRoot == null)
        {
            Debug.LogError("LevelParser: levelRoot is not assigned.");
            return;
        }

        // Push lines onto a stack so we can pop bottom-up rows
        Stack<string> levelRows = new Stack<string>();

        foreach (string line in levelFile.text.Split('\n'))
            levelRows.Push(line);

        int row = 0;

        while (levelRows.Count > 0)
        {
            string rowString = levelRows.Pop();

            // If the row is empty, just move to the next row
            if (string.IsNullOrWhiteSpace(rowString))
            {
                row++;
                continue;
            }

            char[] rowChars = rowString.ToCharArray();

            for (int columnIndex = 0; columnIndex < rowChars.Length; columnIndex++)
            {
                char currentChar = rowChars[columnIndex];

                // Ignore Windows carriage returns
                if (currentChar == '\r') continue;

                // Ignore spaces (your level file uses lots of spacing)
                if (currentChar == ' ') continue;

                GameObject prefabToSpawn = null;

                switch (currentChar)
                {
                    case 'x':
                        prefabToSpawn = rockPrefab;
                        break;

                    case 'b':
                        prefabToSpawn = brickPrefab;
                        break;

                    case '?':
                        prefabToSpawn = goldPrefab;   // your ? block prefab
                        break;

                    case 's':
                        prefabToSpawn = stonePrefab;
                        break;

                    // If you use '.' or something for empty, add it here:
                    // case '.':
                    default:
                        prefabToSpawn = null;
                        break;
                }

                if (prefabToSpawn == null) continue;

                // Same positioning you already used (centered in a 1x1 grid cell)
                Vector3 newPosition = new Vector3(columnIndex + 0.5f, row + 0.5f, 0f);

                Transform instance = Instantiate(prefabToSpawn, levelRoot).transform;
                instance.position = newPosition;
            }

            row++;
        }
    }

    void ReloadLevel()
    {
        if (levelRoot == null) return;

        foreach (Transform child in levelRoot)
            Destroy(child.gameObject);

        LoadLevel();
    }
}
