using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelParser : MonoBehaviour
{
    [Header("Level")]
    public TextAsset levelFile;
    public Transform levelRoot;

    [Header("Prefabs")]
    public GameObject rockPrefab;
    public GameObject brickPrefab;
    public GameObject goldPrefab;
    public GameObject stonePrefab;

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
        // Push lines onto a stack so we can pop bottom-up rows. This is easy to reason
        //  about, but an index-based loop over the string array is faster.
        Stack<string> levelRows = new Stack<string>();

        foreach (string line in levelFile.text.Split('\n'))
            levelRows.Push(line);

        int row = 0;
        while (levelRows.Count > 0)
        {
            string rowString = levelRows.Pop();
            char[] rowChars = rowString.ToCharArray();
            
            for (var columnIndex = 0; columnIndex < rowChars.Length; columnIndex++)
            {
                var currentChar = rowChars[columnIndex];

                // Todo - Instantiate a new GameObject that matches the type specified by the character
                // Todo - Position the new GameObject at the appropriate location by using row and column
                // Todo - Parent the new GameObject under levelRoot
                if(currentChar == 'x')
                {
                    Vector3 position = new Vector3(columnIndex + 0.5f, row + 0.5f, 0);
                    Transform rockInstance = Instantiate(rockPrefab,levelRoot).transform;
                    rockInstance.position = position;
                   
                }
                else if(currentChar == 'b')
                {
                    Vector3 position = new Vector3(columnIndex + 0.5f, row + 0.5f, 0);
                    Transform brickInstance = Instantiate(brickPrefab,levelRoot).transform;
                    brickInstance.position = position;
                }
                else if(currentChar == '?')
                {
                    Vector3 position = new Vector3(columnIndex + 0.5f, row + 0.5f, 0);
                    Transform goldInstance = Instantiate(goldPrefab,levelRoot).transform;
                    goldInstance.position = position;
                }
                else if(currentChar == 's')
                {
                    Vector3 position = new Vector3(columnIndex + 0.5f, row + 0.5f, 0);
                    Transform stoneInstance = Instantiate(stonePrefab,levelRoot).transform;
                    stoneInstance.position = position;
                }

               

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
