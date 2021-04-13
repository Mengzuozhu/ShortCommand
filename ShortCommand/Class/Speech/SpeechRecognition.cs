using System;
using System.Globalization;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace ShortCommand.Class.Speech
{
    public class SpeechRecognition
    {
        private const string OpenSpeechText = "开启语音识别";
        private const string CloseSpeechText = "关闭语音识别";
        private readonly EventHandler<SpeechRecognizedEventArgs> speechRecognizedHandler;

        public bool EnabledSpeech { get; set; }

        public string[] Phrases { get; set; }

        private SpeechRecognitionEngine speechRecognitionEngine;
        private readonly SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
        private readonly string[] fixControlPhrase = {OpenSpeechText, CloseSpeechText};

        public SpeechRecognition(EventHandler<SpeechRecognizedEventArgs> speechRecognizedHandler, string[] phrases)
        {
            this.speechRecognizedHandler = speechRecognizedHandler;
            Phrases = phrases;
        }

        public static bool IsOpenSpeechText(string recognizedName)
        {
            return recognizedName.Equals(OpenSpeechText);
        }

        private static string BuildTextToSpeak(String text)
        {
            return $"已{text}模式";
        }

        public void OpenOrClose(bool enableSpeech)
        {
            if (enableSpeech)
            {
                OpenRecognizeAsync();
            }
            else
            {
                EnabledSpeech = false;
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
            if (speechRecognitionEngine == null)
            {
                return;
            }

            speechRecognitionEngine.Dispose();
            speechRecognitionEngine = null;
        }

        public bool UpdateEnabledSpeech(string recognizedName)
        {
            if (IsOpenSpeechText(recognizedName))
            {
                EnabledSpeech = true;
                speechSynthesizer.SpeakAsync(BuildTextToSpeak(OpenSpeechText));
            }
            else if (recognizedName.Equals(CloseSpeechText))
            {
                EnabledSpeech = false;
                speechSynthesizer.SpeakAsync(BuildTextToSpeak(CloseSpeechText));
            }

            return EnabledSpeech;
        }

        private void LoadGrammar(string[] phrases)
        {
            Choices choices = new Choices(phrases);
            choices.Add(fixControlPhrase);
            GrammarBuilder grammarBuilder = new GrammarBuilder(choices);
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