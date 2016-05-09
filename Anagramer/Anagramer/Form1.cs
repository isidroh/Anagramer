using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anagramer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            anagramFinder = new AnagramFinder();
        }
        private void DisplayTextList(List<string> listOfStrings)
        {
            string resultsText = string.Format("Number of results = {0}\r\n", listOfStrings.Count);
            foreach (var anagrams in listOfStrings)
            {
                resultsText += anagrams;
                resultsText += "\r\n";
            }
            textBoxAnagrams.Text = resultsText;
        }
        private AnagramFinder anagramFinder;

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxAnagrams.ReadOnly = true;
            textBoxMinWords.Text = "3";
            textBoxMinWordLength.Text = "6";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DisplayTextList(anagramFinder.ListAllAnagrams(Int32.Parse(textBoxMinWordLength.Text), Int32.Parse(textBoxMinWords.Text)));
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBoxAnagrams.Text = anagramFinder.GetSingleWordAnagramsOfWord(textBoxWordToGetAnagramsOf.Text.Replace(" ", ""));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DisplayTextList(anagramFinder.GetMultiWordAnagramsOfWord(textBoxWordToGetAnagramsOf.Text.Replace(" ", ""), 3));
        }
    }
}
