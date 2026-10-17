using UnityEngine;
using SerializeReferenceEditor;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Data/Card")]
public class CardData : ScriptableObject
{
    [field : SerializeField] public string Description {get; private set;}
    [field : SerializeField] public int Mana {get; private set;}
    [field : SerializeField] public Sprite Image {get; private set;}
    
    //[field : SerializeReference, SR] public List<Effect> ManualTargetEffect {get; private set;} // check later 
    
    [field: SerializeReference, SR] public Effect ManualTargetingEffect { get; private set; } = null;
    [field: SerializeReference, SR] public List<AutoTargetEffect> OtherEffects {get; private set;}  
}
