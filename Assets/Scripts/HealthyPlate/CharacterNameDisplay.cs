using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Fusion;

public class CharacterNameDisplay : NetworkBehaviour
{
    public TextMeshProUGUI nameDisplay;

    [Networked, OnChangedRender(nameof(SetNameDisplay))]
    public string characterName { get; set; }

    public override void Spawned()
    {
        if (Object.HasStateAuthority)
        {
            characterName = IntroButtons.characterName;
        }
    }

    public void SetNameDisplay()
    {
        nameDisplay.text = characterName;
    }
}
