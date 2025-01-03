using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace SimpleAPI.Helpers;

public class SequentialStringValueGenerator : ValueGenerator<string>
{
    private static int _counter = 0;

    public override bool GeneratesTemporaryValues => false;

    public override string Next(EntityEntry entry)
    {
        var timestamp = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
        var sequence = Interlocked.Increment(ref _counter).ToString("D6");
        return $"INC-{timestamp}-{sequence}";
    }
}