using System;
using System.Globalization;
using System.Linq;
using System.Speech.Recognition;
using ShortCommand.Class.Device;
using ShortCommand.Class.Helper;

namespace ShortCommand.Class.Speech
{
    /// <summary>
    /// 默认语音识别
    /// </summary>
    /// <seealso cref="ShortCommand.Class.Speech.ISpeechRecognitionStrategy" />
    public class DefaultSpeechRecognition : ISpeechRecognitionStrategy
    {
        private string[] Phrases { get; }

        private SpeechRecognitionEngine speechRecognitionEngine;
        private readonly EventHandler<SpeechRecognizedEventArgs> speechRecognizedHandler;
        private readonly CultureInfo cultureInfo = new CultureInfo("zh-CN");

        public DefaultSpeechRecognition(EventHandler<SpeechRecognizedEventArgs> recognizedHandler, string[] phrases)
            : this(recognizedHandler, phrases, true)
        {
        }

        public DefaultSpeechRecognition(EventHandler<SpeechRecognizedEventArgs> recognizedHandler, string[] phrases,
            bool onlyContainChinese)
        {
            this.speechRecognizedHandler = recognizedHandler;
            Phrases = onlyContainChinese ? phrases.Where(StringUtil.ContainsChinese).ToArray() : phrases;
        }

        /// <inheritdoc />
        public void OpenRecognizeAsync()
        {
            if (!DeviceHelper.HasInDevice())
            {
                CloseRecognize();
                return;
            }

            speechRecognitionEngine = new SpeechRecognitionEngine(cultureInfo);
            try
            {
                speechRecognitionEngine.SetInputToDefaultAudioDevice();
            }
            catch (InvalidOperationException)
            {
                return;
            }
            AddGrammar(Phrases);
            speechRecognitionEngine.SpeechRecognized += speechRecognizedHandler;
            speechRecognitionEngine.RecognizeAsync(RecognizeMode.Multiple);
        }

        /// <inheritdoc />
        public void CloseRecognize()
        {
            if (speechRecognitionEngine == null)
            {
                return;
            }

            speechRecognitionEngine.Dispose();
            speechRecognitionEngine = null;
        }

        /// <inheritdoc />
        public void AddGrammar(string[] phrases)
        {
            // 自定义词汇识别
            GrammarBuilder grammarBuilder = new GrammarBuilder(new Choices(phrases)) {Culture = cultureInfo};
            speechRecognitionEngine?.LoadGrammar(new Grammar(grammarBuilder));
        }

        private void ReloadGrammar(string[] phrases)
        {
            if (speechRecognitionEngine == null)
            {
                return;
            }

            speechRecognitionEngine.UnloadAllGrammars();
            AddGrammar(phrases);
        }

        private static DictationGrammar GetDictationGrammar()
        {
            // 自由文本识别
            return new DictationGrammar();
        }
    }
}