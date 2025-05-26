using System.Runtime.InteropServices;

namespace Demos;

[StructLayout(LayoutKind.Explicit)]
internal unsafe struct VASigCookie : IDisposable
{
    [FieldOffset(0)]
    public uint SizeOfArgs;

    [FieldOffset(8)]
    public ulong NDirectILStub;

    [FieldOffset(16)]
    public nint Module;

    [FieldOffset(24)]
    public nint LoaderModule;

    [FieldOffset(32)]
    public NativeSignature Signature;

    [FieldOffset(48)]
    public Instantiation ClassInst;

    [FieldOffset(64)]
    public Instantiation MethodInst;

    public VASigCookie(Span<byte> signature)
    {
        var nativeSignature = NativeMemory.Alloc((nuint)signature.Length);
        signature.CopyTo(new Span<byte>(nativeSignature, signature.Length));

        Signature = new()
        {
            Sig = (nint)nativeSignature,
            CbSig = (uint)signature.Length
        };
    }

    public void Dispose()
    {
        NativeMemory.Free((void*)Signature.Sig);
    }

    [StructLayout(LayoutKind.Explicit, Size = 16)]
    public struct NativeSignature
    {
        [FieldOffset(0)]
        public nint Sig;

        [FieldOffset(8)]
        public uint CbSig;
    }

    [StructLayout(LayoutKind.Explicit, Size = 16)]
    public struct Instantiation
    {
        [FieldOffset(0)]
        public nint Args;

        [FieldOffset(8)]
        public uint Count;
    }
}