using System;
using System.Collections.Generic;
using System.Linq;

public class Actions
{
	public List<Action> List { get; set; } = new List<Action>();

	public static Actions operator +(Actions actions, Action action)
	{
		if (actions == null)
			actions = new Actions();
		actions.List.Add(action);
		return actions;
	}

	public static Actions operator -(Actions actions, Action action)
	{
		if (actions == null)
			actions = new Actions();
		int index = actions.List.FindIndex(match => match.Method == action.Method);
		if (index < 0)
			return actions;
		actions.List.RemoveAt(index);
		return actions;
	}

	public void Invoke()
	{
		var list = List.ToList();
		foreach (var item in list)
			item();
	}
}

public class Actions<T>
{
	public List<Action<T>> List { get; set; } = new List<Action<T>>();

	public static Actions<T> operator +(Actions<T> actions, Action<T> action)
	{
		if (actions == null)
			actions = new Actions<T>();
		actions.List.Add(action);
		return actions;
	}

	public static Actions<T> operator -(Actions<T> actions, Action<T> action)
	{
		if (actions == null)
			actions = new Actions<T>();
		int index = actions.List.FindIndex(match => match.Method == action.Method);
		if (index < 0)
			return actions;
		actions.List.RemoveAt(index);
		return actions;
	}

	public void Invoke(T target)
	{
		var list = List.ToList();
		foreach (var item in list)
			item(target);
	}
}

public class Funcs<Result> where Result : IComparable
{
	public List<Func<Result, Result>> List { get; set; } = new List<Func<Result, Result>>();

	public static Funcs<Result> operator +(Funcs<Result> funcs, Func<Result, Result> action)
	{
		if (funcs == null)
			funcs = new Funcs<Result>();
		funcs.List.Add(action);
		return funcs;
	}

	public static Funcs<Result> operator -(Funcs<Result> funcs, Func<Result, Result> action)
	{
		if (funcs == null)
			funcs = new Funcs<Result>();
		int index = funcs.List.FindIndex(match => match.Method == action.Method);
		if (index < 0)
			return funcs;
		funcs.List.RemoveAt(index);
		return funcs;
	}

	public Result Invoke(Result value)
	{
		var list = List.ToList();
		foreach (var func in list)
			value = func(value);
		return value;
	}
}

public class Funcs<T, Result> where Result : IComparable
{
	public List<Func<T, Result, Result>> List { get; set; } = new List<Func<T, Result, Result>>();

	public static Funcs<T, Result> operator +(Funcs<T, Result> funcs, Func<T, Result, Result> action)
	{
		if (funcs == null)
			funcs = new Funcs<T, Result>();
		funcs.List.Add(action);
		return funcs;
	}

	public static Funcs<T, Result> operator -(Funcs<T, Result> funcs, Func<T, Result, Result> action)
	{
		if (funcs == null)
			funcs = new Funcs<T, Result>();
		int index = funcs.List.FindIndex(match => match.Method == action.Method);
		if (index < 0)
			return funcs;
		funcs.List.RemoveAt(index);
		return funcs;
	}

	public Result Invoke(T target, Result value)
	{
		var list = List.ToList();
		foreach (var func in list)
			value = func(target, value);
		return value;
	}
}

public class Event<T>
{
	public List<Action<T>> Callbacks { get; set; } = new List<Action<T>>();
	Action<T> _Action { get; set; }

	public static Event<T> operator +(Event<T> target, Action<T> action)
	{
		if (target == null)
			target = new Event<T>();
		target.Callbacks.Add(action);
		return target;
	}

	public static Event<T> operator -(Event<T> target, Action<T> action)
	{
		if (target == null)
			target = new Event<T>();
		int index = target.Callbacks.FindIndex(match => match.Method == action.Method);
		if (index < 0)
			return target;
		target.Callbacks.RemoveAt(index);
		return target;
	}

	public static Event<T> operator *(Event<T> target, Action<T> action)
	{
		if (target == null)
			target = new Event<T>();
		target._Action = action;
		return target;
	}

	public void Invoke(T target)
	{
		_Action?.Invoke(target);
		var loop = Callbacks.ToList();
		foreach (var item in Callbacks)
			item(target);
	}
}

public class Event
{
	public List<Action> Callbacks { get; set; } = new List<Action>();
	Action _Action { get; set; }

	public static Event operator +(Event target, Action action)
	{
		if (target == null)
			target = new Event();
		target.Callbacks.Add(action);
		return target;
	}

	public static Event operator -(Event target, Action action)
	{
		if (target == null)
			target = new Event();
		int index = target.Callbacks.FindIndex(match => match.Method == action.Method);
		if (index < 0)
			return target;
		target.Callbacks.RemoveAt(index);
		return target;
	}

	public static Event operator *(Event target, Action action)
	{
		if (target == null)
			target = new Event();
		target._Action = action;
		return target;
	}

	public void Invoke()
	{
		_Action?.Invoke();
		var loop = Callbacks.ToList();
		foreach (var item in loop)
			item();
	}
}


public class EventFunc<Result>
{
	public List<Action<Result>> Callbacks { get; set; } = new List<Action<Result>>();
	Func<Result> _Func { get; set; }

	public static EventFunc<Result> operator +(EventFunc<Result> target, Action<Result> action)
	{
		if (target == null)
			target = new EventFunc<Result>();
		target.Callbacks.Add(action);
		return target;
	}

	public static EventFunc<Result> operator -(EventFunc<Result> target, Action<Result> action)
	{
		if (target == null)
			target = new EventFunc<Result>();
		int index = target.Callbacks.FindIndex(match => match.Method == action.Method);
		if (index < 0)
			return target;
		target.Callbacks.RemoveAt(index);
		return target;
	}

	public static EventFunc<Result> operator *(EventFunc<Result> target, Func<Result> func)
	{
		if (target == null)
			target = new EventFunc<Result>();
		target._Func = func;
		return target;
	}

	public Result Invoke()
	{
		var result = _Func();
		var loop = Callbacks.ToList();
		foreach (var item in loop)
			item(result);
		return result;
	}
}


public class EventFunc<T,Result>
{
	public List<Action<Result>> Callbacks { get; set; } = new List<Action<Result>>();
	Func<T,Result> _Func { get; set; }

	public static EventFunc<T, Result> operator +(EventFunc<T, Result> target, Action<Result> action)
	{
		if (target == null)
			target = new EventFunc<T, Result>();
		target.Callbacks.Add(action);
		return target;
	}

	public static EventFunc<T, Result> operator -(EventFunc<T, Result> target, Action<Result> action)
	{
		if (target == null)
			target = new EventFunc<T, Result>();
		int index = target.Callbacks.FindIndex(match => match.Method == action.Method);
		if (index < 0)
			return target;
		target.Callbacks.RemoveAt(index);
		return target;
	}

	public static EventFunc<T, Result> operator *(EventFunc<T, Result> target, Func<T, Result> func)
	{
		if (target == null)
			target = new EventFunc<T, Result>();
		target._Func = func;
		return target;
	}

	public Result Invoke(T t)
	{
		var result = _Func(t);
		var loop = Callbacks.ToList();
		foreach (var item in loop)
			item(result);
		return result;
	}
}
