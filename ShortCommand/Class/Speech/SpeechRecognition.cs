using System;
using System.Globalization;
using System.Speech.Recognition;

namespace ShortCommand.Class.Speech
{
    public class SpeechRecognition
    {
        private readonly EventHandler<SpeechRecognizedEventArgs> speechRecognizedHandler;

        public string[] Phrases { get; set; }

        private SpeechRecognitionEngine speechRecognitionEngine;

        public SpeechRecognition(EventHandler<SpeechRecognizedEventArgs> speechRecognizedHandler, string[] phrases)
        {
            this.speechRecognizedHandler = speechRecognizedHandler;
            Phrases = phrases;
        }

        public void OpenOrClose(bool enableSpeech)
        {
            if (enableSpeech)
            {
                OpenRecognizeAsync();
            }
            else
            {
                CloseRecognize();
            }
        }

        public void OpenRecognizeAsync()
        {
            speechRecognitionEngine = new SpeechRecognitionEngine(new CultureInfo("zh-CN"));
            LoadGrammar(Phrases);
            speechRecognitionEngine.SpeechRecognized += speechRecognizedHandler;
            speechRecognitionEngine.SetInputToDefaultAudioDevice();
            speechRecognitionEngine.RecognizeAsync(RecognizeMode.Multiple);
        }

        public void CloseRecognize()
        {
            speechRecognitionEngine?.Dispose();
        }

        private void LoadGrammar(string[] phrases)
        {
            GrammarBuilder grammarBuilder = new GrammarBuilder(new Choices(phrases));
            Grammar grammar = new Grammar(grammarBuilder);

            // 自由文本识别
            //            DictationGrammar dictationGrammar = new DictationGrammar();
            //            recognizer.LoadGrammar(dictationGrammar);
            speechRecognitionEngine.UnloadAllGrammars();
            // 自定义词汇识别
            speechRecognitionEngine.LoadGrammar(grammar);
        }
    }
}