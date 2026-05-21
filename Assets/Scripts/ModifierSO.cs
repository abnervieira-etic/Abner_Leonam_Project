using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
[CreateAssetMenu(fileName = "New Modifier", menuName = "Modifier/New Modifier")]
public class ModifierSO : ScriptableObject
{
    public Image modifierImage;
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player1") || other.gameObject.CompareTag("Player2"))
            {
              
            }
        }

        void GiveModifier(Player1 player)
        {

            Debug.Log("Modifier applied to " + player.name);
        }

        void RandomModifier()
        {
            
        }

        
}
