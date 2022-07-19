using Core;

var sample = new SampleObject()
{
    Date1 = new DateTime(2021, 10, 19, 19, 45, 33),
    Date2 = new DateTime(2021, 10, 12, 12, 2, 39),
    Date3 = new DateTime(2023, 11, 13, 7, 34, 10),
    Date4 = new DateTime(2023, 12, 14, 17, 12, 56)
};

sample.ApplyDateTimeKind().AppyTimeStrip();

Console.WriteLine((sample.Date1.HasValue ? $"{sample.Date1} - Kind = {sample.Date1.Value.Kind}" : "null value"));
Console.WriteLine((sample.Date2.HasValue ? $"{sample.Date2} - Kind = {sample.Date2.Value.Kind}" : "null value"));
Console.WriteLine((sample.Date3.HasValue ? $"{sample.Date3} - Kind = {sample.Date3.Value.Kind}" : "null value"));
Console.WriteLine((sample.Date4.HasValue ? $"{sample.Date4} - Kind = {sample.Date4.Value.Kind}" : "null value"));

public class SampleObject
{
    public int Number1 { get; set; }
    public string? SomeText { get; set; }
    public DateTime? Date1 { get; set; }
    [StripTime]
    public DateTime? Date2 { get; set; }
    [SetKind(DateTimeKind.Utc)]
    [StripTime]
    public DateTime? Date3 { get; set; }
    [SetKind(DateTimeKind.Local)]
    public DateTime? Date4 { get; set; }
}