using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Mendel
{
    public class GamePanel : MonoBehaviour
    {
        [SerializeField] private TextMeshPro questionText;
        [SerializeField] private Button btnOption1;
        [SerializeField] private Button btnOption2;
        [SerializeField] private Button btnOption3;
        [SerializeField] private Button btnOption4;

        #region Properties

        public string QuestionString
        {
            get
            {
                return questionText.text;
            }

            set
            {
                questionText.text = value;
            }
        }

        public string Option1
        {
            get
            {
                return btnOption1.GetComponentInChildren<TextMeshPro>().text;
            }

            set
            {
                btnOption1.GetComponentInChildren<TextMeshPro>().text = value; ;
            }
        }

        public string Option2
        {
            get
            {
                return btnOption2.GetComponentInChildren<TextMeshPro>().text;
            }

            set
            {
                btnOption2.GetComponentInChildren<TextMeshPro>().text = value; ;
            }
        }

        public string Option3
        {
            get
            {
                return btnOption3.GetComponentInChildren<TextMeshPro>().text;
            }

            set
            {
                btnOption3.GetComponentInChildren<TextMeshPro>().text = value; ;
            }
        }

        public string Option4
        {
            get
            {
                return btnOption4.GetComponentInChildren<TextMeshPro>().text;
            }

            set
            {
                btnOption4.GetComponentInChildren<TextMeshPro>().text = value; ;
            }
        }

        #endregion
    }
}
