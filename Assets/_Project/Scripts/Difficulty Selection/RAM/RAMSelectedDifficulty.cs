using UnityEngine;

[CreateAssetMenu(menuName = "Difficulties/Selected/RAM")]
public class RAMSelectedDifficulty : ScriptableObject
{
    [HideInInspector] public RAMDifficultySettings activeSettings;
}
