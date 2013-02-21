
// F# 教程文件
//
// 此文件包含代码示例来引导您了解
// F# 语言的基元。
//
// 在 http://fsharp.net 网站上了解有关 F# 的更多信息
// 
// 有关更大的 F# 示例集合，请参见:
//     http://go.microsoft.com/fwlink/?LinkID=124614
//
// 内容:
//   - 简单计算
//   - 针对整数的函数
//   - 元组
//   - 布尔值
//   - 字符串
//   - 列表
//   - 数组
//   - 更多集合
//   - 函数
//   - 类型: 联合
//   - 类型: 记录
//   - 类型: 类
//   - 类型: 接口
//   - 类型: 带有接口实现的类
//   - 输出

// 打开某些标准命名空间
open System

// 简单计算
// ---------------------------------------------------------------
// 此处是一些简单的计算。请注意可以如何通过“///”注释来
// 说明代码。将鼠标指针悬停在任何变量引用的上面，
// 可查看相关文档。

/// 一个非常简单的整数常量
let int1 = 1

/// 另一个非常简单的整数常量
let int2 = 2

/// 将两个整数相加
let int3 = int1 + int2

// 针对整数的函数
// ---------------------------------------------------------------

/// 一个针对整数的函数
let f x = 2*x*x - 5*x + 3

/// 简单计算的结果
let result = f (int3 + 4)

/// 另一个针对整数的函数
let increment x = x + 1

/// 计算一个整数的阶乘
let rec factorial n = if n=0 then 1 else n * factorial (n-1)

/// 计算两个整数的最大公因数
let rec hcf a b =                       // 注意: 两个参数之间由空格分隔
    if a=0 then b
    elif a<b then hcf a (b-a)           // 注意: 两个参数之间由空格分隔
    else hcf (a-b) b
    // 注意: 函数参数通常是由空格分隔的
    // 注意:“let rec”定义一个递归函数

      
// 元组
// ---------------------------------------------------------------

// 一个包含整数的简单元组
let pointA = (1, 2, 3)

// 一个包含整数、字符串和双精度浮点数的简单元组
let dataB = (1, "fred", 3.1415)

/// 一个用于交换两个值在元组中的顺序的函数
let Swap (a, b) = (b, a)

// 布尔值
// ---------------------------------------------------------------

/// 一个简单的布尔值
let boolean1 = true

/// 另一个简单的布尔值
let boolean2 = false

/// 使用 AND、OR 和 NOT 计算一个新布尔值
let boolean3 = not boolean1 && (boolean2 || false)

// 字符串
// ---------------------------------------------------------------

/// 一个简单字符串
let stringA  = "Hello"

/// 另一个简单字符串
let stringB  = "world"

/// 使用字符串串联计算的“Hello world”
let stringC  = stringA + " " + stringB

/// 使用 .NET 库函数计算的“Hello world”
let stringD = String.Join(" ",[| stringA; stringB |])
  // 尝试重新键入上面的行以查看 Intellisense 是如何起作用的
  // 注意，针对(部分)标识符按 Ctrl-J 时将重新激活它

// 功能列表
// ---------------------------------------------------------------

/// 空列表
let listA = [ ]           

/// 包含 3 个整数的列表
let listB = [ 1; 2; 3 ]     

/// 包含 3 个整数的列表，注意，:: 是“cons”运算
let listC = 1 :: [2; 3]    

/// 使用递归函数计算一个整数列表的总和
let rec SumList xs =
    match xs with
    | []    -> 0
    | y::ys -> y + SumList ys

/// 列表的总和
let listD = SumList [1; 2; 3]  

/// 介于 1 和 10 之间的整数(含 1 和 10)的列表
let oneToTen = [1..10]

/// 前 10 个整数的平方
let squaresOfOneToTen = [ for x in 0..10 -> x*x ]


// 可变数组
// ---------------------------------------------------------------

/// 创建一个数组
let arr = Array.create 4 "hello"
arr.[1] <- "world"
arr.[3] <- "don"

/// 通过对数组对象使用实例方法计算数组的长度
let arrLength = arr.Length        

// 使用切片表示法提取子数组
let front = arr.[0..2]


// 更多集合
// ---------------------------------------------------------------

/// 一个包含整数键和字符串值的字典
let lookupTable = dict [ (1, "One"); (2, "Two") ]

let oneString = lookupTable.[1]

// 有关其他一些常见的数据结构，请参见:
//   System.Collections.Generic
//   Microsoft.FSharp.Collections
//   Microsoft.FSharp.Collections.Seq
//   Microsoft.FSharp.Collections.Set
//   Microsoft.FSharp.Collections.Map

// 函数
// ---------------------------------------------------------------

/// 一个对其输入求平方的函数
let Square x = x*x              

// 跨值列表映射函数
let squares1 = List.map Square [1; 2; 3; 4]
let squares2 = List.map (fun x -> x*x) [1; 2; 3; 4]

// 管线
let squares3 = [1; 2; 3; 4] |> List.map (fun x -> x*x) 
let SumOfSquaresUpTo n = 
  [1..n] 
  |> List.map Square 
  |> List.sum

// 类型: 联合
// ---------------------------------------------------------------

type Expr = 
  | Num of int
  | Add of Expr * Expr
  | Mul of Expr * Expr
  | Var of string
  
let rec Evaluate (env:Map<string,int>) exp = 
    match exp with
    | Num n -> n
    | Add (x,y) -> Evaluate env x + Evaluate env y
    | Mul (x,y) -> Evaluate env x * Evaluate env y
    | Var id    -> env.[id]
  
let envA = Map.ofList [ "a",1 ;
                        "b",2 ;
                        "c",3 ]
             
let expT1 = Add(Var "a",Mul(Num 2,Var "b"))
let resT1 = Evaluate envA expT1


// 类型: 记录
// ---------------------------------------------------------------

type Card = { Name  : string;
              Phone : string;
              Ok    : bool }
              
let cardA = { Name = "Alf" ; Phone = "(206) 555-0157" ; Ok = false }
let cardB = { cardA with Phone = "(206) 555-0112"; Ok = true }
let ShowCard c = 
  c.Name + " Phone: " + c.Phone + (if not c.Ok then " (unchecked)" else "")


// 类型: 类
// ---------------------------------------------------------------

/// 二维矢量
type Vector2D(dx:float, dy:float) = 
    // 预先计算的矢量长度
    let length = sqrt(dx*dx + dy*dy)
    /// 沿 X 轴的位移
    member v.DX = dx
    /// 沿 Y 轴的位移
    member v.DY = dy
    /// 矢量的长度
    member v.Length = length
    // 按某个常量重新缩放矢量
    member v.Scale(k) = Vector2D(k*dx, k*dy)
    

// 类型: 接口
// ---------------------------------------------------------------

type IPeekPoke = 
    abstract Peek: unit -> int
    abstract Poke: int -> unit

              
// 类型: 带有接口实现的类
// ---------------------------------------------------------------

/// 一个用于计算其被发送的次数的小组件
type Widget(initialState:int) = 
    /// 该小组件的内部状态
    let mutable state = initialState

    // 实现 IPeekPoke 接口
    interface IPeekPoke with 
        member x.Poke(n) = state <- state + n
        member x.Peek() = state 
        
    /// 是否已发送该小组件?
    member x.HasBeenPoked = (state <> 0)


let widget = Widget(12) :> IPeekPoke

widget.Poke(4)
let peekResult = widget.Peek()

              
// 输出
// ---------------------------------------------------------------

// 输出一个整数
printfn "peekResult = %d" peekResult 

// 对一般输出使用 %A 来输出结果
printfn "listC = %A" listC
