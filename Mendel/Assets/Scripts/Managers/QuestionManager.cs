using System.Collections.Generic;
using UnityEngine;
using Mendel.Objects;
using System.Linq;
using UnityEngine.UI;
using TMPro;

namespace Mendel.Managers
{
    public class QuestionManager : MonoBehaviour
    {
        public List<Question> questions;
        public int currentQuestionIndex;

        public Image image;
        public TextMeshProUGUI text;
        public TextMeshProUGUI opt1, opt2, opt3, opt4;

        public static QuestionManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("Found more than one Question Manager in the scene.");
            }

            Instance = this;
        }

        private void Start()
        {
            // Load questions from Resources
            questions.AddRange(Resources.LoadAll("Questions", typeof(Question)).Cast<Question>().ToArray());

            SetCurrentQuestion(currentQuestionIndex);
        }

        public void SetCurrentQuestion(int questionIndex)
        {
            SetCurrentQuestion(questions[questionIndex]);
        }

        public void SetCurrentQuestion(Question question)
        {
            image.sprite = question.Image;
            text.text = question.QuestionString;

            opt1.text = question.Options[0];
            opt2.text = question.Options[1];
            opt3.text = question.Options[2];
            opt4.text = question.Options[3];
        }
    }
}
    