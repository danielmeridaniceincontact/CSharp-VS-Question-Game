using CSharpVSQuestionGame.CoreModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpVSQuestionGame
{
    public partial class Main : Form
    {
        private int index = 0;
        private int score = 0;
        private TriviaGame triviaGame;

        public Main()
        {
            InitializeComponent();
            label2.Text = score.ToString();
            label3.Text = score.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.MouseHover += OnMouseEnterButton;
            button1.MouseLeave += OnMouseLeaveButton;
            button2.MouseHover += OnMouseEnterButton;
            button2.MouseLeave += OnMouseLeaveButton;
            button3.MouseHover += OnMouseEnterButton;
            button3.MouseLeave += OnMouseLeaveButton;
            button4.MouseHover += OnMouseEnterButton;
            button4.MouseLeave += OnMouseLeaveButton;
            button5.MouseHover += OnMouseEnterButton;
            button5.MouseLeave += OnMouseLeaveButton;
            button6.MouseHover += OnMouseEnterButton;
            button6.MouseLeave += OnMouseLeaveButton;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadTrivia();
            LoadTriviaUI();
            tabControl1.SelectedIndex = 1;
        }

        private void OnMouseEnterButton(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.Green;
        }
        private void OnMouseLeaveButton(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.GreenYellow;
        }

        private void LoadTrivia()
        {
            triviaGame = CoreAPI.CoreAPI.GetTriviaGame();
        }

        private void LoadTriviaUI()
        {
            label2.Text = score.ToString();
            label6.Text = CleanString(triviaGame.results[index].question);
            List<string> answersList = new List<string>()
            {
                CleanString(triviaGame.results[index].correct_answer),
                CleanString(triviaGame.results[index].incorrect_answers[0]),
                CleanString(triviaGame.results[index].incorrect_answers[1]),
                CleanString(triviaGame.results[index].incorrect_answers[2])
            };
            
            Random random = new();
            List<string> answersListTemp = answersList.OrderBy(item => random.Next()).ToList();

            button3.Text = answersListTemp[0];
            button4.Text = answersListTemp[1];
            button5.Text = answersListTemp[2];
            button6.Text = answersListTemp[3];
        }

        private string CleanString(string text)
        {
            return text
                .Replace("#039;", "'")
            .Replace("&'", "'")
            .Replace("&quot;", "\"")
            .Replace("&lt;", "<")
            .Replace("&gt;", ">");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CheckResponse(((Button)sender).Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CheckResponse(((Button)sender).Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CheckResponse(((Button)sender).Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CheckResponse(((Button)sender).Text);
        }

        private void CheckResponse(string responseText)
        {
            if(triviaGame.results.Where(answer => answer.correct_answer == responseText).ToList().Count == 1)
            {
                index += 1;
                score += 10;
                if (index == triviaGame.results.Count)
                {
                    WinGame();
                }
                else
                {
                    LoadTriviaUI();
                }
            }
            else
            {
                LoseGame();
            }
        }

        private void LoseGame()
        {
            label4.Text = "SORRY, THIS ANSWER WAS WRONG";
            label3.Text = score.ToString();
            tabControl1.SelectedIndex = 2;
        }

        private void WinGame()
        {
            label4.Text = "YOU WIN!!!";
            label3.Text = score.ToString();
            tabControl1.SelectedIndex = 2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            score = 0;
            index = 0;
            LoadTrivia();
            LoadTriviaUI();
            tabControl1.SelectedIndex = 1;
        }
    }
}
