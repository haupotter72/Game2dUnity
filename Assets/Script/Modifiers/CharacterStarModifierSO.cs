using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterStarModifierSO : ScriptableObject
{
    public abstract void AffectCharacter(GameObject gameObject, float value);
}
