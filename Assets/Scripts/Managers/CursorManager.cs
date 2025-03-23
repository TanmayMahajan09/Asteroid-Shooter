using UnityEngine;

public class CursorManager : MonoBehaviour {
    public Texture2D crosshairTexture;
    public Vector2 hotspot;
    public CursorMode cursorMode = CursorMode.Auto;

    void Start() {
        hotspot = new Vector2(crosshairTexture.width / 2, crosshairTexture.height / 2);
        Cursor.SetCursor(crosshairTexture, hotspot, cursorMode);
    }
}
