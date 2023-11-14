var tp = TimeProvider.System.GetLocalNow();

var start = TimeProvider.System.GetTimestamp();
var end = TimeProvider.System.GetTimestamp();

var diff = TimeProvider.System.GetElapsedTime(start, end);