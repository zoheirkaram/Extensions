A demo on how to use attributes targeting class properties in a c# extension

#### Extensions:
- **ApplyDateTimeKind** works with _SetKind_ attribute
- **AppyTimeStrip** works with _StripTime_ attribute
- DateTime kind can be set using _SetKind_ attribute like:
```C#
[SetKind(DateTimeKind.Utc)]
public DateTime? DateDemo { get; set; }
```

Both extensions can apply to an instance of a class, but it will affect only properties decorated with _SetKind_ and _StripTime_ attributes.

Example:
```C#
var sample = new SampleObject()
{
    Date1 = new DateTime(2021, 10, 19, 19, 45, 33),
    Date2 = new DateTime(2021, 10, 12, 12, 2, 39),
    Date3 = new DateTime(2023, 11, 13, 7, 34, 10),
    Date4 = new DateTime(2023, 12, 14, 17, 12, 56)
};

sample.ApplyDateTimeKind().AppyTimeStrip();

public class SampleObject
{
	public int Number1 { get; set; }
	public string SomeText { get; set; }
	public DateTime? Date1 { get; set; }
	[StripTime]
	public DateTime? Date2 { get; set; }
	[SetKind(DateTimeKind.Utc)]
	[StripTime]
	public DateTime? Date3 { get; set; }
	[SetKind(DateTimeKind.Local)]
	public DateTime? Date4 { get; set; }
}
```

Result will be:

    10/19/2021 07:45:33 PM  - Kind = Unspecified
    10/12/2021 12:00:00 AM  - Kind = Unspecified
    11/13/2023 12:00:00 AM  - Kind = Utc
    12/14/2023 05:12:56 PM  - Kind = Local
