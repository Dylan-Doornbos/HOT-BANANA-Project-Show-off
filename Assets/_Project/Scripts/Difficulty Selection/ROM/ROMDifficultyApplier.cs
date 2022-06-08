using UnityEngine;

public class ROMDifficultyApplier : DifficultyApplier<ROMSelectedDifficulty, ROMDifficultySettings>
{
    [Header("References")] 
    [SerializeField] private MovingBeam _horizontalBeam;
    [SerializeField] private MovingBeam _verticalBeam;

    protected override void Awake()
    {
        base.Awake();
        if (_horizontalBeam == null || _verticalBeam == null)
        {
            DebugUtil.Log($"Missing references for '{GetType()}' on '{gameObject.name}'.", LogType.WARNING);
        }
    }

    protected override void applyDifficulty()
    {
        applyBeamSettings(_horizontalBeam, _settingsToApply.horizontalBeam);
        applyBeamSettings(_verticalBeam, _settingsToApply.verticalBeam);
    }

    private void applyBeamSettings(MovingBeam pBeam, BeamSettings pSettings)
    {
        if(pBeam == null || pSettings == null) return;
        
        pBeam.SetEnabledState(pSettings.enable);
        
        if(!pSettings.enable) return;

        pBeam.SetSpeed(pSettings.speed);
        pBeam.SetMoveBehaviour(pSettings.randomizeMovement);
    }
}
