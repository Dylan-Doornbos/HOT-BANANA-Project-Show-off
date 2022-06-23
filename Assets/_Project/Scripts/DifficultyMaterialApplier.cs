using System;
using System.Linq;
using UnityEngine;

public class DifficultyMaterialApplier : MonoBehaviour
{
    [SerializeField] private RAMSelectedDifficulty _selectedDifficulty;
    [SerializeField] private MeshRenderer[] _renderersToUpdate;
    [SerializeField] private difficultyMaterial[] _difficultyMaterials;

    private void OnEnable()
    {
        foreach (difficultyMaterial difficultyMaterial in _difficultyMaterials)
        {
            if (_selectedDifficulty.difficulty != difficultyMaterial._difficulty) continue;
            
            foreach (MeshRenderer meshRenderer in _renderersToUpdate)
            {
                meshRenderer.material = difficultyMaterial._material;
            }
                
            return;
        }
    }

    [Serializable]
    internal class difficultyMaterial
    {
        public RAMDifficultySettings _difficulty;
        public Material _material;
    }
}
