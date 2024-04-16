using System.Collections.Generic;
using UnityEngine;
using Mendel.Objects;
using System.Linq;

namespace Mendel.Managers
{
    public class QuestionManager : MonoBehaviour
    {
        [SerializeField] private List<Question> questions;

        private void Start()
        {
            // Load questions from Resources
            questions.AddRange(Resources.LoadAll("Questions", typeof(Question)).Cast<Question>().ToArray());
        }


    }
}
