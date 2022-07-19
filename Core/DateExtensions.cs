using System.Reflection;

namespace Core;
public static class DateExtensions
{
    public static T AppyTimeStrip<T>(this T sourceObject)
    {
        var dateProperties = sourceObject?.GetType().GetProperties().Where(m => m.PropertyType == typeof(DateTime?) || m.PropertyType == typeof(DateTime)).ToList();

        dateProperties?.ForEach(prop =>
        {

            var stripTimeAttribute = prop.GetCustomAttribute(typeof(StripTime));

            if (stripTimeAttribute != null)
            {
                var date = (prop.GetValue(sourceObject, null) as DateTime?);
                prop.SetValue(sourceObject, (date == null ? null : date?.Date));
            }
        });

        return sourceObject;
    }

    public static T ApplyDateTimeKind<T>(this T sourceObject) where T : class
    {
        var dateProperties = sourceObject.GetType().GetProperties().Where(m => m.PropertyType == typeof(DateTime?) || m.PropertyType == typeof(DateTime)).ToList();

        dateProperties.ForEach(prop =>
        {
            var dateTimeKindAttribute = prop.GetCustomAttribute(typeof(SetKind));

            if (dateTimeKindAttribute != null)
            {
                if (prop.PropertyType == typeof(DateTime?))
                {
                    var date = (DateTime?)prop.GetValue(sourceObject, null);
                    if (date.HasValue)
                    {
                        var newDate = DateTime.SpecifyKind(date.Value, ((SetKind)dateTimeKindAttribute).Kind);
                        prop.SetValue(sourceObject, newDate);
                    }
                }
                else
                {
                    var date = prop.GetValue(sourceObject, null);
                    if (date != null)
                    {
                        var newDate = DateTime.SpecifyKind((DateTime)date, ((SetKind)dateTimeKindAttribute).Kind);
                        prop.SetValue(sourceObject, newDate);
                    }
                }
            }
        });

        return sourceObject;
    }
}

[AttributeUsage(AttributeTargets.Property)]
public class SetKind : Attribute
{
    public DateTimeKind Kind;
    public SetKind(DateTimeKind kind)
    {
        this.Kind = kind;
    }
}

[AttributeUsage(AttributeTargets.Property)]
public class StripTime : Attribute
{
    public StripTime() { }
}
