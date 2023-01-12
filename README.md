# Delegates

`Action`, `Func` 등 `delegate`가 여러개로 이루어져 있을 때 추가 및 제거가 정상 동작 한다

여러개의 파라미터가 필요한 경우 `class`, `struct`를 사용한다.

명명된 `class`, `struct` 가 굳이 필요없는 경우 `Tuple`을 사용한다.

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

	Funcs<int> getInt;
	Funcs<Item,int> getIntByItem;
	Funcs<Tuple<Item, int>,int> getIntByItemCount;
}
```

### Actions
`Actions<int> intAction` int를 사용한 함수 실행이다

`Actions<Item> itemAction` Item을 사용한 함수 실행이다

`Actions<Tuple<Item, int>> itemCountAction` Item과 int를 사용한 함수 실행이다

### Funcs
`Funcs<int> getInt` 숫자를 를 반환하는 함수 실행이다

`Funcs<Item,int> getIntByItem` Item을 사용하여 int 를 반환하는 함수 실행이다

`Funcs<Tuple<Item, int>,int> getIntByItemCount` Item과 int를 사용하여 int를 반환하는 함수 실행이다


### Add, Remove

```
void Start()
{
	int Add50(int value)
	{
		return value + 50;
	}

	getInt = new FuncsInt();

	getInt += Add50;
	Debug.Log(getInt.Invoke(100));

	getInt -= Add50;
	Debug.Log(getInt.Invoke(100));
}
```

`Add50` : `value`에 50을 더하는 함수이다.

`+=` 로 함수를 더하고,

`-=` 로 함수를 제거한다.

결과
```
150
100
```

결과와 같이 Add와 Remove가 정상 동작 한다.
