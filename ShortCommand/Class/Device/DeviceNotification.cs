using NAudio.CoreAudioApi;
using NAudio.CoreAudioApi.Interfaces;
using ShortCommand.Class.Speech;

namespace ShortCommand.Class.Device
{
    public class DeviceNotification : IMMNotificationClient
    {
        private readonly SpeechRecognition speechRecognition;
        private readonly MMDeviceEnumerator deviceEnum = new MMDeviceEnumerator();

        public DeviceNotification(SpeechRecognition speechRecognition)
        {
            this.speechRecognition = speechRecognition;
            deviceEnum.RegisterEndpointNotificationCallback(this);
        }

        public void OnDeviceStateChanged(string deviceId, DeviceState newState)
        {
        }

        public void OnDeviceAdded(string pwstrDeviceId)
        {
        }

        public void OnDeviceRemoved(string deviceId)
        {
        }

        public void OnDefaultDeviceChanged(DataFlow flow, Role role, string defaultDeviceId)
        {
            speechRecognition.OpenOrClose(speechRecognition.EnabledSpeech);
        }

        public void OnPropertyValueChanged(string pwstrDeviceId, PropertyKey key)
        {
        }
    }
}