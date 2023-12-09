using System;

public class Funcs<Result> where Result : IComparable
{
	Func<Result, Result> Func { get; set; }

	public void Add(Func<Result, Result> action) => Func += action;
	public void Remove(Func<Result, Result> action) => Func -= action;

	public Result Invoke(Result value)
	{
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

	public void Add(Func<T, Result, Result> action) => Func += action;
	public void Remove(Func<T, Result, Result> action) => Func -= action;

	public Result Invoke(T target, Result value)
	{
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

	public void Add(Action action) => Callbacks += action;
	public void Remove(Action action) => Callbacks -= action;
	public void Set(Action action) => Action = action;

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

	public void Add(Action<T> action) => Callbacks += action;
	public void Remove(Action<T> action) => Callbacks -= action;
	public void Set(Action<T> action) => Action = action;

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

	public void Add(Action<T1, T2> action) => Callbacks += action;
	public void Remove(Action<T1, T2> action) => Callbacks -= action;
	public void Set(Action<T1, T2> action) => Action = action;

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

	public void Add(Action<Result> action) => Callbacks += action;
	public void Remove(Action<Result> action) => Callbacks -= action;
	public void Set(Func<Result> action) => Func = action;

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

	public void Add(Action<Result> action) => Callbacks += action;
	public void Remove(Action<Result> action) => Callbacks -= action;
	public void Set(Func<T, Result> action) => Func = action;

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

	public void Add(Action<Result> action) => Callbacks += action;
	public void Remove(Action<Result> action) => Callbacks -= action;
	public void Set(Func<T1, T2, Result> action) => Func = action;

	public Result Invoke(T1 t1, T2 t2)
	{
		var result = Func(t1, t2);
		Callbacks?.Invoke(result);
		return result;
	}
}