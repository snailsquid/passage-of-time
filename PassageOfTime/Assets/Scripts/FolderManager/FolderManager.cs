using UnityEngine;
public class FolderManager
{
    public static readonly string CHARACTERS = "2D/Characters/";
    public static readonly string BACKGROUNDS = "2D/Backgrounds/";
    /// <summary>
    /// Searches for the sprite in the Characters folder
    /// </summary>
    /// <param name="character">Straight from ink with template 'character:variant' or just 'character'</param>
    /// <returns>Sprite of the given name</returns>
    public static Sprite GetCharacterSprite(string character)
    {
        character = character.Replace(":", "@");
        return Resources.Load<Sprite>(CHARACTERS + character);
    }
    public static Sprite GetBackgroundSprite(string imageName)
    {
        return Resources.Load<Sprite>(BACKGROUNDS + imageName);
    }
}
