namespace Infrastructure.Mitsubishi.ACompatible1EFrame;

public class ACompatible1EFrameResponseHeader
{
    public readonly static ACompatible1EFrameResponseHeader DEVICE_MEM_BULK_READ_BIT = new ACompatible1EFrameResponseHeader(0x80, RegisterType.BIT);
    public readonly static ACompatible1EFrameResponseHeader DEVICE_MEM_BULK_READ_WORD = new ACompatible1EFrameResponseHeader(0x81, RegisterType.WORD);
    public readonly static ACompatible1EFrameResponseHeader DEVICE_MEM_BULK_WRITE_BIT = new ACompatible1EFrameResponseHeader(0x82, RegisterType.BIT);
    public readonly static ACompatible1EFrameResponseHeader DEVICE_MEM_BULK_WRITE_WORD = new ACompatible1EFrameResponseHeader(0x83, RegisterType.WORD);
    public readonly static ACompatible1EFrameResponseHeader DEVICE_MEM_TEST_WRITE_BIT = new ACompatible1EFrameResponseHeader(0x84, RegisterType.BIT);
    public readonly static ACompatible1EFrameResponseHeader DEVICE_MEM_TEST_WRITE_WORD = new ACompatible1EFrameResponseHeader(0x85, RegisterType.WORD);
    public readonly static ACompatible1EFrameResponseHeader DEVICE_MEM_MONITOR_REGISTER_BIT = new ACompatible1EFrameResponseHeader(0x86, RegisterType.BIT);
    public readonly static ACompatible1EFrameResponseHeader DEVICE_MEM_MONITOR_REGISTER_WORD = new ACompatible1EFrameResponseHeader(0x87, RegisterType.WORD);
    public readonly static ACompatible1EFrameResponseHeader DEVICE_MEM_MONITOR_BIT = new ACompatible1EFrameResponseHeader(0x88, RegisterType.BIT);
    public readonly static ACompatible1EFrameResponseHeader DEVICE_MEM_MONITOR_WORD = new ACompatible1EFrameResponseHeader(0x89, RegisterType.WORD);
    private ACompatible1EFrameResponseHeader(byte value, RegisterType registerType)
    {
        Value = value;
        RegisterType = registerType;
    }

    public byte Value { get; }
    public RegisterType RegisterType { get; }

    public override bool Equals(object? obj)
    {
        var value = obj as ACompatible1EFrameResponseHeader;
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
