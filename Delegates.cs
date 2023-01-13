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
			return null;
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
