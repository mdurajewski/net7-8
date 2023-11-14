string? text = null;
int a = 0;
int b = 0;

ArgumentNullException.ThrowIfNull(text);
ArgumentException.ThrowIfNullOrWhiteSpace(text);

ArgumentOutOfRangeException.ThrowIfZero(a);

ArgumentOutOfRangeException.ThrowIfNegative(a);
ArgumentOutOfRangeException.ThrowIfNegativeOrZero(a);

ArgumentOutOfRangeException.ThrowIfGreaterThan(a, b);
ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(a, b);

ArgumentOutOfRangeException.ThrowIfLessThan(a, b);
ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(a, b);