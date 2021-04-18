using NAudio.Wave;

namespace ShortCommand.Class.Device
{
    public class DeviceHelper
    {
        public static bool HasInDevice()
        {
            return WaveIn.DeviceCount > 0;
        }
    }
}