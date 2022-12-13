# Delegates

`Action`, `Func` 등 `delegate`가 여러개로 이루어져 있을 때 추가 및 제거가 정상 동작 한다

여러개의 파라미터가 필요한 경우 `class`, `struct`를 사용한다.

`class`, `struct` 가 굳이 필요없는 경우 Tuple을 사용한다.

# 예제

```
public class Example
{
	public class Item
	{
		public string key;
		public int damage;
	}

	Actions<int> intAction;
	Actions<Item> itemAction;
	Actions<Tuple<Item, int>> itemCountAction;

	FuncsInt getInt;
	FuncsInt<Item> getIntByItem;
	FuncsInt<Tuple<Item, int>> getIntByItemCount;

	FuncsFloat getFloat;
	FuncsFloat<Item> getFloatByItem;
	FuncsFloat<Tuple<Item, int>> getFloatByItemCount;
}
```
