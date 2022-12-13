using System;
using System.Collections.Generic;

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
		List.Reverse();
		for (int i = List.Count - 1; i >= 0; i--)
			List[i](target);
		List.Reverse();
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
		List.Reverse();
		for (int i = List.Count - 1; i >= 0; i--)
			value = List[i](target, value);
		List.Reverse();
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
		List.Reverse();
		for (int i = List.Count - 1; i >= 0; i--)
			value = List[i](target, value);
		List.Reverse();
		return value;
	}
}