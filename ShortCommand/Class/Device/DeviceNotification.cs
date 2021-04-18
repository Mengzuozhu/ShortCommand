using NAudio.CoreAudioApi;
using NAudio.CoreAudioApi.Interfaces;
using ShortCommand.Class.Speech;

namespace ShortCommand.Class.Device
{
    public class DeviceNotification : IMMNotificationClient
    {
        private readonly SpeechRecognitionFacade speechRecognitionFacade;
        private readonly MMDeviceEnumerator deviceEnum = new MMDeviceEnumerator();

        public DeviceNotification(SpeechRecognitionFacade speechRecognitionFacade)
        {
            this.speechRecognitionFacade = speechRecognitionFacade;
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
            speechRecognitionFacade.OpenOrClose(speechRecognitionFacade.EnabledSpeech);
        }

        public void OnPropertyValueChanged(string pwstrDeviceId, PropertyKey key)
        {
        }
    }
}