using System;

[Serializable]
public enum AreaMaskEnum
{
    None = 0,
    Street = 8,
    Outer_Sidewalk = 16,
    Inner_Sidewalk_01 = 32,
    Inner_Sidewalk_02 = 64,
    Sky = 128
}
