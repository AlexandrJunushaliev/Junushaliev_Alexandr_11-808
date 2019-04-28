using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegularExpression
{
    //класс эпсилон-НКА
    class EpsilonNFA
    {
        public Node Start;
        public Node Finish;
        public List<Node> Nodes;
        public EpsilonNFA(Node node1, Node node2, string weight)
        {
            Start = node1;
            Finish = node2;
            Node.Connect(node1, node2, weight);
            Nodes = new List<Node> { node1, node2 };
        }
        //метод создания эпсилон-НКА по регулярному выражению, записанному в обратной польской нотации
        public static EpsilonNFA BuildEpsilonNFAByExp(string exp)
        {
            //в стеке будут лежать автоматы
            //в конце алгоритма в стеке останется один, искомый, автомат
            var stack = new Stack<EpsilonNFA>();
            var i = 0;
            //идем по символам в выражении
            foreach (var symbol in exp)
            {
                //если символ не звездочка Клини, не + и не *, то строим автомат вида О->symbol->O и кладем в стек
                if (symbol != '^' && symbol != '+' && symbol != '*')
                {
                    var nfa = new EpsilonNFA(new Node(i), new Node(i + 1), symbol.ToString());
                    i += 2;
                    stack.Push(nfa);
                }
                //если символ *, то берем из стека два последних автомата и соединяем их по правилу
                //затем кладем в стек
                else if (symbol == '*')
                {
                    var nfa2 = stack.Pop();
                    var nfa1 = stack.Pop();
                    i += 1;
                    Node.Connect(nfa1.Finish, nfa2.Start, "eps");
                    nfa1.Nodes.AddRange(nfa2.Nodes);
                    nfa1.Finish = nfa2.Finish;
                    stack.Push(nfa1);
                }
                //аналогично * (также по правилу)
                else if (symbol == '+')
                {
                    var nfa2 = stack.Pop();
                    var nfa1 = stack.Pop();
                    var Start = new Node(Math.Min(nfa1.Start.NodeNumber, nfa2.Start.NodeNumber) - 1);
                    var Finish = new Node(Math.Max(nfa1.Finish.NodeNumber, nfa2.Finish.NodeNumber) + 1);
                    i++;

                    Node.Connect(Start, nfa1.Start, "eps");
                    nfa1.Start = Start;
                    nfa1.Nodes.Add(Start);

                    Node.Connect(Start, nfa2.Start, "eps");
                    nfa2.Start = Start;
                    nfa1.Nodes.AddRange(nfa2.Nodes);

                    Node.Connect(nfa1.Finish, Finish, "eps");
                    nfa1.Nodes.Add(Finish);
                    nfa1.Finish = Finish;

                    Node.Connect(nfa2.Finish, Finish, "eps");
                    nfa2.Finish = Finish;
                    stack.Push(nfa1);
                }
                //аналогично
                else if (symbol == '^')
                {
                    var nfa = stack.Pop();
                    var Start = new Node(nfa.Start.NodeNumber - 1);
                    var Finish = new Node(nfa.Finish.NodeNumber + 1);
                    i++;
                    Node.Connect(Start, Finish, "eps");
                    Node.Connect(nfa.Finish, nfa.Start, "eps");
                    Node.Connect(Start, nfa.Start, "eps");
                    Node.Connect(nfa.Finish, Finish, "eps");
                    nfa.Start = Start;
                    nfa.Finish = Finish;
                    nfa.Nodes.Add(Start);
                    nfa.Nodes.Add(Finish);
                    stack.Push(nfa);
                }
            }

            var sortedNodes = stack.Peek().Nodes.OrderBy(v => v.NodeNumber).ToList();
            for (var j = 0; j < stack.Peek().Nodes.Count - 1; j++)
            {
                if (sortedNodes[j].NodeNumber == sortedNodes[j + 1].NodeNumber)
                {
                    for (var l = j + 1; l < sortedNodes.Count; l++)
                    {
                        sortedNodes[l].NodeNumber++;
                    }
                }
            }
            //возвращаем автомат
            return stack.Pop();
        }
        //метод обхода автомата
        public static int ByPassENFA(EpsilonNFA nfa, string text)
        {
            //метод находит такой наименьший индекс k, что a1..ak является словом из языка, определяемым регулярным выражением
            //если слово полностью прошло по автомату и не прочиталось, то уменьшаем слово с начала
            //в результате получаем, что как только слово прочитается, то мы получим минимальный индекс k, 
            //для которого существует некоторый j<k : аj..ak - слово из языка, определяемым регулярным выражением
            //reducerCount нужен для восстановления индекса в начальном слове
            var reducerCount = 0;
            //сам метод выполнен по алгоритму
            while (text.Length != 0)
            {
                var states = new List<Node>[text.Length + 1];
                states = states.Select(v => v = new List<Node>()).ToArray();
                for (var i = -1; i < text.Length; i++)
                {

                    var visied = new HashSet<Node>();
                    var list = new List<Node>();
                    if (i == -1)
                    {
                        states[text.Length].Add(nfa.Start);
                        list.AddRange(states[text.Length]);
                    }
                    else
                    {
                        //находим вершины, которые были в предыдущем наборе состояний и у которых есть ребро, которое направлено в них, и вес этого ребра == символу и слове
                        if (i == 0)
                        {
                            states[i].AddRange(nfa.Nodes.Where(v => states[text.Length].Contains(v)).SelectMany(v => v.IncidentNodes.Where(l => l.IncidentEdges.Where(k => k.To == l && k.Weight == text[i].ToString()).Count() != 0)));
                        }
                        else
                            states[i].AddRange(nfa.Nodes.Where(v => states[i - 1].Contains(v)).SelectMany(v => v.IncidentNodes.Where(l => l.IncidentEdges.Where(k => k.To == l && k.Weight == text[i].ToString()).Count() != 0)));
                        list.AddRange(states[i]);
                    }
                    while (list.Count != 0)
                    {
                        {
                            var curNode = list.FirstOrDefault();
                            list.Remove(curNode);
                            //ищем вершины, в которых есть ребро, направленное от вершины, вес которого равен эпсилон
                            var neededNodes = curNode.IncidentNodes.Where(v => v.IncidentEdges.Where(l => l.From == curNode).Where(l => l.Weight == "eps").Count() != 0);
                            foreach (var node in neededNodes)
                            {
                                if (!visied.Contains(node))
                                {
                                    visied.Add(node);
                                    if (i == -1)
                                    {
                                        states[text.Length].Add(node);
                                    }
                                    else
                                    {
                                        states[i].Add(node);
                                    }
                                    list.Add(node);
                                }
                            }
                        }
                    }
                    //после каждой итерации проверяем, не появилось ли в текущем наборе состояний финального
                    //если появлиось, то мы нашли минимальный k : a1..ak - слово из языка, определяемого регулярным выражением
                    if (i == -1)
                    {
                        if (states[text.Length].Contains(nfa.Finish))
                            return reducerCount + i;
                    }
                    else
                    {
                        if (states[i].Contains(nfa.Finish))
                            return reducerCount + i;
                    }
                }
                //если не случилось возврата - обрезаем строку
                text = text.Substring(1);
                reducerCount++;
            }
            //если не случилось ни одного возврата, то в строке нет подстроки : подстрока является словом, определяемым регулярным выражением
            return -1;
        }
    }
}
