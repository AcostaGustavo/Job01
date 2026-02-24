
namespace ClassTime.Backend;
public class Time  //Fields
{
    private int _hour;
    private int _millisecond;
    private int _minute;
    private int _second;

    //Empty Builder 
    public Time()
    {
        _hour = 0;
        _millisecond = 0;
        _minute = 0;
        _second = 0;    
    }
    
    //Builder 2
    public Time( int hour)
    {
        _hour = hour;
    }

    //Builder 3
    public Time(int hour, int minute)
    {
        _hour = hour;
        _minute = minute;
    }

    //Builder 4
    public Time(int hour, int minute, int second)
    {
        _hour = hour;
        _minute = minute;
        _second = second;
    }
    //Builder 5
    public Time(int hour, int minute, int second, int millisecond)
    {
        _hour = hour;
        _minute = minute;
        _second = second;
        _millisecond = millisecond;
    }

    //Properties
    public int Hour {
        get => _hour;
        set => _hour = value;
    }
    public int Millisecond { 
        get => _millisecond;
        set => _millisecond = value;
    }
    public int Minute {
        get => _minute;
        set => _minute = value;
    }
    public int Second {
        get => _second;
        set => _second = value;
    }

    public object Add(Time t3)
    {
        throw new NotImplementedException();
    }

    public bool IsOtherDay(Time t4)
    {
        throw new NotImplementedException();
    }

    public object ToMilliseconds()
    {
        throw new NotImplementedException();
    }

    public object ToMinutes()
    {
        throw new NotImplementedException();
    }

    public object ToSecons()
    {
        throw new NotImplementedException();
    }
}

