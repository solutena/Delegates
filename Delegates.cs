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

public class FuncsInt
{
	public List<Func<int, int>> List { get; set; } = new List<Func<int, int>>();

	public static FuncsInt operator +(FuncsInt funcs, Func<int, int> action)
	{
		if (funcs == null)
			funcs = new FuncsInt();
		funcs.List.Add(action);
		return funcs;
	}

	public static FuncsInt operator -(FuncsInt funcs, Func<int, int> action)
	{
		int index = funcs.List.FindIndex(match => match.Method == action.Method);
		if (index < 0)
			return funcs;
		funcs.List.RemoveAt(index);
		return funcs;
	}

	public int Invoke(int value)
	{
		var list = List.ToList();
		foreach (var item in list)
			value = item(value);
		return value;
	}
}

public class FuncsInt<T>
{
	public List<Func<T, int, int>> List { get; set; } = new List<Func<T, int, int>>();

	public static FuncsInt<T> operator +(FuncsInt<T> funcs, Func<T, int, int> action)
	{
		if (funcs == null)
			funcs = new FuncsInt<T>();
		funcs.List.Add(action);
		return funcs;
	}

	public static FuncsInt<T> operator -(FuncsInt<T> funcs, Func<T, int, int> action)
	{
		int index = funcs.List.FindIndex(match => match.Method == action.Method);
		if (index < 0)
			return funcs;
		funcs.List.RemoveAt(index);
		return funcs;
	}

	public int Invoke(T target, int value)
	{
		var list = List.ToList();
		foreach (var item in list)
			value = item(target, value);
		return value;
	}
}

public class FuncsFloat
{
	public List<Func<float, float>> List { get; set; } = new List<Func<float, float>>();

	public static FuncsFloat operator +(FuncsFloat funcs, Func<float, float> action)
	{
		if (funcs == null)
			funcs = new FuncsFloat();
		funcs.List.Add(action);
		return funcs;
	}

	public static FuncsFloat operator -(FuncsFloat funcs, Func<float, float> action)
	{
		int index = funcs.List.FindIndex(match => match.Method == action.Method);
		if (index < 0)
			return funcs;
		funcs.List.RemoveAt(index);
		return funcs;
	}

	public float Invoke(float value)
	{
		var list = List.ToList();
		foreach (var item in list)
			value = item(value);
		return value;
	}
}

public class FuncsFloat<T>
{
	public List<Func<T, float, float>> List { get; set; } = new List<Func<T, float, float>>();

	public static FuncsFloat<T> operator +(FuncsFloat<T> funcs, Func<T, float, float> action)
	{
		if (funcs == null)
			funcs = new FuncsFloat<T>();
		funcs.List.Add(action);
		return funcs;
	}

	public static FuncsFloat<T> operator -(FuncsFloat<T> funcs, Func<T, float, float> action)
	{
		int index = funcs.List.FindIndex(match => match.Method == action.Method);
		if (index < 0)
			return funcs;
		funcs.List.RemoveAt(index);
		return funcs;
	}

	public float Invoke(T target, float value)
	{
		var list = List.ToList();
		foreach (var item in list)
			value = item(target, value);
		return value;
	}
}
