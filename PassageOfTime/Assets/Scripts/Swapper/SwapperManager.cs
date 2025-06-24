using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapperManager : Singleton<SwapperManager>
{
    [SerializeField] ImageSwapper backgroundSwapper;
    [SerializeField] SpriteSwapper characterSwapper;

    public void SwapBackground(string imageName)
    {
        Debug.Log(imageName);
        backgroundSwapper.Swap(FolderManager.GetBackgroundSprite(imageName));
    }
    public void SwapCharacter(string imageName)
    {
        if (imageName == "Narrator")
            imageName = "";
        characterSwapper.Swap(FolderManager.GetCharacterSprite(imageName));
    }
    void Start()
    {
        SwapBackground("Test01");
        SwapCharacter("Gurt");
    }
}
