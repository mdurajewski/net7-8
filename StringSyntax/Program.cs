using System.Diagnostics.CodeAnalysis;

TestRegex(@"^a\d+|b\w*");

TestDate(DateTime.Now, "O");

void TestDate(DateTime dateTime, [StringSyntax(StringSyntaxAttribute.DateTimeFormat)] string format) { }
void TestRegex([StringSyntax(StringSyntaxAttribute.Regex)] string regex) { }