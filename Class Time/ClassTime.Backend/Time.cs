namespace ClassTime.Backend;

public class Time
{
    private int _hour;
    private int _minute;
    private int _second;
    private int _millisecond;

    // Constructor 1
    public Time()
    {
        Hour = 0;
        Minute = 0;
        Second = 0;
        Millisecond = 0;
    }

    // Constructor 2
    public Time(int hour)
    {
        Hour = hour;
        Minute = 0;
        Second = 0;
        Millisecond = 0;
    }

    // Constructor 3
    public Time(int hour, int minute)
    {
        Hour = hour;
        Minute = minute;
        Second = 0;
        Millisecond = 0;
    }

    // Constructor 4
    public Time(int hour, int minute, int second)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
        Millisecond = 0;
    }

    // Constructor 5
    public Time(int hour, int minute, int second, int millisecond)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
        Millisecond = millisecond;
    }

    // Properties
    public int Hour
    {
        get => _hour;
        set => _hour = ValidateHour(value);
    }

    public int Minute
    {
        get => _minute;
        set => _minute = ValidateMinute(value);
    }

    public int Second
    {
        get => _second;
        set => _second = ValidateSecond(value);
    }

    public int Millisecond
    {
        get => _millisecond;
        set => _millisecond = ValidateMillisecond(value);
    }

    // Validations
    private int ValidateHour(int value)
    {
        if (value < 0 || value > 23)
            throw new Exception( $"The hour: {value}, is not valid.");

        return value;
    }

    private int ValidateMinute(int value)
    {
        if (value < 0 || value > 59)
            throw new ArgumentOutOfRangeException(nameof(Minute),
                $"The minute: {value}, is not valid.");

        return value;
    }

    private int ValidateSecond(int value)
    {
        if (value < 0 || value > 59)
            throw new ArgumentOutOfRangeException(nameof(Second),
                $"The second: {value}, is not valid.");

        return value;
    }

    private int ValidateMillisecond(int value)
    {
        if (value < 0 || value > 999)
            throw new ArgumentOutOfRangeException(nameof(Millisecond),
                $"The millisecond: {value}, is not valid.");

        return value;
    }

    // Convert methods
    public long ToMilliseconds()
    {
        return ((long)Hour * 3600 + (long)Minute * 60 + Second) * 1000 + Millisecond;
    }

    public long ToSecons()
    {
        return (long)Hour * 3600 + (long)Minute * 60 + Second;
    }

    public long ToMinutes()
    {
        return (long)Hour * 60 + Minute;
    }

    // Add method
    public Time Add(Time other)
    {
        int millisecond = this.Millisecond + other.Millisecond;
        int carrySecond = millisecond / 1000;
        millisecond %= 1000;

        int second = this.Second + other.Second + carrySecond;
        int carryMinute = second / 60;
        second %= 60;

        int minute = this.Minute + other.Minute + carryMinute;
        int carryHour = minute / 60;
        minute %= 60;

        int hour = this.Hour + other.Hour + carryHour;
        hour %= 24;

        return new Time(hour, minute, second, millisecond);
    }

    // Check if next day
    public bool IsOtherDay(Time other)
    {
        int millisecond = this.Millisecond + other.Millisecond;
        int carrySecond = millisecond / 1000;

        int second = this.Second + other.Second + carrySecond;
        int carryMinute = second / 60;

        int minute = this.Minute + other.Minute + carryMinute;
        int carryHour = minute / 60;

        int hour = this.Hour + other.Hour + carryHour;

        return hour > 23;
    }

    //Format 12-hour clock
    public override string ToString()
    {
        string period = Hour >= 12 ? "PM" : "AM";

        int hour12;

        if (Hour == 0)
            hour12 = 0;
        else if (Hour > 12)
            hour12 = Hour - 12;
        else
            hour12 = Hour;

        return $"{hour12:00}:{Minute:00}:{Second:00}.{Millisecond:000} {period}";
    }

}
