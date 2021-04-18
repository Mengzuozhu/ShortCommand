namespace ShortCommand.Class.Speech
{
    /// <summary>
    /// 语音识别策略
    /// </summary>
    public interface ISpeechRecognitionStrategy
    {
        /// <summary>
        /// Opens the recognize asynchronous.
        /// </summary>
        void OpenRecognizeAsync();

        /// <summary>
        /// Closes the recognize.
        /// </summary>
        void CloseRecognize();


        /// <summary>
        /// Adds the grammar.
        /// </summary>
        /// <param name="phrases">The phrases.</param>
        void AddGrammar(string[] phrases);
    }
}