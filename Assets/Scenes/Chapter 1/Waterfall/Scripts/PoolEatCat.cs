using System.Linq;
using UnityEngine;

public class PoolEatCat : LunariaBehaviour {
    public Transform OffsetTransform;
    public Vector3 Offset;
    public bool Inside;
    public PoolEatCat[] Others = new PoolEatCat[0];

    private Transform playerTransform;
    private SpriteRenderer playerRenderer;
    private SpriteMask playerMask;
    private Texture2D maskTexture;
    private Sprite maskSprite;

    void Start() {
        playerTransform = Lunaria.Player.transform;
        playerRenderer = Lunaria.Player.Renderer;
        playerMask = Lunaria.Player.GetComponentInChildren<SpriteMask>();
        playerMask.enabled = false;

        //int height = playerRenderer.sprite.texture.height / 4;

        ////playerMask.transform.position = new Vector2(
        ////    -playerRenderer.size.x / 2 * playerTransform.localScale.x,
        ////    -playerRenderer.size.y / 4 * 3 * playerTransform.localScale.y);

        //Debug.Log(playerTransform.localScale.x + " " + playerTransform.localScale.y);

        //maskTexture = new Texture2D(
        //    (int)playerRenderer.size.x,
        //    height);

        //int y = playerRenderer.sprite.texture.height - height;

        //Color[] whole = new Color[height * maskTexture.width];
        //for (int i = 0; i < whole.Length; i++) whole[i] = Color.white;
        //maskTexture.SetPixels(
        //    0,
        //    0,
        //    maskTexture.width,
        //    height,
        //    whole);
        //maskTexture.Apply();

        //maskSprite = Sprite.Create(
        //    maskTexture,
        //    new Rect(
        //        0,
        //        0,
        //        maskTexture.width,
        //        height),
        //    Vector2.zero);
    }

    void Update() {

    }

    void OnTriggerEnter2D(Collider2D collider) {
        Inside = true;
        playerMask.enabled = true;
        OffsetTransform.localPosition = Offset;
    }
    void OnTriggerExit2D(Collider2D collider) {
        Inside = false;
        bool insideAny = false;
        foreach (PoolEatCat other in Others) {
            if (other.Inside) {
                OffsetTransform.position = other.Offset;
                insideAny = true;
            }
        }
        if (!insideAny) playerMask.enabled = false;
        OffsetTransform.localPosition = Vector3.zero;
    }
}
