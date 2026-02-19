using UnityEngine;

public class QuestionTileOffset : MonoBehaviour
{
    public int tilesX = 4;
    public int tilesY = 4;

    public int tileColumn = 0;
    public int tileRow = 0;

    void Start()
    {
        Renderer r = GetComponent<Renderer>();
        Material mat = r.material;

        Vector2 scale = new Vector2(1f / tilesX, 1f / tilesY);
        mat.mainTextureScale = scale;
        
        float flippedRow = (tilesY - 1 - tileRow);

        Vector2 offset = new Vector2(tileColumn * scale.x,
            flippedRow * scale.y);

        mat.mainTextureOffset = offset;
    }
}