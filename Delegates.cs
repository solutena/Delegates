using System;

public class Funcs<Result> where Result : IComparable
{
	Func<Result, Result> Func { get; set; }

	public static Funcs<Result> operator +(Funcs<Result> funcs, Func<Result, Result> action)
	{
		if (funcs == null)
			funcs = new Funcs<Result>();
		funcs.Func += action;
		return funcs;
	}

	public static Funcs<Result> operator -(Funcs<Result> funcs, Func<Result, Result> action)
	{
		if (funcs == null)
			funcs = new Funcs<Result>();
		funcs.Func -= action;
		return funcs;
	}

	public Result Invoke(Result value)
	{
		if (Func == null)
			return value;
		var list = Func.GetInvocationList();
		foreach (var loop in list)
		{
			Func<Result, Result> func = (Func<Result, Result>)loop;
			value = func(value);
		}
		return value;
	}
}

public class Funcs<T, Result> where Result : IComparable
{
	Func<T, Result, Result> Func { get; set; }

	public static Funcs<T, Result> operator +(Funcs<T, Result> funcs, Func<T, Result, Result> action)
	{
		if (funcs == null)
			funcs = new Funcs<T, Result>();
		funcs.Func += action;
		return funcs;
	}

	public static Funcs<T, Result> operator -(Funcs<T, Result> funcs, Func<T, Result, Result> action)
	{
		if (funcs == null)
			funcs = new Funcs<T, Result>();
		funcs.Func -= action;
		return funcs;
	}

	public Result Invoke(T target, Result value)
	{
		if (Func == null)
			return value;
		var list = Func.GetInvocationList();
		foreach (var loop in list)
		{
			Func<T, Result, Result> func = (Func<T, Result, Result>)loop;
			value = func(target, value);
		}
		return value;
	}
}

public class Event
{
	Action Callbacks { get; set; }
	Action Action { get; set; }

	public static Event operator +(Event target, Action action)
	{
		if (target == null)
			target = new Event();
		target.Callbacks += action;
		return target;
	}

	public static Event operator -(Event target, Action action)
	{
		if (target == null)
			target = new Event();
		target.Callbacks -= action;
		return target;
	}

	public static Event operator *(Event target, Action action)
	{
		if (target == null)
			target = new Event();
		target.Action = action;
		return target;
	}

	public void Invoke()
	{
		Action?.Invoke();
		Callbacks?.Invoke();
	}
}

public class Event<T>
{
	Action<T> Callbacks { get; set; }
	Action<T> Action { get; set; }

	public static Event<T> operator +(Event<T> target, Action<T> action)
	{
		if (target == null)
			target = new Event<T>();
		target.Callbacks += action;
		return target;
	}

	public static Event<T> operator -(Event<T> target, Action<T> action)
	{
		if (target == null)
			target = new Event<T>();
		target.Callbacks -= action;
		return target;
	}

	public static Event<T> operator *(Event<T> target, Action<T> action)
	{
		if (target == null)
			target = new Event<T>();
		target.Action = action;
		return target;
	}

	public void Invoke(T target)
	{
		Action?.Invoke(target);
		Callbacks?.Invoke(target);
	}
}

public class Event<T1, T2>
{
	Action<T1, T2> Callbacks { get; set; }
	Action<T1, T2> Action { get; set; }

	public static Event<T1, T2> operator +(Event<T1, T2> target, Action<T1, T2> action)
	{
		if (target == null)
			target = new Event<T1, T2>();
		target.Callbacks += action;
		return target;
	}

	public static Event<T1, T2> operator -(Event<T1, T2> target, Action<T1, T2> action)
	{
		if (target == null)
			target = new Event<T1, T2>();
		target.Callbacks -= action;
		return target;
	}

	public static Event<T1, T2> operator *(Event<T1, T2> target, Action<T1, T2> action)
	{
		if (target == null)
			target = new Event<T1, T2>();
		target.Action = action;
		return target;
	}

	public void Invoke(T1 t1, T2 t2)
	{
		Action?.Invoke(t1, t2);
		Callbacks?.Invoke(t1, t2);
	}
}


public class EventFunc<Result>
{
	Action<Result> Callbacks { get; set; }
	Func<Result> Func { get; set; }

	public static EventFunc<Result> operator +(EventFunc<Result> target, Action<Result> action)
	{
		if (target == null)
			target = new EventFunc<Result>();
		target.Callbacks += action;
		return target;
	}

	public static EventFunc<Result> operator -(EventFunc<Result> target, Action<Result> action)
	{
		if (target == null)
			target = new EventFunc<Result>();
		target.Callbacks -= action;
		return target;
	}

	public static EventFunc<Result> operator *(EventFunc<Result> target, Func<Result> func)
	{
		if (target == null)
			target = new EventFunc<Result>();
		target.Func = func;
		return target;
	}

	public Result Invoke()
	{
		var result = Func();
		Callbacks?.Invoke(result);
		return result;
	}
}

public class EventFunc<T, Result>
{
	Action<Result> Callbacks { get; set; }
	Func<T, Result> Func { get; set; }

	public static EventFunc<T, Result> operator +(EventFunc<T, Result> target, Action<Result> action)
	{
		if (target == null)
			target = new EventFunc<T, Result>();
		target.Callbacks += action;
		return target;
	}

	public static EventFunc<T, Result> operator -(EventFunc<T, Result> target, Action<Result> action)
	{
		if (target == null)
			target = new EventFunc<T, Result>();
		target.Callbacks -= action;
		return target;
	}

	public static EventFunc<T, Result> operator *(EventFunc<T, Result> target, Func<T, Result> func)
	{
		if (target == null)
			target = new EventFunc<T, Result>();
		target.Func = func;
		return target;
	}

	public Result Invoke(T t)
	{
		var result = Func(t);
		Callbacks?.Invoke(result);
		return result;
	}
}

public class EventFunc<T1, T2, Result>
{
	Action<Result> Callbacks { get; set; }
	Func<T1, T2, Result> Func { get; set; }

	public static EventFunc<T1, T2, Result> operator +(EventFunc<T1, T2, Result> target, Action<Result> action)
	{
		if (target == null)
			target = new EventFunc<T1, T2, Result>();
		target.Callbacks += action;
		return target;
	}

	public static EventFunc<T1, T2, Result> operator -(EventFunc<T1, T2, Result> target, Action<Result> action)
	{
		if (target == null)
			target = new EventFunc<T1, T2, Result>();
		target.Callbacks -= action;
		return target;
	}

	public static EventFunc<T1, T2, Result> operator *(EventFunc<T1, T2, Result> target, Func<T1, T2, Result> func)
	{
		if (target == null)
			target = new EventFunc<T1, T2, Result>();
		target.Func = func;
		return target;
	}

	public Result Invoke(T1 t1, T2 t2)
	{
		var result = Func(t1, t2);
		Callbacks?.Invoke(result);
		return result;
	}
}
