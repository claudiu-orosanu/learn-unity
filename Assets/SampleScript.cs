using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace BeyondTheBasics.Gameplay
{
    public class SampleScript : MonoBehaviour
    {
        #region Variable Declarations

        public int numberToDisplay;
        private int numberToMultiplyBy = 10;

        #endregion

        #region Private Methods

        // Start is called before the first frame update
        private void Start()
        {
            AnonymousTypeExample();
        }

        private void SayHelloWorld()
        {
            var randomNumber = UnityEngine.Random.Range(0, numberToDisplay);
            var displayText = "Hello World!";

            for (var i = 0; i < randomNumber; i++)
            {
                Debug.Log(displayText);
            }
        }

        private void MultiplyNumber(int numberToMultiply)
        {
            int product = numberToMultiply * numberToMultiplyBy;

            Debug.Log(product);
        }

        private void AnonymousTypeExample()
        {
            //  var enemy = new { name = "Monster", hitPoints = 100 };

            var enemies = new[] {
                                new { name = "Monster", hitPoints = 100 },
                                new { name = "Goblin", hitPoints = 200 },
                                new { name = "Beast", hitPoints = 250 }
                            };

            var enemyQuery =
                from enemy in enemies
                orderby enemy.name
                select enemy;

            foreach (var enemy in enemyQuery)
            {
                Debug.Log(enemy.name);
            }

        }
       
         #endregion
    }
}