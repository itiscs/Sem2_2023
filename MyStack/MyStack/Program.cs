using MyStack;

MyStack<int> st = new MyStack<int>();

st.Push(1);
st.Push(20);

st.Push(30);
st.Push(40);

Console.WriteLine(st);


Console.WriteLine(st.Pop());
Console.WriteLine(st.Pop());
Console.WriteLine(st.Pop());

Console.WriteLine(st);

MyStack<string> st2 = new MyStack<string>();

st2.Push("Ivan");

st2.Push("Petr");
st2.Push("Maksim");

Console.WriteLine(st2);


Tuple<int, int> t = new Tuple<int, int>(4,5);






