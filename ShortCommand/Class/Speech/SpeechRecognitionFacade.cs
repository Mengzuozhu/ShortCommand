using System;
using System.Speech.Synthesis;

namespace ShortCommand.Class.Speech
{
    /// <summary>
    /// 语音识别统一控制
    /// </summary>
    public class SpeechRecognitionFacade
    {
        private const string OpenSpeechText = "开启语音识别";
        private const string CloseSpeechText = "关闭语音识别";
        private readonly SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
        private readonly string[] fixControlPhrase = {OpenSpeechText, CloseSpeechText};
        private readonly ISpeechRecognitionStrategy recognitionStrategy;

        public bool EnabledSpeech { get; set; }

        public string[] Phrases { get; set; }

        public SpeechRecognitionFacade(ISpeechRecognitionStrategy recognitionStrategy)
        {
            this.recognitionStrategy = recognitionStrategy;
        }

        public static bool IsOpenSpeechText(string recognizedName)
        {
            return recognizedName.Equals(OpenSpeechText);
        }

        public void OpenOrClose(bool enableSpeech)
        {
            if (enableSpeech)
            {
                recognitionStrategy.OpenRecognizeAsync();
                recognitionStrategy.AddGrammar(fixControlPhrase);
            }
            else
            {
                recognitionStrategy.CloseRecognize();
            }

            EnabledSpeech = enableSpeech;
        }

        public bool UpdateEnabledSpeech(string recognizedName)
        {
            if (IsOpenSpeechText(recognizedName))
            {
                if (!EnabledSpeech)
                {
                    speechSynthesizer.SpeakAsync(BuildTextToSpeak(OpenSpeechText));
                }

                EnabledSpeech = true;
            }
            else if (recognizedName.Equals(CloseSpeechText))
            {
                if (EnabledSpeech)
                {
                    speechSynthesizer.SpeakAsync(BuildTextToSpeak(CloseSpeechText));
                }

                EnabledSpeech = false;
            }

            return EnabledSpeech;
        }

        private static string BuildTextToSpeak(String text)
        {
            return $"已{text}模式";
        }
    }
}