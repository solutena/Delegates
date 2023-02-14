# Delegates

`Action`, `Func` 등 `delegate`가 여러개로 이루어져 있을 때 추가 및 제거가 정상 동작 한다

여러개의 파라미터가 필요한 경우 `class`, `struct`를 사용한다.

명명된 `class`, `struct` 가 굳이 필요없는 경우 `Tuple`을 사용한다.

### Actions
### Actions<Item>
Action을 리스트로 가지는 클래스이다

`+=` 로 함수을 추가한다

`-=` 로 함수을 제거한다

### Funcs<Result>
### Funcs<<Item>Result>
Func를 리스트로 가지고 Result를 반환하는 클래스이다
	
Result는 숫자만 가능하다

`+=` 로 함수을 추가한다
	
`-=` 로 함수을 제거한다
	
### Event	
### Event<Item>
유일한 Action과 콜백인 Action들을 리스트로 가지는 클래스이다
	
`+=` 로 콜백을 추가한다
	
`-=` 로 콜백을 제거한다
	
`*=` 로 실행할 함수를 대입할 수 있다

### EventFunc<Result>
### EventFunc<Item,Result>	
Func를 리스트로 가지고 Result를 반환하며 콜백인 Action들을 가지는 클래스이다
	
Result는 숫자만 가능하다
	
유일한 Action과 콜백인 Action들을 리스트로 가지는 클래스이다
	
`+=` 로 콜백을 추가한다
	
`-=` 로 콜백을 제거한다
	
`*=` 로 실행할 함수를 대입할 수 있다


## Example

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
