using UnityEngine;
using UnityEngine.UI;

namespace Mendel.Objects
{
    [CreateAssetMenu(fileName = "Question", menuName = "Data/New Question", order = 1)]
    public class Question : ScriptableObject
    {
        [SerializeField] private Sprite image;
        [SerializeField] private string questionString;
        [SerializeField] private string[] answers = new string[4];
        [SerializeField] private int correctAnswer;

        public Question(string questionString, string[] answers, int correctAnswer)
        {
            this.questionString = questionString;
            this.answers = answers;
            this.correctAnswer = correctAnswer; 
        }

        public Question(string questionString, string answer1, string answer2, 
            string answer3, string answer4, int correctAnswer)
        {
            answers = new string[4];
            answers[1] = answer1;
            answers[2] = answer2;
            answers[3] = answer3;
            answers[4] = answer4;

            new Question(questionString, answers, correctAnswer);
        }

        #region Properties

        public Sprite Image
        {
            get
            {
                return image;
            }

            private set
            {
                image = value;
            }
        }

        public string QuestionString
        {
            get
            {
                return questionString;
            }
        }

        public string[] Options
        {
            get
            {
                return answers;
            }
        }

        public int CorrectAnswer
        {
            get
            {
                return correctAnswer;
            }
        }

        #endregion

    }
}
