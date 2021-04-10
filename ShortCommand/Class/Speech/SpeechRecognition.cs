using System;
using System.Globalization;
using System.Speech.Recognition;
using ShortCommand.Class.Command;

namespace ShortCommand.Class.Speech
{
    public class SpeechRecognition
    {
        private EventHandler<SpeechRecognizedEventArgs> speechRecognizedHandler;
        private ShortCommandClass shortCommand; //快捷命令

        public SpeechRecognition(EventHandler<SpeechRecognizedEventArgs> speechRecognizedHandler,
            ShortCommandClass shortCommand)
        {
            this.speechRecognizedHandler = speechRecognizedHandler;
            this.shortCommand = shortCommand;
        }


        public void BeginRecognizeAsync()
        {
            SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine(new CultureInfo("zh-CN"));

            Choices choices = new Choices();
            choices.Add(shortCommand.GetShortNames());
            GrammarBuilder grammarBuilder = new GrammarBuilder();
            grammarBuilder.Append(choices);
            Grammar grammar = new Grammar(grammarBuilder);

            // 自由文本识别
            DictationGrammar dictationGrammar = new DictationGrammar();
            recognizer.LoadGrammar(dictationGrammar);
            // 自定义词汇识别
            recognizer.LoadGrammar(grammar);
            recognizer.SpeechRecognized += speechRecognizedHandler;
            recognizer.SetInputToDefaultAudioDevice();
            recognizer.RecognizeAsync(RecognizeMode.Multiple);
        }
    }
}