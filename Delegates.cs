using System;
using System.Collections.Generic;
using System.Linq;

public class Actions<T>
{
	public List<Action<T>> List { get; set; } = new List<Action<T>>();

	public void Add(Action<T> action)
	{
		List.Add(action);
	}

	public bool Remove(Action<T> action)
	{
		int index = List.FindIndex(match => match.Method == action.Method);
		if (index < 0)
			return false;
		List.RemoveAt(index);
		return true;
	}

	public void Invoke(T target)
	{
		var list = List.ToList();
		foreach (var item in list)
			item(target);
	}
}

public class FuncsInt<T>
{
	public List<Func<T, int, int>> List { get; set; } = new List<Func<T, int, int>>();

	public void Add(Func<T, int, int> action)
	{
		List.Add(action);
	}

	public bool Remove(Func<T, int, int> action)
	{
		int index = List.FindIndex(match => match.Method == action.Method);
		if (index < 0)
			return false;
		List.RemoveAt(index);
		return true;
	}

	public int Invoke(T target, int value)
	{
		var list = List.ToList();
		foreach (var item in list)
			value = item(target,value);
		return value;
	}
}

public class FuncsFloat<T>
{
	public List<Func<T, float, float>> List { get; set; } = new List<Func<T, float, float>>();

	public void Add(Func<T, float, float> action)
	{
		List.Add(action);
	}

	public bool Remove(Func<T, float, float> action)
	{
		int index = List.FindIndex(match => match.Method == action.Method);
		if (index < 0)
			return false;
		List.RemoveAt(index);
		return true;
	}

	public float Invoke(T target, float value)
	{
		var list = List.ToList();
		foreach (var item in list)
			value = item(target, value);
		return value;
	}
}
