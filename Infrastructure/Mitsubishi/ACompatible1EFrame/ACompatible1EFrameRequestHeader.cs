using System.Net.Http.Headers;

namespace Infrastructure.Mitsubishi.ACompatible1EFrame;

public class ACompatible1EFrameRequestHeader
{
    public readonly static ACompatible1EFrameRequestHeader DEVICE_MEM_BULK_READ_BIT = new ACompatible1EFrameRequestHeader(0x00);
    public readonly static ACompatible1EFrameRequestHeader DEVICE_MEM_BULK_READ_WORD = new ACompatible1EFrameRequestHeader(0x01);
    public readonly static ACompatible1EFrameRequestHeader DEVICE_MEM_BULK_WRITE_BIT = new ACompatible1EFrameRequestHeader(0x02);
    public readonly static ACompatible1EFrameRequestHeader DEVICE_MEM_BULK_WRITE_WORD = new ACompatible1EFrameRequestHeader(0x03);
    public readonly static ACompatible1EFrameRequestHeader DEVICE_MEM_TEST_WRITE_BIT = new ACompatible1EFrameRequestHeader(0x04);
    public readonly static ACompatible1EFrameRequestHeader DEVICE_MEM_TEST_WRITE_WORD = new ACompatible1EFrameRequestHeader(0x05);
    public readonly static ACompatible1EFrameRequestHeader DEVICE_MEM_MONITOR_REGISTER_BIT = new ACompatible1EFrameRequestHeader(0x06);
    public readonly static ACompatible1EFrameRequestHeader DEVICE_MEM_MONITOR_REGISTER_WORD = new ACompatible1EFrameRequestHeader(0x07);
    public readonly static ACompatible1EFrameRequestHeader DEVICE_MEM_MONITOR_BIT = new ACompatible1EFrameRequestHeader(0x08);
    public readonly static ACompatible1EFrameRequestHeader DEVICE_MEM_MONITOR_WORD = new ACompatible1EFrameRequestHeader(0x09);
    private ACompatible1EFrameRequestHeader(byte value)
    {
        Value = value;
    }

    public byte Value { get; }

    public static ACompatible1EFrameRequestHeader Create(byte value)
    {
        return new ACompatible1EFrameRequestHeader(value);
    }

    public override bool Equals(object? obj)
    {
        var value = obj as ACompatible1EFrameRequestHeader;
        if (value == null)
        {
            return false;
        }
        return value.Value == Value;
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}
