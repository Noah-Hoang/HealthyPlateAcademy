using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterNameDisplay : MonoBehaviour
{
    public TextMeshProUGUI nameDisplay;

    public void Start()
    {
        nameDisplay.text = IntroButtons.characterName;
    }
}
