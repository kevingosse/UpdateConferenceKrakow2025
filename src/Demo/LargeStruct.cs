namespace Demos;

internal struct LargeStruct(long a, long b, long c, long d)
{
    public long A = a;
    public long B = b;
    public long C = c;
    public long D = d;

    public override string ToString() => $"{A} {B} {C} {D}";
}