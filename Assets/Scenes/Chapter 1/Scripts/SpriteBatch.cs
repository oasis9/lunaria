using System;
using System.Linq;

[Serializable]
public class SpriteBatch {
    public SpriteInfo[] Sprites = new SpriteInfo[0];

    public SpriteInfo GetSprite(string name) {
        return Sprites.First(sprite => sprite.Name.Equals(name));
    }
}