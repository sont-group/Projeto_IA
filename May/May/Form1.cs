using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace May
{
    public partial class Form1 : Form
    {
        SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();
        SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Choices commands = new Choices();
            commands.Add(new string[] { "ok computer", "how are you", "who are you" });
            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(commands);
            Grammar g = new Grammar(gb);
            recognizer.LoadGrammarAsync(g);
            recognizer.SetInputToDefaultAudioDevice();
            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);
        }

         void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text)
            {
                case "ok computer":
                    synthesizer.Speak("yes, sir");
                    textBox1.Text += "\n" + e.Result.Text;
                    return;
                case "how are you":
                    synthesizer.Speak("i am fine, sir");
                    textBox1.Text += "\n" + e.Result.Text;
                    return;
                case "who are you":
                    synthesizer.Speak("i am you computer");
                    textBox1.Text += "\n" + e.Result.Text;
                    return;


            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            recognizer.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            recognizer.RecognizeAsyncStop();
        }
    }
}
